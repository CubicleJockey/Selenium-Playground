using System;
using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumPlayground
{
    [TestClass]
    public class BasicsWithChrome
    {
        private const string GOOGLE_URL = "http://google.com/ncr";
        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver(Path.Combine(Directory.GetCurrentDirectory(), "WebDrivers", "32-Bit"));
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

        [TestMethod]
        public void SetGoogleQueryText()
        {
            driver.Url = GOOGLE_URL;

            var input = driver.FindElement(By.XPath("//input[@class='gLFyf gsfi']"));
            input.SendKeys("raspberry pi");

            var searchButton = driver.FindElement(By.Name("btnK"));
            searchButton.Click();

            driver.Title.Should().Be("raspberry pi - Google Search");
        }
    }
}
