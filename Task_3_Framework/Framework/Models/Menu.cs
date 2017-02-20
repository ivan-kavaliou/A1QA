using System.Collections.Generic;

namespace Framework
{
    public class Menu
    {
        public Dictionary<string, Element> MenuElements;

        public Menu()
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


    }
}
