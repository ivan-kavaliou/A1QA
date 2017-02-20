using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;

namespace CarsPages.Pages
{
    public class CarToCompare
    {

        private readonly Element _tabTrims = new Element(
            "//*[@id=\"mmyt-sub-headline\"]//a[contains(text(),\'Trims\')]", "Tab 'Trims'");

        private readonly Element _chbCompare = new Element("//*[@id=\"checkbox-trim-\"][contains(text(),\'Compare\')]",
            "CheckBox 'Compare'");

        private readonly Element _btnComparenow = new Element("//*[@class=\"cui-button\"][contains(text(),\'Compare Now\')]",
            "Button 'Compare Now'");

        public void GoTrimsTab()
        {
            _tabTrims.Click();
        }

        public void ClickCompareCheckbox()
        {
            _chbCompare.JavaScriptClick();
        }

        public void ClickCompareNow()
        {
            _btnComparenow.Click();
        }


    }
}
