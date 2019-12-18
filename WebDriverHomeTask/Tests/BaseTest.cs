using NUnit.Framework;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Tests
{
    public class BaseTest
    {
        private static string BaseUrl => "https://www.citrus.ua/";

        [OneTimeSetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl(BaseUrl);
            Driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
