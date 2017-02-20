using Framework.Properties;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;

namespace Framework
{
    public class Page
    {
        public static ConfigFile PageConfigFile { get; set; }
        public static Dictionary<string, string> LocalDictionary { get; set; }
        public IWebDriver CurrentDriver = WebBrowser.GetDriver();
        public Menu TopMenu;
        public Menu NavigationMenu;

        public Page()
        {
            TopMenu = new Menu();
            NavigationMenu = new Menu();
        }

        public void InitPage()
        {
            PageConfigFile = new ConfigFile();
            PageConfigFile = ConfigReader.GetConfigFile();
            LocalDictionary = new Dictionary<string, string>();
            LocalDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(GetPathToLocalDictionary()));
        }

        public string GetPathToLocalDictionary()
        {
            if (PageConfigFile.LocationLang.Equals(Resources.RuLangValue))
            {
                return Resources.PathRuDictionary;
            }
            else
            {
                return Resources.PathEngDictionary;
            }
        }
    }
}