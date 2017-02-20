using System;

namespace Framework
{
    public class ConfigFile
    {
        public string BrowserName { get; set; }
        public string SiteUrl { get; set; }
        public string LocationLang { get; set; }
        public string AgeDay { get; set; }
        public string AgeMonth { get; set; }
        public string AgeYear { get; set; }

        public override string ToString()
        {
            return String.Format(
                "Browser name: " + BrowserName +
                "\t\tURL: " + SiteUrl +
                "\t\tLocation Language: " + LocationLang);
        }
    }
}