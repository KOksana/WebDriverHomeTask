using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverHomeTask.Core
{
    public class SeleniumDriver
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                }
                return _driver;
            }
        }
    }
}
