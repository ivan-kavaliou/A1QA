using System;
using Framework;
using OpenQA.Selenium;
using PagesSteamPowered.Properties;
using System.IO;
using System.Reflection;

namespace PagesSteamPowered.Pages
{
    public class DownLoadPage : BasePageSteamPowered
    {
        public Element BtnDownloadSteam = new Element(Resources.XPathDownloadSteamBtn, "Button 'Download Steam'");
        private readonly string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Datatest\\SteamSetup.exe";

        public void DownloadSteam()
        {
            BtnDownloadSteam.WaitElement();

            JavaScriptClick(CurrentDriver.FindElement(BtnDownloadSteam.Locator));

            while (!File.Exists(_path)|| File.ReadAllBytes(_path).Length==0)
            {
                CurrentDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            }
        }

        public bool CheckDownload()
        {
            TestLogger.Info(Resources.StrCheckingDowloadingFile);
            
            
            if (File.ReadAllBytes(_path).Length > 1000)
            {
                TestLogger.Debug("Game is dowloaded");
                return true;
            }
            else
            {
                TestLogger.Debug("Game is NOT downloaded");
                return false;
            }
        }

        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)CurrentDriver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        
    }
}