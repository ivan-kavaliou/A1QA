using System;
using System.Globalization;
using System.Threading;

namespace PagesSteamPowered.PageModels
{
    public class Game
    {
        public int Discount { get; }
        public double Price { get; }

        public Game(string discount, string price)
        {
            Discount = GetInt(discount);

            Price = GetDouble(price);
        }

        public int GetInt(string str)
        {
            int intValue = Convert.ToInt32(str.Replace("%", "").Replace("-", ""));
            return intValue;
        }

        public double GetDouble(string str)
        {
            string temp = str.Replace('$', ' ').Replace(" ", "").Replace("USD", "");
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            double doubleValue = Convert.ToDouble(temp);
            Thread.CurrentThread.CurrentCulture = temp_culture;
            return doubleValue;
        }
    }
}