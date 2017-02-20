using Framework;

namespace CarsPages.Pages
{
    public class ConsumerReviews:CarsBasePage
    {
        private Element _lnkModelDetails = new Element("//a[contains(text(),\'Model details\')]", "Link 'Model details'");

        public void ClickModelDetails()
        {
            _lnkModelDetails.Click();
        }

    }
}
