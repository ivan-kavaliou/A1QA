using Framework;
using Framework.Models;

namespace CarsPages.Menus
{
    public class TopMenu:BaseMenu
    {
        public Element BtnBuyElement = new Element("//*[@class=\"navbar-item-label\"][contains(text(),\'Buy\') ]", "Button \'Buy\'");


        public TopMenu()
        {
            AddElement(BtnBuyElement);
        }
        
    }

}
