using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsPages.Menus;
using CarsPages.Properties;
using Framework;

namespace CarsPages.Models
{
    public class SubMenuBuy:TopMenu
    {
        public Element BtnRevirwCar = new Element("//*[@class=\"submenu\"]//a[contains(text(),'Review a Car') ]", "Button 'Review a Car'");
        public SubMenuBuy()
        {
            AddElement(BtnRevirwCar);
        }
    }
}
