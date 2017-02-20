using Framework;

namespace CarsPages.Pages
{
    public class CarSpecPage : CarsBasePage
    {
        private readonly Element _lblEngine = new Element("//*[@id=\"engine\"]", "Label 'Engine'");
        private readonly Element _lblTransmission = new Element(" //*[@id=\"transmission\"]", "Label 'Transmission'");

        public string GetCarEngine()
        {
            return _lblEngine.Text();
        }

        public string GetTransmission()
        {
            return _lblTransmission.Text();
        }
    }
}