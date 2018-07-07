using Abp.AspNetCore;
using Abp.AspNetZeroCore.Web.Authentication.JwtBearer;
using Abp.Castle.Logging.Log4Net;
using Castle.Facilities.Logging;
using Hangfire;
using Hangfire.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Linq;
using Tensee.Banch.Configuration;
using Tensee.Banch.EntityFrameworkCore;
using Tensee.Banch.Identity;
using Tensee.Banch.Web.IdentityServer;
#if FEATURE_SIGNALR
using Abp.Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using Owin.Security.AesDataProtectorProvider;
using Abp.Web.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Abp.AspNetZeroCore.Web.Owin;
#elif FEATURE_SIGNALR_ASPNETCORE
using Abp.AspNetCore.SignalR.Hubs;
#endif


namespace Tensee.Banch.Web.Startup
{
    public class Startup
    {
        private const string DefaultCorsPolicyName = "localhost";
        private readonly IConfigurationRoot _appConfiguration;
        private readonly string WebRootPath;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
            WebRootPath = env.WebRootPath;
        }


        private static System.Collections.Generic.List<string> GetXmlCommentsPath()
        {          
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\xmls\";
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }
            var docs = Directory.GetFiles(baseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
            return docs;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //MVC
            services.AddMvc(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(DefaultCorsPolicyName));
            });
#if FEATURE_SIGNALR_ASPNETCORE
            services.AddSignalR(options =>
            {
                // Faster pings for testing
                options.KeepAliveInterval = TimeSpan.FromSeconds(5);
            }).AddJsonProtocol(options =>
            {
                //options.PayloadSerializerSettings.Converters.Add(JsonConver);
                //the next settings are important in order to serialize and deserialize date times as is and not convert time zones
                options.PayloadSerializerSettings.Converters.Add(new IsoDateTimeConverter());
                options.PayloadSerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;
                options.PayloadSerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
            });
#endif
            //Configure CORS for angular2 UI
            services.AddCors(
                options => options.AddPolicy(
                    DefaultCorsPolicyName,
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);
            
            //Identity server
            if (bool.Parse(_appConfiguration["IdentityServer:IsEnabled"]))
            {
                IdentityServerRegistrar.Register(services, _appConfiguration);
            }

            //Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            
            var xmls = GetXmlCommentsPath();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Banch API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.OperationFilter<FormFileOperationFilter>();
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Authorization format : Bearer {token}",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                options.AddSecurityDefinition("Abp.TenantId", new ApiKeyScheme
                {
                    Description = "Abp.TenantId: {Int}",
                    Name = "Abp.TenantId",
                    In = "header",
                    Type = "apiKey"
                });
                foreach (var xml in xmls)
                {
                    if (File.Exists(xml))
                    {
                        options.IncludeXmlComments(xml);
                    }                   
                }

                //api界面新增authorize按钮
            });

            //Recaptcha
            services.AddRecaptcha(new RecaptchaOptions
            {
                SiteKey = _appConfiguration["Recaptcha:SiteKey"],
                SecretKey = _appConfiguration["Recaptcha:SecretKey"]
            });

            //Hangfire (Enable to use Hangfire instead of default job manager)
            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(_appConfiguration.GetConnectionString("Default"));
            });


         

            var webApisPluginsFolder=Path.Combine(WebRootPath, "WebApisPlugins");
            if (!Directory.Exists(webApisPluginsFolder)) Directory.CreateDirectory(webApisPluginsFolder);
           
            //Configure Abp and Dependency Injection
            return services.AddAbp<BanchWebHostModule>(options =>
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
                options.PlugInSources.Add(new Abp.PlugIns.FolderPlugInSource(webApisPluginsFolder));
            });


         


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Initializes ABP framework.
            app.UseAbp(options =>
            {
                options.UseAbpRequestLocalization = false; //used below: UseAbpRequestLocalization

            });
            app.UseAuthentication();

            app.UseJwtTokenMiddleware();

            if (bool.Parse(_appConfiguration["IdentityServer:IsEnabled"]))
            {
                app.UseJwtTokenMiddleware("IdentityBearer");
                app.UseIdentityServer();
            }

#if FEATURE_SIGNALR
            // Integrate with OWIN
            app.UseAppBuilder(ConfigureOwinServices);
#elif FEATURE_SIGNALR_ASPNETCORE
            app.UseSignalR(routes =>
            {
                 routes.MapHub<AbpCommonHub>("/signalr", options => options.WebSockets.SubProtocolSelector = requestedProtocols =>
                {
                    return requestedProtocols.Count > 0 ? requestedProtocols[0] : null;
                });
#if CHATNOANNOY
                routes.MapHub<Chat.ChatNoAnnoy.ChatNoAnnoy>("/chatNoAnnoy", options =>
                    options.WebSockets.SubProtocolSelector = requestedProtocols =>
                    {
                        return requestedProtocols.Count > 0 ? requestedProtocols[0] : null;
                    });
#endif
            });
#endif
            app.UseCors(DefaultCorsPolicyName); //Enable CORS!



            app.UseStaticFiles();

            if (DatabaseCheckHelper.Exist(_appConfiguration["ConnectionStrings:Default"]))
            {
                app.UseAbpRequestLocalization();
            }

#if FEATURE_SIGNALR
            //Integrate to OWIN
            app.UseAppBuilder(ConfigureOwinServices);
#endif

            //Hangfire dashboard & server (Enable to use Hangfire instead of default job manager)
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                // Authorization = new[] { new AbpHangfireAuthorizationFilter(AppPermissions.Pages_Administration_HangfireDashboard) }
                Authorization = new[] { new CustomAuthorizeFilter() }
            });
            app.UseHangfireServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Banch API V1");
            }); //URL: /swagger
#if EXTERNLOGIN
            //开启后台hangfire作业
            //BackgroundJob.Schedule<IHangfireJobAppSevice>(r => r.StartHangfire(), TimeSpan.FromMinutes(1));

#endif



        }

#if FEATURE_SIGNALR
        private static void ConfigureOwinServices(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(typeof(IAssemblyLocator), () => new SignalRAssemblyLocator());
            app.Properties["host.AppName"] = "Banch";

            app.UseAbp();
            app.UseAesDataProtectorProvider();

            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);

                var hubConfiguration = new HubConfiguration
                {
                    EnableJSONP = true
                };

                map.RunSignalR(hubConfiguration);
            });
        }
#endif


    }
}

public class CustomAuthorizeFilter : Hangfire.Dashboard.IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] Hangfire.Dashboard.DashboardContext context)
    {
        //var httpcontext = context.GetHttpContext();
       // return httpcontext.User.Identity.IsAuthenticated;
        return true;
    }
}
