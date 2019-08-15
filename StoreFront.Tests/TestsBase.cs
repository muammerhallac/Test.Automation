using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.Tests
{
    [TestClass]
    public class TestsBase
    {
        #region Fields
        public IWebDriver driver;
        public const string DriversBase = "Drivers";

        public string HomePageUrl
        {
            get { return "https://www.hangikredi.com"; }
        }
        #endregion

        [TestInitialize]
        public void Initialize()
        {
            var options = new ChromeOptions();
            //options.AddArgument("--headless");

            driver = new ChromeDriver(DriversBase, options);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
