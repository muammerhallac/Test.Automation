using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.Tests.Pages
{
    [TestClass]
    public class PersonalFinanceCreditPageTests : TestsBase
    {
        #region Fields
        public string PersonalFinanceCreditPageUrl
        {
            get { return string.Format("{0}/{1}", HomePageUrl, "kredi/ihtiyac-kredisi"); }
        }
        #endregion

        [TestMethod]
        public void Can_Navigate_To_Personal_Finance_Credit_Page()
        {
            driver.Navigate().GoToUrl(PersonalFinanceCreditPageUrl);
            var calculationForm = driver.FindElement(By.Id("hk-search-form"));

            calculationForm.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Display_Credit_Of_Month()
        {
            driver.Navigate().GoToUrl(PersonalFinanceCreditPageUrl);
            var creditOfMonthContainer = driver.FindElement(By.Id("monthly-credit-panel"));

            creditOfMonthContainer.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Display_Suggested_Personal_Finance_Credits()
        {
            driver.Navigate().GoToUrl(PersonalFinanceCreditPageUrl);
            var suggestedCreditsContainer = driver.FindElement(By.Id("tavsiyeKr"));

            suggestedCreditsContainer.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Display_Personal_Finance_Credits_Interest_Rates()
        {
            driver.Navigate().GoToUrl(PersonalFinanceCreditPageUrl);
            var popularCreditsContainer = driver.FindElement(By.ClassName("faizOraniTablosu"));

            popularCreditsContainer.ShouldBeDisplayed();
        }
    }
}
