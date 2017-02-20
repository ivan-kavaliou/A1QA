using Framework;
using OpenQA.Selenium;

namespace CarsPages.Pages
{
    public class CompareCarsPage
    {
        public string GetYearMakerModel(int index)
        {
            var carYearMakerModelString = new Element("(//*[@class=\"listing-name\"])[" + index + "]",
            "String 'Year Maker Model'");

            return carYearMakerModelString.Text();
        }

        public string GetEngineString(int index)
        {
            var _carEngineString = new Element("(//*[@header=\'Engine\']//*[@class=\"info-column\"]//span[contains(text(),\'\')])[" + index + "]",
               "String 'Engine");
            return _carEngineString.Text();
        }

        public string GetTransmissionString(int index)
        {
            Element _carTranssmisionString = new Element("(//*[@header=\'Transmission\']//*[@class=\"info-column\"]//span[contains(text(),\'\')])[" + index + "]",
               "String 'Transmissions' ");
            return _carTranssmisionString.Text();
        }

        public int CountCarsOnPage()
        {
            int carCount = 0;
            try
            {
                for (int i = 1; i < 5; i++)
                {
                    if (GetYearMakerModel(i).Length > 0)
                    {
                        carCount++;
                    }
                }
            }
            catch (NoSuchElementException)
            {
                return carCount;
            }
            catch (WebDriverTimeoutException)
            {
                return carCount;
            }
            return carCount;
        }
    }
}