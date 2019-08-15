using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace StoreFront.Tests
{
    [TestClass]
    public class HomePageTests : TestsBase
    {
        [TestMethod]
        public void Can_Navigate_To_Main_Page()
        {
            driver.Navigate().GoToUrl(HomePageUrl);
            IWebElement logo = driver.FindElement(By.ClassName("home-logo"));
            logo.ShoultNotBeNull();
        }

        [TestMethod]
        public void Can_Display_Credit_Tab()
        {
            driver.Navigate().GoToUrl(HomePageUrl);
            var creditTab = driver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[0];
            creditTab.Click();
            var showBidsButton = driver.FindElement(By.Id("teklif-goster"));

            creditTab.ShoultNotBeNull();
            showBidsButton.ShoultNotBeNull();
            showBidsButton.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Display_Credit_Card_Tab()
        {
            driver.Navigate().GoToUrl(HomePageUrl);

            var creditCardTab = driver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[1];
            creditCardTab.Click();

            var creditCardPageListingButton = driver.FindElement(By.Id("listButton"));

            creditCardPageListingButton.ShoultNotBeNull();
            creditCardPageListingButton.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Display_Insurance_Tab()
        {
            driver.Navigate().GoToUrl(HomePageUrl);

            var insuranceTab = driver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[2];
            insuranceTab.Click();

            var insuranceRedirectButton = driver.FindElement(By.LinkText("Kasko Teklifleri"));
            var trafficInsuranceRedirectButton = driver.FindElement(By.LinkText("Trafik Sigortası Teklifleri"));
            var healthInsuranceRedirectButton = driver.FindElement(By.LinkText("Sağlık Sigortası Teklifleri"));

            insuranceTab.ShoultNotBeNull();
            insuranceRedirectButton.ShoultNotBeNull();
            trafficInsuranceRedirectButton.ShoultNotBeNull();
            healthInsuranceRedirectButton.ShoultNotBeNull();

            insuranceRedirectButton.ShouldBeDisplayed();
            trafficInsuranceRedirectButton.ShouldBeDisplayed();
            healthInsuranceRedirectButton.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Display_Deposit_Tab()
        {
            driver.Navigate().GoToUrl(HomePageUrl);

            var depositTab = driver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[3];
            depositTab.Click();

            var depositCalculationRedirectButton = driver.FindElement(By.LinkText("Mevduat Hesaplama"));
            var currencyRedirectButton = driver.FindElement(By.LinkText("Döviz"));
            var goldRedirectButton = driver.FindElement(By.LinkText("Altın"));

            depositTab.ShoultNotBeNull();
            depositCalculationRedirectButton.ShoultNotBeNull();
            currencyRedirectButton.ShoultNotBeNull();
            goldRedirectButton.ShoultNotBeNull();

            depositCalculationRedirectButton.ShouldBeDisplayed();
            currencyRedirectButton.ShouldBeDisplayed();
            goldRedirectButton.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Display_Internet_Tab()
        {
            driver.Navigate().GoToUrl(HomePageUrl);

            var internetTab = driver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[4];
            internetTab.Click();

            var leanInternetRedirectButton = driver.FindElement(By.LinkText("Yalın İnternet"));
            var phonePlusInternetRedirectButton = driver.FindElement(By.LinkText("Telefon + İnternet"));
            var tvPlusInternetRedirectButton = driver.FindElement(By.LinkText("Tv + İnternet"));
            var triplePackageRedirectButton = driver.FindElement(By.LinkText("3’lü Paket"));
            var allInternetPackagesRedirectButton = driver.FindElement(By.LinkText("Tüm İnternet Paketlerini Gör"));

            internetTab.ShoultNotBeNull();
            leanInternetRedirectButton.ShoultNotBeNull();
            phonePlusInternetRedirectButton.ShoultNotBeNull();
            tvPlusInternetRedirectButton.ShoultNotBeNull();
            triplePackageRedirectButton.ShoultNotBeNull();
            allInternetPackagesRedirectButton.ShoultNotBeNull();

            leanInternetRedirectButton.ShouldBeDisplayed();
            phonePlusInternetRedirectButton.ShouldBeDisplayed();
            tvPlusInternetRedirectButton.ShouldBeDisplayed();
            triplePackageRedirectButton.ShouldBeDisplayed();
            allInternetPackagesRedirectButton.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Calculate_Personal_Finance_Credit()
        {
            driver.Navigate().GoToUrl(HomePageUrl);
            var creditTab = driver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[0];
            creditTab.Click();

            var personalFinanceCreditLabel = driver.FindElement(By.XPath("//label[@for='ihtiyacRadio']"));
            personalFinanceCreditLabel.Click();

            var amountTextBox = driver.FindElement(By.Id("Tutar"));
            amountTextBox.Click();
            amountTextBox.SendKeys("10000");

            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript(@"$('.hk-select.form-control').attr('class', 'hk-select form-control hk-active')");
            var expirationBox = driver.FindElement(By.XPath("//li[@data-value='12']"));
            expirationBox.Click();
            
            var showBidsButton = driver.FindElement(By.Id("teklif-goster"));
            showBidsButton.Click();

            var navigatedPageHeaderTitle = driver.FindElement(By.Id("divHeaderTitle"));

            navigatedPageHeaderTitle.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Calculate_Mortgage_Loan()
        {
            driver.Navigate().GoToUrl(HomePageUrl);
            var creditTab = driver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[0];
            creditTab.Click();

            var housingCreditLabel = driver.FindElement(By.XPath("//label[@for='konutRadio']"));
            housingCreditLabel.Click();

            var amountTextBox = driver.FindElement(By.Id("Tutar"));
            amountTextBox.Click();
            amountTextBox.SendKeys("100000");

            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript(@"$('.hk-select.form-control').attr('class', 'hk-select form-control hk-active')");
            var expirationBox = driver.FindElement(By.XPath("//li[@data-value='60']"));
            expirationBox.Click();

            var showBidsButton = driver.FindElement(By.Id("teklif-goster"));
            showBidsButton.Click();

            driver.SwitchTo().ActiveElement();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var modalElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("redirect")));
            modalElement.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.SwitchTo().ActiveElement();
            var navigatedPageHeaderTitle = driver.FindElement(By.Id("housingHeader"));

            navigatedPageHeaderTitle.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Calculate_Transport_Credit()
        {
            driver.Navigate().GoToUrl(HomePageUrl);
            var creditTab = driver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[0];
            creditTab.Click();

            var housingCreditLabel = driver.FindElement(By.XPath("//label[@for='tasitRadio']"));
            housingCreditLabel.Click();

            var amountTextBox = driver.FindElement(By.Id("Tutar"));
            amountTextBox.Click();
            amountTextBox.SendKeys("50000");

            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript(@"$('.hk-select.form-control').attr('class', 'hk-select form-control hk-active')");
            var expirationBox = driver.FindElement(By.XPath("//li[@data-value='24']"));
            expirationBox.Click();

            var showBidsButton = driver.FindElement(By.Id("teklif-goster"));
            showBidsButton.Click();

            driver.SwitchTo().ActiveElement();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var modalElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("redirect")));
            modalElement.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.SwitchTo().ActiveElement();
            var navigatedPageHeaderTitle = driver.FindElement(By.Id("divHeaderTitle"));

            navigatedPageHeaderTitle.ShouldBeDisplayed();
        }

        [TestMethod]
        public void Can_Calculate_SME_Loan()
        {
            driver.Navigate().GoToUrl(HomePageUrl);
            var creditTab = driver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[0];
            creditTab.Click();

            var housingCreditLabel = driver.FindElement(By.XPath("//label[@for='kobiRadio']"));
            housingCreditLabel.Click();

            var amountTextBox = driver.FindElement(By.Id("Tutar"));
            amountTextBox.Click();
            amountTextBox.SendKeys("250000");

            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript(@"$('.hk-select.form-control').attr('class', 'hk-select form-control hk-active')");
            var expirationBox = driver.FindElement(By.XPath("//li[@data-value='60']"));
            expirationBox.Click();

            var showBidsButton = driver.FindElement(By.Id("teklif-goster"));
            showBidsButton.Click();
            
            var navigatedPageHeaderTitle = driver.FindElement(By.Id("divHeaderTitle"));
            
            navigatedPageHeaderTitle.ShouldBeDisplayed();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
