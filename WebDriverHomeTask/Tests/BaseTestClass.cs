using NUnit.Framework;
using OpenQA.Selenium;
using WebDriverHomeTask.Core;

namespace WebDriverHomeTask.Tests
{
    public class BaseTestClass
    {
        protected IWebDriver _driver;
        protected const string URL = "https://www.citrus.ua/";

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = SeleniumDriver.Driver;
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
