using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace Tensee.Banch.Web.Controllers.Handlers
{
    public static class Config
    {
        private static readonly bool noCache = true;
        private static JObject BuildItems()
        {
            var json = File.ReadAllText(Path.Combine(typeof(Config).GetAssembly().GetDirectoryPathOrNull(), "FileUploadConfig.json"));
            return JObject.Parse(json);
        }

        public static JObject Items
        {
            get
            {
                if (noCache || _Items == null)
                {
                    _Items = BuildItems();
                }
                return _Items;
            }
        }
        private static JObject _Items;


        public static T GetValue<T>(string key)
        {
            return Items[key].Value<T>();
        }

        public static string[] GetStringList(string key)
        {
            return Items[key].Select(x => x.Value<string>()).ToArray();
        }

        public static string GetString(string key)
        {
            return GetValue<string>(key);
        }

        public static int GetInt(string key)
        {
            return GetValue<int>(key);
        }
    }
}
