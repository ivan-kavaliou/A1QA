using Framework;
using PagesSteamPowered.PageModels;
using PagesSteamPowered.Properties;

namespace PagesSteamPowered.Pages
{
    public class SelectGamePage : BasePageSteamPowered
    {
        public Element LblDiscountSelectedGame = new Element(Resources.XPathDiscountSelectedGame, "Label 'Discount of current game'");
        public Element LblPriceSelectedGame = new Element(Resources.XPathPriceSelectedGame, "Label 'Price of current game'");
        public Element BtnDownloadSteam = new Element(Resources.XPathDownloadLink, "Button 'Download steam'");

        public bool IsDiscountAndPriceCorrect()
        {
            LblDiscountSelectedGame.WaitElement();
            LblPriceSelectedGame.WaitElement();

            ActualGame = new Game(LblDiscountSelectedGame.Text(), LblPriceSelectedGame.Text());
            TestLogger.Info(Resources.StrCheckingGameParams);

            if (ExpectedGame.Discount.Equals(ActualGame.Discount) &&
                ExpectedGame.Price.Equals(ActualGame.Price))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DownloadSteam()
        {
            BtnDownloadSteam.Click();
        }
    }
}