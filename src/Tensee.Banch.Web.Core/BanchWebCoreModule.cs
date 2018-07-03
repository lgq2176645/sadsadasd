using System;
using System.IO;
using System.Text;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetZeroCore.Licensing;
using Abp.AspNetZeroCore.Web;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.IO;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Caching.Redis;
using Abp.Zero.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Tensee.Banch.Configuration;
using Tensee.Banch.EntityFrameworkCore;
using Tensee.Banch.Web.Authentication.JwtBearer;
using Tensee.Banch.Web.Authentication.TwoFactor;
using Tensee.Banch.Web.Chat.SignalR;
using Tensee.Banch.Web.Configuration;
#if FEATURE_SIGNALR
#endif

namespace Tensee.Banch.Web
{
    [DependsOn(
        typeof(BanchApplicationModule),
        typeof(BanchEntityFrameworkCoreModule),
        typeof(AbpAspNetZeroCoreWebModule),
#if FEATURE_SIGNALR
        //typeof(AbpWebSignalRModule),
#endif
        typeof(AbpRedisCacheModule), //AbpRedisCacheModule dependency (and Abp.RedisCache nuget package) can be removed if not using Redis cache
        typeof(AbpHangfireAspNetCoreModule) //AbpHangfireModule dependency (and Abp.Hangfire.AspNetCore nuget package) can be removed if not using Hangfire
    )]
    public class BanchWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BanchWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            //Set default connection string
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                BanchConsts.ConnectionStringName
            );

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Add applicationService module to WebApi
            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(BanchApplicationModule).GetAssembly()
                );

            Configuration.Caching.Configure(TwoFactorCodeCacheItem.CacheName, cache =>
            {
                cache.DefaultAbsoluteExpireTime = TimeSpan.FromMinutes(2);
            });

            if (_appConfiguration["Authentication:JwtBearer:IsEnabled"] != null && bool.Parse(_appConfiguration["Authentication:JwtBearer:IsEnabled"]))
            {
                ConfigureTokenAuth();
            }

            Configuration.ReplaceService<IAppConfigurationAccessor, AppConfigurationAccessor>();

            //Uncomment this line to use Hangfire instead of default background job manager (remember also to uncomment related lines in Startup.cs file(s)).
            Configuration.BackgroundJobs.UseHangfire();

            //Uncomment this line to use Redis cache instead of in-memory cache.
            //注释掉这行在内存中缓存而不是使用Redis缓存
            //See app.config for Redis configuration and connection string
            //设置 Redis的链接字符串
            //Configuration.Caching.UseRedis(options =>
            //{
            //    options.ConnectionString = _appConfiguration["Abp:RedisCache:ConnectionString"];
            //    options.DatabaseId = _appConfiguration.GetValue<int>("Abp:RedisCache:DatabaseId");
            //});

            //设置所有Redis缓存的默认过期时间
            Configuration.Caching.ConfigureAll(cache =>
            {
                cache.DefaultAbsoluteExpireTime = TimeSpan.FromHours(2);//微信token默认7200s
            });

            //设置某个缓存的默认过期时间 根据 "CacheName" 来区分
            Configuration.Caching.Configure("CacheName", cache =>
            {
                cache.DefaultAbsoluteExpireTime = TimeSpan.FromHours(2);
            });

        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {

            //IocManager.Register<Banch.Chat.IChatCommunicator, SignalRChatCommunicator>();
            IocManager.RegisterAssemblyByConvention(typeof(BanchWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            SetAppFolders();
        }

        private void SetAppFolders()
        {
            var appFolders = IocManager.Resolve<AppFolders>();
          //  WxMallAfterSaleImgFolder
            appFolders.SampleProfileImagesFolder = Path.Combine(_env.WebRootPath, $"Common{Path.DirectorySeparatorChar}Images{Path.DirectorySeparatorChar}SampleProfilePics");
            appFolders.TempFileDownloadFolder = Path.Combine(_env.WebRootPath, $"Temp{Path.DirectorySeparatorChar}Downloads");
            appFolders.WebLogsFolder = Path.Combine(_env.ContentRootPath, $"App_Data{Path.DirectorySeparatorChar}Logs");
            appFolders.ImagesFolder = Path.Combine(_env.WebRootPath, $"Temp{Path.DirectorySeparatorChar}Images");
            appFolders.WxMallGoodsImgFolder = Path.Combine(_env.WebRootPath, $"Common{Path.DirectorySeparatorChar}Wxpicture{Path.DirectorySeparatorChar}Goods");
            appFolders.WxMallBannerImgFolder = Path.Combine(_env.WebRootPath, $"Common{Path.DirectorySeparatorChar}Wxpicture{Path.DirectorySeparatorChar}Banner");
            appFolders.WxMallBrandImgFolder = Path.Combine(_env.WebRootPath, $"Common{Path.DirectorySeparatorChar}Wxpicture{Path.DirectorySeparatorChar}Brand");
            appFolders.WxMallCategoryImgFolder = Path.Combine(_env.WebRootPath, $"Common{Path.DirectorySeparatorChar}Wxpicture{Path.DirectorySeparatorChar}Category");
            appFolders.WxMallExcelsFolder = Path.Combine(_env.WebRootPath, $"Common{Path.DirectorySeparatorChar}WxExcels");
            appFolders.TravelsMediaFolder = Path.Combine(_env.WebRootPath, $"Common{Path.DirectorySeparatorChar}TravelsMedia");
            appFolders.WxMallAfterSaleImgFolder = Path.Combine(_env.WebRootPath, $"Common{Path.DirectorySeparatorChar}Wxpicture{Path.DirectorySeparatorChar}AfterSale");
#if NET461
            if (_env.IsDevelopment())
            {
                var currentAssemblyDirectoryPath = typeof(BanchWebCoreModule).GetAssembly().GetDirectoryPathOrNull();
                if (currentAssemblyDirectoryPath != null)
                {
                    appFolders.WebLogsFolder = Path.Combine(currentAssemblyDirectoryPath, $"App_Data{Path.DirectorySeparatorChar}Logs");
                }
            }
#endif

            try
            {
                DirectoryHelper.CreateIfNotExists(appFolders.TempFileDownloadFolder);
            }
            catch { }
        }
    }
}
