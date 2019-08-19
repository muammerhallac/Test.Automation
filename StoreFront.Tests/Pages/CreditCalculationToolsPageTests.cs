using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.Tests.Pages
{
    [TestClass]
    public class CreditCalculationToolsPageTests : TestsBase
    {
        #region Fields
        public string CreditCalculationToolsPageUrl { get { return string.Format("{0}/{1}", HomePageUrl, "kredi/hesaplama-araclari"); } }
        #endregion

        [TestMethod]
        public void Can_Navigate_To_Credit_Calculation_Tools_Page()
        {
            driver.Navigate().GoToUrl(CreditCalculationToolsPageUrl);
            var popularCreditsContainer = driver.FindElement(By.ClassName("krediForm"));

            popularCreditsContainer.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Calculate_Personal_Finance_Credit()
        {
            driver.Navigate().GoToUrl(CreditCalculationToolsPageUrl);
            var creditTab = driver.FindElement(By.ClassName("bankaKredi"));
            creditTab.Click();

            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript(@"$('.krediTuruHs').find('.hk-select.form-control').attr('class', 'hk-select form-control hk-active')");
            var creditType = driver.FindElement(By.XPath("//li[@data-value='1']"));
            creditType.Click();

            var amountTextBox = driver.FindElement(By.Id("Tutar"));
            amountTextBox.Click();
            amountTextBox.SendKeys("25000");

            javaScriptExecutor.ExecuteScript(@"$('.krediVadeHs').find('.hk-select.form-control').attr('class', 'hk-select form-control hk-active')");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var expirationBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//li[@data-value='3']")));
            expirationBox.Click();

            var showBidsButton = driver.FindElement(By.Id("krediHesapla"));
            showBidsButton.Click();

            driver.SwitchTo().ActiveElement();
            var navigatedPageHeaderTitle = driver.FindElement(By.Id("divHeaderTitle"));

            navigatedPageHeaderTitle.ShouldBeDisplayed();
        }
    }
}
