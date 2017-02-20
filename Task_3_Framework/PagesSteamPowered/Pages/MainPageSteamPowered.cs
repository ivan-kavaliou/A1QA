using Framework;
using PagesSteamPowered.Properties;
using PagesSteamPowered.Pages;

namespace PagesSteamPowered
{
    public class MainPageSteamPowered :BasePageSteamPowered
    {
       
        
       public void SelectActionGame()
        {
            BtnTypeOfGame.Click();
            BtnActionGame = new Element(Resources.XPathActionBtn + LocalDictionary["Action"] + "')]", "Button 'Action games'");
            BtnActionGame.Click();
        }

       
        
    }
}