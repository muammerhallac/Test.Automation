using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.Tests
{
    public static class Extensions
    {
        public static void ShoultNotBeNull(this IWebElement element)
        {
            Assert.IsNotNull(element);
        }

        public static void ShouldBeDisplayed(this IWebElement element)
        {
            Assert.IsTrue(element.Displayed);
        }
    }
}