using Framework;
using PagesSteamPowered.Properties;

namespace PagesSteamPowered.Pages
{
    public class AgeGatePageWithoutSelectDate : BasePageSteamPowered
    {
        public Element BtnContinue;

        public AgeGatePageWithoutSelectDate()
        {
            BtnContinue = new Element(Resources.XPathBtnContinueOnAgeGateApp + LocalDictionary["Continue"] + "')]", "Button 'Continue'");
        }

        public void ContinueBtnClick()
        {
            BtnContinue.Click();
        }
    }
}