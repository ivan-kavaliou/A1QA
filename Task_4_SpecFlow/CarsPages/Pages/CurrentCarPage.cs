using Framework;

namespace CarsPages.Pages
{
    public class CurrentCarPage
    {
        private readonly Element _chbCompare = new Element("//*[@id=\"checkbox-trim-\"][contains(text(),\'Compare\')]",
            "CheckBox 'Compare'");

        private readonly Element _lblTrimsAvailable = new Element("//*[contains(text(),\'Trims Available\')]",
            "Label 'Trims available");

        private readonly Element _trimsViewDetails = new Element("//div[@class=\"trim_listing__footer\"]//a[contains(text(),\'View Details\')]", "Link 'View Details'");

        public bool IsCheckBoxCompareAndTrimsAvailableOnPage()
        {
            
            if (_chbCompare.TryFindElement(_chbCompare.Locator) &&
                _lblTrimsAvailable.TryFindElement(_lblTrimsAvailable.Locator))
            {
                return true;
            }
            return false;
        }

        public void ClickTrimModification()
        {
            _trimsViewDetails.JavaScriptClick();
        }
    }
}