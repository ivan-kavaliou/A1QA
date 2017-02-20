using Framework;
using OpenQA.Selenium;
using PagesSteamPowered.PageModels;
using PagesSteamPowered.Properties;
using System;
using System.Collections.Generic;

namespace PagesSteamPowered.Pages
{
    public class ActionPageSteamPowered : BasePageSteamPowered
    {
        public Element TabDiscounts = new Element(Resources.XPathDiscountsTab, "Link 'Discount tab'");
        private List<Element> listOfDiscounts = new List<Element>();
        private List<Element> listOfPrices = new List<Element>();
        public Element FrmAgeGate, AgeGateApp;
        public By LocFrmAgeGate = By.XPath(Resources.XPathAgeGateBox);
        public By LocAgeGateApp = By.XPath(Resources.XPathAgeGateApp);

        public void GoToDiscountTab()
        {
            TabDiscounts.Click();
            TabDiscounts.WaitElement();
        }

        public void SelectMaxDiscount()
        {
            GoToDiscountTab();

            for (int i = 1; i < 11; i++)
            {
               listOfDiscounts.Add(new Element("//div[@id=\'DiscountsRows\']/a[" + i + "]//div[@class=\'discount_pct\']", "Button 'Game with max piscount'"));
               listOfPrices.Add(new Element("//div[@id=\'DiscountsRows\']/a[" + i + "]//div[@class=\'discount_final_price\']", "Button 'Game with max price'"));
            }

            int maxDiscountIndex = GetMaxSpecialIndex();

            TestLogger.Info(Resources.StrFindMaxPriceGame);
            ExpectedGame = new Game(listOfDiscounts[maxDiscountIndex].Text(),
                                    listOfPrices[maxDiscountIndex].Text());

            listOfPrices[maxDiscountIndex].Click();
        }

        public int GetMaxSpecialIndex()
        {
            int maxSpecialIndex = 0;
            int maxValue = Convert.ToInt32(listOfDiscounts[0].Text().Replace("%", "").Replace("-", ""));
            for (int i = 1; i < 10; i++)
            {
                if (Convert.ToInt32(listOfDiscounts[i].Text().Replace("%", "").Replace("-", "")) > maxValue)
                {
                    maxSpecialIndex = i;
                    maxValue = Convert.ToInt32(listOfDiscounts[i].Text().Replace("%", "").Replace("-", ""));
                }
            }

            return maxSpecialIndex;
        }

        public void CheckAgeGateOnPage()
        {
            if (PageNameElement.TryFindElement(LocFrmAgeGate))
            {
                IsAgeGateAppeared();
            }
            else if (PageNameElement.TryFindElement(LocAgeGateApp))
            {
                IsAgeGateAppAppeared();
            }
            else
            {
                return;
            }
        }

        public void IsAgeGateAppeared()
        {
            if (PageNameElement.TryFindElement(LocFrmAgeGate))
            {
                FrmAgeGate = new Element(LocFrmAgeGate, "Age Gate Box");
                AgeGatePage newAgeGatePage = new AgeGatePage();
                newAgeGatePage.SubmitUserData();
                TestLogger.Info(Resources.StrAgeGateFilds);
            }
        }

        public void IsAgeGateAppAppeared()
        {
            if (PageNameElement.TryFindElement(LocAgeGateApp))
            {
                AgeGateApp = new Element(LocAgeGateApp, "Age Gate App");
                AgeGatePageWithoutSelectDate newAgeGatePageWithoutSelectDate =
                        new AgeGatePageWithoutSelectDate();
                newAgeGatePageWithoutSelectDate.ContinueBtnClick();
                TestLogger.Info(Resources.StrConfirmAgeGate);
            }
        }
    }
}