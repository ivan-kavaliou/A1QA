using Steps.StringUtils;
using System.Collections.Generic;

namespace CarsPages.Models
{
    public class CarsGarage
    {
        public Dictionary<string, Car> Garage = new Dictionary<string, Car>();

        public void PutCar(string carName, Car newCar)
        {
            Garage.Add(carName, newCar);
        }

        public Car GetCar(string carName)
        {
            return Garage[carName];
        }

        public void RemoveCar(string carName)
        {
            Garage.Remove(carName);
        }

        public void ModifyCarEngine(string carName, string engine)
        {
            Garage[carName].Engine = engine;
        }

        public void ModifyCarTransmission(string carName, string transmission)
        {
            Garage[carName].Transmissions = transmission;
        }

        public string GetCarMaker(string carName)
        {
            return Garage[carName].Maker;
        }

        public string GetCarModel(string carName)
        {
            return Garage[carName].Model;
        }

        public string GetCarYear(string carName)
        {
            return Garage[carName].Year;
        }

        public string GetCarEngine(string carName)
        {
            return Garage[carName].Engine;
        }

        public string GetCarTransmission(string carName)
        {
            return Garage[carName].Transmissions;
        }

        public string GetYearMakerModelToLowerString(string carName)
        {
            return StringUtil.TransformStringToLowerWithoutSpecSymbols(new[]
            { Garage[carName].Year,
                Garage[carName].Maker,
                Garage[carName].Model});
        }
    }
}