using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverHomeTask.Core
{
    public static class SeleniumDriver
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver => _driver ?? (_driver = new ChromeDriver());
    }
}
