using Steps.StringUtils;

namespace CarsPages.Models
{
    public class Car
    {
        public string Maker { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Engine { get; set; }
        public string Transmissions { get; set; }

        public Car(string maker, string model, string year)
        {
            Maker = maker;
            Model = model;
            Year = year;
        }

        public string GetCompareYearMakeModelString()
        {
            return StringUtil.TransformStringToLowerWithoutSpecSymbols(new[] {Year, Maker, Model});
        }

    }
}