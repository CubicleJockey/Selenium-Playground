using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

namespace SeleniumPlayground
{
    [TestClass]
    public class Basic
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new FirefoxDriver(Path.Combine(Directory.GetCurrentDirectory(), "WebDrivers", "64-Bit"));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //Close the browser.
            driver?.Close();
        }

        [TestMethod]
        public void GoToGoogle()
        {
            driver.Url = "http://www.google.com/ncr";
        }
    }
}
