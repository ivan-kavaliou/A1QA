using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;

namespace Framework
{
    public class BrowserFactory
    {
        public static string absolutePath;

        public static IWebDriver GetInstance()
        {
            absolutePath =Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Datatest";

            if (ConfigReader.GetBrowserName() == "Chrome")
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("download.default_directory", absolutePath);
                chromeOptions.AddUserProfilePreference("safebrowsing.enabled", "true");
                return new ChromeDriver(chromeOptions);
            }
            else if (ConfigReader.GetBrowserName() == "Firefox")
            {
                var fireFoxProfile = new FirefoxProfile();
                fireFoxProfile.SetPreference("browser.download.dir", absolutePath);
                fireFoxProfile.SetPreference("browser.download.folderList", 2);
                fireFoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");

                return new FirefoxDriver(fireFoxProfile);
            }

            return new FirefoxDriver();
        }
    }
}