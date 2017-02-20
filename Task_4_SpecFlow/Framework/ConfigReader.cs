using Framework.Properties;
using Newtonsoft.Json;
using System.IO;

namespace Framework.Models
{
    public class ConfigReader
    {
        public string BrowserName { get; set; }
        public string SiteUrl { get; set; }

        public static ConfigReader Config;

        static ConfigReader()
        {
            Config = JsonConvert.DeserializeObject<ConfigReader>(File.ReadAllText(Resources.PathConfigFile));
        }

        public static string GetBrowserName()
        {
            return Config.BrowserName;
        }

        public static string GetSiteUrl()
        {
            return Config.SiteUrl;
        }

        public static ConfigReader GetConfigFile()
        {
            return Config;
        }
    }
}