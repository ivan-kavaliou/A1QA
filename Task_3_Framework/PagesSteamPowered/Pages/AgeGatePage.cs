using Framework;
using PagesSteamPowered.Properties;

namespace PagesSteamPowered.Pages
{
    public class AgeGatePage : BasePageSteamPowered
    {
        public Element SlcAgeDay = new Element(Resources.XPathAgeDay, "Select 'Age Day'");
        public Element SlcAgeMonth = new Element(Resources.XPathAgeMonth, "Select 'Age Month'");
        public Element SlcAgeYear = new Element(Resources.XPathAgeYear, "Select 'Age Year'");
        public Element BtnSubmitAge = new Element(Resources.XPathSubmitAgeButton, "Button 'Submit Age'");

        public void SubmitUserData()
        {
            SlcAgeDay.SelectByValue(PageConfigFile.AgeDay);
            SlcAgeMonth.SelectByValue(PageConfigFile.AgeMonth);
            SlcAgeYear.SelectByValue(PageConfigFile.AgeYear);
            BtnSubmitAge.Click();
        }
    }
}