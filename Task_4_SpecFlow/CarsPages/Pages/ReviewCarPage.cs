using Framework;
using System;

namespace CarsPages.Pages
{
    public class ReviewCarPage : CarsBasePage
    {
        private readonly Element _selCarMake = new Element("//*[@name=\"makeDropDown\"]", "Select 'Car maker'");
        private readonly Element _selCarModel = new Element("//*[@name=\"modelDropDown\"]", "Select 'Car model'");
        private readonly Element _selCarYear = new Element("//*[@name=\"yearDropDown\"]", "Select 'Car year'");
        private readonly Element _btnSearch = new Element("//*[contains(text(),\'Search\')]", "Button 'Search'");

        private readonly Element _lnkModelDetails = new Element("//a[contains(text(),'Model details')]",
            "Link 'Model Details");

        public string GetRandomMake()
        {
            return SetRandomValue(_selCarMake, "//*[@name=\"makeDropDown\"]/*[", "Link 'Random maker'");
        }

        public string GetRandomModel()
        {
            return SetRandomValue(_selCarModel, "//*[@name=\"modelDropDown\"]/*[", "Link 'Random model'");
        }

        public string GetRandomYear()
        {
            return SetRandomValue(_selCarYear, "//*[@name=\"yearDropDown\"]/*[", "Link 'Random year'");
        }

        private string SetRandomValue(Element el, string selectXPath, string elementName)
        {
            var newSelect = el.GetSelectElement();
            if (newSelect.Options.Count > 1)
            {
                int randomChoice = new Random().Next(1, newSelect.Options.Count);
                newSelect.SelectByIndex(randomChoice);
                Element randomElement = new Element(selectXPath + (randomChoice + 1) + "]", elementName);
                string resaultValue = randomElement.Text();
                return resaultValue;
            }
            return string.Empty;
        }

        public void ClickBtnSearch()
        {
            _btnSearch.Click();
        }

        public string[] GetRandomCar()
        {
            string randomMake = string.Empty;
            string randomModel = string.Empty;
            string randomYear = string.Empty;

            for (int i = 0; i < 5; i++)
            {
                randomMake = GetRandomMake();
                randomModel = GetRandomModel();
                randomYear = GetRandomYear();

                if (string.IsNullOrEmpty(randomMake) ||
                    string.IsNullOrEmpty(randomModel) ||
                    string.IsNullOrEmpty(randomYear))
                {
                }
                else
                {
                    break;
                }
            }

            return new[] { randomMake, randomModel, randomYear };
        }
    }
}