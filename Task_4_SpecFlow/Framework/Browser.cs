using OpenQA.Selenium;

namespace Framework
{
    public static class Browser
    {
        private static IWebDriver driver;
        private static readonly object lockObject = new object();

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                lock (lockObject)
                {
                    if (driver == null)
                    {
                        driver = BrowserFactory.GetInstance();
                    }
                }
            }
            return driver;
        }
    }
}