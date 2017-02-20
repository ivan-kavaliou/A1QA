using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework
{
    public class Element
    {
        public IWebDriver CurrentDriver = WebBrowser.GetDriver();
        public By Locator { get; set; }
        public string ElementName { get; set; }
        public WebDriverWait Wait { get; set; }
        public Logger TestLogger { get; set; }

        public Element(string xPath, string name)
        {
            ElementName = name;
            Locator = By.XPath(xPath);
            Wait = new WebDriverWait(CurrentDriver, TimeSpan.FromSeconds(30));
            TestLogger=new Logger();
        }

        public Element(By locator, string name)
        {
            ElementName = name;
            Locator = locator;
            TestLogger=new Logger();
        }

        public void Click()
        {
            WaitElement();
            CurrentDriver.FindElement(Locator).Click();
            TestLogger.Info(ElementName+ " :: Clicking");
        }

        public string GetElementName()
        {
            return ElementName;
        }

        public string Text()
        {
            WaitElement();
            return CurrentDriver.FindElement(Locator).Text;
        }

        public void SelectByValue(string value)
        {
            WaitElement();
            CurrentDriver.FindElement(Locator).SendKeys(value);
        }

        public bool IsEnabled()
        {
            WaitElement();
            return CurrentDriver.FindElement(Locator).Enabled;
        }

        public bool TryFindElement(By locator)
        {
            try
            {
                CurrentDriver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void MoveToElement()
        {
            Actions actions = new Actions(CurrentDriver);
            actions.MoveToElement(CurrentDriver.FindElement(Locator));
            actions.Perform();
        }

        public void WaitElement()
        {
            Wait.Until(
                (d) =>
                {
                    IWebElement element = d.FindElement(Locator);
                    Wait.IgnoreExceptionTypes(typeof(NoSuchElementException),
                                                typeof(StaleElementReferenceException));
                    return (element.Enabled && element.Displayed);
                }
            );
        }
    }
}