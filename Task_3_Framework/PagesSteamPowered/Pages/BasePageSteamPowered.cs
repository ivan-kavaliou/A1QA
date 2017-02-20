using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PagesSteamPowered.PageModels;
using PagesSteamPowered.Properties;
using System;

namespace PagesSteamPowered.Pages
{
    public class BasePageSteamPowered : Page
    {
        public Element BtnChangeLang = new Element(Resources.XPathLocalLangDropDown, "Button 'Current location language'");
        public Element LblRuLang = new Element(Resources.XPathRuLocal, "Link 'Ru location language'");
        public Element LblEnLang = new Element(Resources.XPathEngLocal, "Link 'En location language");
        public Element BtnTypeOfGame = new Element(Resources.XPathGameDropDownSpanSpan, "Button 'Location games button'");
        public Element PageNameElement = new Element(Resources.XPathPageTitle, "PageName");
        public Logger TestLogger { get; set; }
        public Element BtnActionGame;
        public static Game ExpectedGame, ActualGame;

        public BasePageSteamPowered()
        {
            TopMenu.AddElement(BtnChangeLang);
            NavigationMenu.AddElement(BtnTypeOfGame);
            TestLogger=new Logger();
        }

        public void CheckPageConfig()
        {
            if (!PageConfigFile.SiteUrl.Equals(Resources.UrlPage))
            {
                Assert.Fail("Url page in config file is wrong");
            }
            else
            {
                CurrentDriver.Url = PageConfigFile.SiteUrl;
            }

            if (PageConfigFile.LocationLang == LocalDictionary["Local"] &&
                BtnChangeLang.Text() == LocalDictionary["Language"])
            {
                return;
            }
            else if (PageConfigFile.LocationLang == LocalDictionary["Local"] &&
                BtnChangeLang.Text() == LocalDictionary["Language"])
            {
                BtnChangeLang.Click();
                LblRuLang.Click();
            }
            else
            {
                BtnChangeLang.Click();
                LblEnLang.Click();
            }

            WebDriverWait wait = new WebDriverWait(CurrentDriver, TimeSpan.FromSeconds(30));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException),
                                               typeof(StaleElementReferenceException));
            wait.Until(ExpectedConditions.ElementIsVisible(BtnTypeOfGame.Locator));
            
        }
    }
}