using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace SeleniumPlayground
{
    [TestClass]
    public class BasicWithFireFox
    {
        private const string GOOGLE_URL = "http://google.com/ncr";
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
            driver.Url = GOOGLE_URL;
        }

        [TestMethod]
        public void CheckGoogleTitle()
        {
            driver.Url = GOOGLE_URL;
            driver.Title.Should().Be("Google");
        }

        [TestMethod]
        public void GetGooglePageContent()
        {
            driver.Url = GOOGLE_URL;
            var content = driver.PageSource;

            content.Should().NotBeNullOrWhiteSpace();
            content.Should().Contain("<body jsmodel=\" \" class=\"hp vasq big\" id=\"gsr\">");
            content.Should().Contain("</body>");
            
            Console.WriteLine(content);
        }
    }
}