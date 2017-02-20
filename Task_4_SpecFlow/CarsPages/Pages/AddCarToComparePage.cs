using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;

namespace CarsPages.Pages
{
    public class AddCarToComparePage
    {

        private readonly Element _lnkAddAnotherCar = new Element("//div[@id=\"icon-div\"]/*[@name=\"plus-line\"]", "Link 'Add another car'");

        public void ClickAddAnotherCar()
        {
            _lnkAddAnotherCar.Click();
        }

    }
}
