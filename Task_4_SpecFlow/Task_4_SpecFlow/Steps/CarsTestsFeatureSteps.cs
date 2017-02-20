using CarsPages.Models;
using CarsPages.Pages;
using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecRun;

namespace Task_4_SpecFlow
{
    [Binding]
    public class CarsTestsFeatureSteps
    {
        public TestContext TestContext { get; set; }
        public Logger TestLogger { get; set; }
        private MainPage _mainPage;
        private ReviewCarPage _reviewCarPage;
        private CurrentCarPage _newCarPage;
        private CompareCarsPage newCompareCarsPage;
        private static CarsGarage Garage = new CarsGarage();
        private CarToCompare newCarToCompare = new CarToCompare();
        public IWebDriver CurrentBrowser { get; set; }

        [Given(@"User navigate to home page")]
        public void GivenUserNavigateToHomePage()
        {
            _mainPage = new MainPage();
        }

        [When(@"Navigate to Buy and Review a Car")]
        public void WhenNavigateToBuyAndReviewACar()
        {
            _mainPage.OpenReviewPage();
            _reviewCarPage = new ReviewCarPage();
        }

        [When(@"Set random car with name (.*)")]
        public void WhenSetRandomCarWithName(string carName)
        {
            var newRandomCar = _reviewCarPage.GetRandomCar();
            Car newAddCar = new Car(newRandomCar[0], newRandomCar[1], newRandomCar[2]);
            Garage.PutCar(carName, newAddCar);
        }

        [When(@"Click Search button")]
        public void WhenClickSearchButton()
        {
            _reviewCarPage.ClickBtnSearch();
        }

        [When(@"Click Model details link")]
        public void WhenClickModelDetailsLink()
        {
            ConsumerReviews newConsumerReviews = new ConsumerReviews();
            newConsumerReviews.ClickModelDetails();
        }

        [When(@"Click first car in trim car bar with name (.*)")]
        public void WhenClickFirstCarInTrimCarBarWithName(string carName)
        {
            _newCarPage = new CurrentCarPage();
            for (int i = 0; i < 6; i++)
            {
                if (_newCarPage.IsCheckBoxCompareAndTrimsAvailableOnPage())
                {
                    _newCarPage.ClickTrimModification();
                    break;
                }
                if (i.Equals(5))
                {
                    Assert.Fail("There is no valid car was found");
                }
                RebuildCar(carName);
            }
        }

        [When(@"Save Car options with name (.*)")]
        public void WhenSaveCarOptionsWithName(string carName)
        {
            CarSpecPage newCarSpecPage = new CarSpecPage();
            Garage.ModifyCarEngine(carName, newCarSpecPage.GetCarEngine());
            Garage.ModifyCarTransmission(carName, newCarSpecPage.GetTransmission());
        }

        [When(@"Click compare checkbox")]
        public void WhenClickCompareCheckbox()
        {
            newCarToCompare = new CarToCompare();
            newCarToCompare.GoTrimsTab();
            newCarToCompare.ClickCompareCheckbox();
        }

        [When(@"Click Compare now button")]
        public void WhenClickCompareNowButton()
        {
            newCarToCompare.ClickCompareNow();
        }

        [When(@"Add (.*) to compare")]
        public void WhenAddToCompare(string carName)
        {
            AddCarToComparePage addCarToComparePage = new AddCarToComparePage();
            addCarToComparePage.ClickAddAnotherCar();

            AddingAnotherCarPage addingCarPage = new AddingAnotherCarPage();
            addingCarPage.SetCarMake(Garage.GetCarMaker(carName));
            addingCarPage.SetCarModel(Garage.GetCarModel(carName));
            addingCarPage.SetCarYear(Garage.GetCarYear(carName));
            addingCarPage.ClickDoneButton();
        }

        [Then(@"Is  selected cars options are correct")]
        public void ThenIsSelectedCarsOptionsAreCorrect()
        {
            newCompareCarsPage = new CompareCarsPage();
            int countCarOnPage = newCompareCarsPage.CountCarsOnPage();
            Dictionary<int, string> CarNamesOnPage = new Dictionary<int, string>();

            for (int i = 1; i <= countCarOnPage; i++)
            {
                foreach (var tempCar in Garage.Garage)
                {
                    if (tempCar.Value.GetCompareYearMakeModelString().Equals(GetStringAboutCarFromPage(i)))
                    {
                        CarNamesOnPage.Add(i, tempCar.Key);
                    }
                }
            }

            foreach (var tempCarOnPage in CarNamesOnPage)
            {
                SoftAssert.AssertEqual(Garage.GetYearMakerModelToLowerString(tempCarOnPage.Value), newCompareCarsPage.GetYearMakerModel(tempCarOnPage.Key), "Year Maker Model are not equal");
                SoftAssert.AssertEqual(Garage.GetCarEngine(tempCarOnPage.Value), newCompareCarsPage.GetEngineString(tempCarOnPage.Key), "Engine  are not equal");
                SoftAssert.AssertEqual(Garage.GetCarTransmission(tempCarOnPage.Value), newCompareCarsPage.GetTransmissionString(tempCarOnPage.Key), "Transmission are not equal");
            }
        }

        [ScenarioCleanup()]
        public void CleanupAfterOtherTest()
        {
            SoftAssert.AllErrors();
            CurrentBrowser.Quit();
        }

        public void RebuildCar(string carName)
        {
            Garage.RemoveCar(carName);
            WhenNavigateToBuyAndReviewACar();
            WhenSetRandomCarWithName(carName);
            WhenClickSearchButton();
            WhenClickModelDetailsLink();
        }

        public string GetStringAboutCarFromPage(int index)
        {
            return Steps.StringUtils.StringUtil.TransformStringToLowerWithoutSpecSymbols(new[]
            {
                newCompareCarsPage.GetYearMakerModel(index),
            });
        }
    }
}