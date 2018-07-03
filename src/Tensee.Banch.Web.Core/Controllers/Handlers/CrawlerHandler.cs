using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tensee.Banch.Web.Controllers.Handlers
{
    /// <summary>
    /// 图片爬取处理器
    /// </summary>
    public class CrawlerHandler : Handler
    {
        private string[] Sources;
        private Crawler[] Crawlers;
        private readonly string FilePath;
        public CrawlerHandler(Microsoft.AspNetCore.Http.HttpContext context, string filePath) : base(context) { FilePath = filePath; }

        public override ContentResult Process()
        {
            Sources = Request.Form["source[]"];
            if (Sources == null || Sources.Length == 0)
            {
                return  WriteJson(new
                {
                    state = "参数错误：没有指定抓取源"
                });
            }
            Crawlers = Sources.Select(x => new Crawler(x, FilePath).Fetch()).ToArray();
            return WriteJson(new
            {
                state = "SUCCESS",
                list = Crawlers.Select(x => new
                {
                    state = x.State,
                    source = x.SourceUrl,
                    url = x.ServerUrl
                })
            });
        }
    }

    /// <summary>
    /// 爬取
    /// </summary>
    public class Crawler
    {
        public string SourceUrl { get; set; }
        public string ServerUrl { get; set; }
        public string State { get; set; }

        private string WebRootPath { get; set; }


        public Crawler(string sourceUrl, string webRootPath)
        {
            SourceUrl = sourceUrl;
            WebRootPath = webRootPath;
        }

        public Crawler Fetch()
        {
            if (!IsExternalIPAddress(SourceUrl))
            {
                State = "INVALID_URL";
                return this;
            }
            var request = new HttpClient();
            try
            {
                ServerUrl = PathFormatter.Format(Path.GetFileName(SourceUrl), Config.GetString("catcherPathFormat"));
                var savePath = Path.Combine(WebRootPath, ServerUrl.Replace('/', Path.DirectorySeparatorChar));
                if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                }
                var stream = request.GetStreamAsync(SourceUrl).Result;
                using (var fs = new FileStream(savePath, FileMode.OpenOrCreate))
                {
                    stream.CopyToAsync(fs).Wait();
                }
                State = "SUCCESS";
                return this;
            }
            catch (Exception e)
            {
                State = e.Message;
                return this;
            }
        }

        private bool IsExternalIPAddress(string url)
        {
            var uri = new Uri(url);
            switch (uri.HostNameType)
            {
                case UriHostNameType.Dns:
                    var ipHostEntry = Dns.GetHostEntry(uri.DnsSafeHost);
                    foreach (IPAddress ipAddress in ipHostEntry.AddressList)
                    {
                        byte[] ipBytes = ipAddress.GetAddressBytes();
                        if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            if (!IsPrivateIP(ipAddress))
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case UriHostNameType.IPv4:
                    return !IsPrivateIP(IPAddress.Parse(uri.DnsSafeHost));
            }
            return false;
        }

        private bool IsPrivateIP(IPAddress myIPAddress)
        {
            if (IPAddress.IsLoopback(myIPAddress)) return true;
            if (myIPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                byte[] ipBytes = myIPAddress.GetAddressBytes();
                // 10.0.0.0/24 
                if (ipBytes[0] == 10)
                {
                    return true;
                }
                // 172.16.0.0/16
                else if (ipBytes[0] == 172 && ipBytes[1] == 16)
                {
                    return true;
                }
                // 192.168.0.0/16
                else if (ipBytes[0] == 192 && ipBytes[1] == 168)
                {
                    return true;
                }
                // 169.254.0.0/16
                else if (ipBytes[0] == 169 && ipBytes[1] == 254)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
