using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PagesSteamPowered;
using PagesSteamPowered.Pages;
using System.IO;
using System.Reflection;
using UnitTestSteamPowered.Properties;

namespace UnitTestSteamPowered
{
    [TestClass]
    public class AutoTestsSteamPowered
    {
        public TestContext TestContext { get; set; }
        public IWebDriver CurrentBrowser { get; set; }
        public Logger TestLogger { get; set; }

        [TestInitialize]
        public void InitTest()
        {
            CurrentBrowser = WebBrowser.GetDriver();
            //CurrentBrowser.Manage().Window.Maximize();

            string pathLogFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt";
            if (File.Exists(pathLogFile))
            {
                File.Delete(pathLogFile);
            }
            string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Datatest\\SteamSetup.exe";

            DirectoryInfo dir = Directory.CreateDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Datatest");


            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Datatest");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
                
            }

            TestLogger = new Logger();
            TestLogger.Info(Resources.StrInitTest);
            TestLogger.Info(TestContext.TestName);
        }

        [TestMethod]
        public void SteamTest()
        {
            MainPageSteamPowered newMainPage = new MainPageSteamPowered();
            ActionPageSteamPowered newActionPage = new ActionPageSteamPowered();
            SelectGamePage newSelectGamePage = new SelectGamePage();
            DownLoadPage newDownLoadPage = new DownLoadPage();

            //MainPage
            TestLogger.Info(Resources.StrOpenMainPage);
            newMainPage.InitPage();
            newMainPage.CheckPageConfig();
            newMainPage.SelectActionGame();

            //ActionPage
            TestLogger.Info(Resources.StrGoActionPage);
            newActionPage.SelectMaxDiscount();
            newActionPage.CheckAgeGateOnPage();

            //SelectedGamePage
            TestLogger.Info(Resources.StrGoDownloadGame);
            Assert.AreEqual(true, newSelectGamePage.IsDiscountAndPriceCorrect());
            newSelectGamePage.DownloadSteam();

            //DownloadSteamPage
            TestLogger.Info(Resources.StrGoDownloadSteam);

            newDownLoadPage.DownloadSteam();
            Assert.AreEqual(true, newDownLoadPage.CheckDownload());
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            TestLogger.Info(Resources.StrTestResaults);
            TestLogger.Info(TestContext.TestName + " : " + TestContext.CurrentTestOutcome);
            CurrentBrowser.Quit();
        }
    }
}