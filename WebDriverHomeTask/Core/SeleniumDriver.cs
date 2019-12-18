using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverHomeTask.Core
{
    public static class SeleniumDriver
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver => _driver ?? (_driver = new ChromeDriver(Options()));

        private static ChromeOptions Options()
        {
            var options = new ChromeOptions();
            options.AddArgument("--disable-web-security");
            options.AddArgument("--incognito");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--allow-running-insecure-content");
            options.AddArgument("--allow-insecure-localhost");
            return options;
        }
    }
}
