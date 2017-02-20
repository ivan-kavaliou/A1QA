using CarsPages.Properties;
using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarsPages.Pages
{
    public class MainPage : CarsBasePage
    {
        public Element LblPageTitle = new Element("//title[contains(text(),\'Cars.com\')]", "Label 'Main page'");


        public MainPage()
        {
            CurrentDriver.Url = PageConfigFile.SiteUrl;
            CurrentDriver.Navigate();
        }


        public void OpenReviewPage()
        {
            TopMenu.ClickElement("Button \'Buy\'");
            SubMenuBuy.ClickElement("Button \'Review a Car\'");
        }
    }
}