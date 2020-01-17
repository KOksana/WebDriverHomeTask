using NUnit.Framework;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Tests
{
    public class BaseTestClass
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
