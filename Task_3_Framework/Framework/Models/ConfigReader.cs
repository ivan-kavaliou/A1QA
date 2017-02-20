using Newtonsoft.Json;
using System.IO;
using Framework.Properties;

namespace Framework
{
    public static class ConfigReader
    {
        public static ConfigFile Config { get; set; }
        
        
        static ConfigReader()
        {
            Config = JsonConvert.DeserializeObject<ConfigFile>(File.ReadAllText(Resources.PathConfigFile));
        }

        public static string GetBrowserName()
        {
            return Config.BrowserName;
        }

        public static string GetSiteUrl()
        {
            return Config.SiteUrl;
        }

        public static string GetLocationLang()
        {
            return Config.LocationLang;
        }

        public static ConfigFile GetConfigFile()
        {
            return Config;
        }

        
    }
}