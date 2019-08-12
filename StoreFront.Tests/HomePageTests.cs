using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace StoreFront.Tests
{
    [TestClass]
    public class HomePageTests
    {
        #region Fields
        IWebDriver chromeDriver;
        const string HomePageUrl = "https://www.hangikredi.com";
        #endregion

        [TestInitialize]
        public void Initialize()
        {
            chromeDriver = new OpenQA.Selenium.Chrome.ChromeDriver("Drivers");
        }

        [TestMethod]
        public void Can_Navigate_To_Main_Page()
        {
            chromeDriver.Navigate().GoToUrl(HomePageUrl);
            IWebElement logo = chromeDriver.FindElement(By.ClassName("home-logo"));
            Assert.IsNotNull(logo);
        }

        [TestMethod]
        public void Can_Display_Credit_Tab()
        {
            chromeDriver.Navigate().GoToUrl(HomePageUrl);
            var creditTab = chromeDriver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[0];
            creditTab.Click();
            var showBidsButton = chromeDriver.FindElement(By.Id("teklif-goster"));

            Assert.IsNotNull(creditTab);
            Assert.IsNotNull(showBidsButton);
            Assert.IsTrue(showBidsButton.Displayed);
        }

        [TestMethod]
        public void Can_Display_Insurance_Tab()
        {
            chromeDriver.Navigate().GoToUrl(HomePageUrl);

            var insuranceTab = chromeDriver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[2];
            insuranceTab.Click();

            var insuranceRedirectButton = chromeDriver.FindElement(By.LinkText("Kasko Teklifleri"));
            var trafficInsuranceRedirectButton = chromeDriver.FindElement(By.LinkText("Trafik Sigortası Teklifleri"));
            var healthInsuranceRedirectButton = chromeDriver.FindElement(By.LinkText("Sağlık Sigortası Teklifleri"));

            Assert.IsNotNull(insuranceTab);
            Assert.IsNotNull(insuranceRedirectButton);
            Assert.IsNotNull(trafficInsuranceRedirectButton);
            Assert.IsNotNull(healthInsuranceRedirectButton);

            Assert.IsTrue(insuranceRedirectButton.Displayed);
            Assert.IsTrue(trafficInsuranceRedirectButton.Displayed);
            Assert.IsTrue(healthInsuranceRedirectButton.Displayed);
        }

        [TestMethod]
        public void Can_Display_Deposit_Tab()
        {
            chromeDriver.Navigate().GoToUrl(HomePageUrl);

            var depositTab = chromeDriver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[3];
            depositTab.Click();

            var depositCalculationRedirectButton = chromeDriver.FindElement(By.LinkText("Mevduat Hesaplama"));
            var currencyRedirectButton = chromeDriver.FindElement(By.LinkText("Döviz"));
            var goldRedirectButton = chromeDriver.FindElement(By.LinkText("Altın"));

            Assert.IsNotNull(depositTab);
            Assert.IsNotNull(depositCalculationRedirectButton);
            Assert.IsNotNull(currencyRedirectButton);
            Assert.IsNotNull(goldRedirectButton);

            Assert.IsTrue(depositCalculationRedirectButton.Displayed);
            Assert.IsTrue(currencyRedirectButton.Displayed);
            Assert.IsTrue(goldRedirectButton.Displayed);
        }

        [TestMethod]
        public void Can_Display_Internet_Tab()
        {
            chromeDriver.Navigate().GoToUrl(HomePageUrl);

            var internetTab = chromeDriver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[4];
            internetTab.Click();

            var leanInternetRedirectButton = chromeDriver.FindElement(By.LinkText("Yalın İnternet"));
            var phonePlusInternetRedirectButton = chromeDriver.FindElement(By.LinkText("Telefon + İnternet"));
            var tvPlusInternetRedirectButton = chromeDriver.FindElement(By.LinkText("Tv + İnternet"));
            var triplePackageRedirectButton = chromeDriver.FindElement(By.LinkText("3’lü Paket"));
            var allInternetPackagesRedirectButton = chromeDriver.FindElement(By.LinkText("Tüm İnternet Paketlerini Gör"));

            Assert.IsNotNull(internetTab);
            Assert.IsNotNull(leanInternetRedirectButton);
            Assert.IsNotNull(phonePlusInternetRedirectButton);
            Assert.IsNotNull(tvPlusInternetRedirectButton);
            Assert.IsNotNull(triplePackageRedirectButton);
            Assert.IsNotNull(allInternetPackagesRedirectButton);

            Assert.IsTrue(leanInternetRedirectButton.Displayed);
            Assert.IsTrue(phonePlusInternetRedirectButton.Displayed);
            Assert.IsTrue(tvPlusInternetRedirectButton.Displayed);
            Assert.IsTrue(triplePackageRedirectButton.Displayed);
            Assert.IsTrue(allInternetPackagesRedirectButton.Displayed);
        }

        [TestMethod]
        public void Can_Calculate_Personal_Finance_Credit()
        {
            chromeDriver.Navigate().GoToUrl(HomePageUrl);
            var creditTab = chromeDriver.FindElement(By.ClassName("tab-selectors")).FindElements(By.TagName("li"))[0];
            creditTab.Click();

            var personalFinanceCreditLabel = chromeDriver.FindElement(By.XPath("//label[@for='ihtiyacRadio']"));
            personalFinanceCreditLabel.Click();

            var amountTextBox = chromeDriver.FindElement(By.Id("Tutar"));
            amountTextBox.Click();
            amountTextBox.SendKeys("10000");

            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)chromeDriver;
            javaScriptExecutor.ExecuteScript(@"$('.hk-select.form-control').attr('class', 'hk-select form-control hk-active')");
            var expirationBox = chromeDriver.FindElement(By.XPath("//li[@data-value='12']"));
            expirationBox.Click();
            
            var showBidsButton = chromeDriver.FindElement(By.Id("teklif-goster"));
            showBidsButton.Click();

            var navigatedPageHeaderTitle = chromeDriver.FindElement(By.Id("divHeaderTitle"));

            Assert.IsNotNull(navigatedPageHeaderTitle);
        }

        [TestCleanup]
        public void Cleanup()
        {
            chromeDriver.Close();
            chromeDriver.Dispose();
        }
    }
}
