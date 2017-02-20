using System.Collections.Generic;

namespace Framework.Models
{
    public class BaseMenu
    {
        public Dictionary<string, Element> MenuElements;

        public BaseMenu()
        {
            MenuElements=new Dictionary<string, Element>();
        }

        public Element SelectElement(string elementName)
        {
            return MenuElements[elementName];
        }

        public void AddElement(Element newElement)
        {
            MenuElements.Add(newElement.ElementName, newElement);
        }

        public void ClickElement(string elementName)
        {
            MenuElements[elementName].JavaScriptClick();
        }


    }
}
