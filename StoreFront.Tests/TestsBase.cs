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
    public class TestsBase
    {
        #region Fields
        public IWebDriver driver;
        public const string HomePageUrl = "https://www.hangikredi.com";
        public const string DriversBase = "Drivers";
        #endregion

        [TestInitialize]
        public void Initialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            
            driver = new ChromeDriver(DriversBase, options);
        }
    }
}
