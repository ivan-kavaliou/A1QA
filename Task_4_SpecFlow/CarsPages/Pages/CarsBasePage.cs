using CarsPages.Menus;
using CarsPages.Models;
using Framework;
using Framework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace CarsPages.Pages
{
    public class CarsBasePage
    {
        public TopMenu TopMenu;
        public SubMenuBuy SubMenuBuy;

        public static ConfigReader PageConfigFile { get; set; }
        public static Dictionary<string, string> LocalDictionary { get; set; }
        public IWebDriver CurrentDriver = Browser.GetDriver();

        public CarsBasePage()
        {
            TopMenu = new TopMenu();
            SubMenuBuy = new SubMenuBuy();
            PageConfigFile = new ConfigReader();
            PageConfigFile = ConfigReader.GetConfigFile();
        }

        public string GetTitle()
        {
            return CurrentDriver.Title;
        }

        public void WaitUntilPageIsReady(int timeout)
        {
            IWait<IWebDriver> wait = new WebDriverWait(CurrentDriver, TimeSpan.FromSeconds(timeout));
            wait.Until(driver1 => ((IJavaScriptExecutor)CurrentDriver).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}