using Framework;

namespace CarsPages.Pages
{
    public class AddingAnotherCarPage
    {
        private readonly Element _selCarMake = new Element("//*[@id=\"make-dropdown\"]", "Select 'Car maker'");
        private readonly Element _selCarModel = new Element("//*[@id=\"model-dropdown\"]", "Select 'Car model'");
        private readonly Element _selCarYear = new Element("//*[@id=\"year-dropdown\"]", "Select 'Car year'");
        private readonly Element _btnDone = new Element("//button[contains(text(),\'Done\')]", "Button 'Done'");

        public void SetCarMake(string carMake)
        {
            var makeSelect = _selCarMake.GetSelectElement();
            makeSelect.SelectByText(carMake);
        }

        public void SetCarModel(string carModel)
        {
            var modelSelect = _selCarModel.GetSelectElement();
            modelSelect.SelectByText(carModel);
        }

        public void SetCarYear(string carYear)
        {
            var yearSelect = _selCarYear.GetSelectElement();
            yearSelect.SelectByText(carYear);
        }

        public void ClickDoneButton()
        {
            _btnDone.Click();
        }

    }
}