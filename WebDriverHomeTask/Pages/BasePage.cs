using OpenQA.Selenium;

namespace WebDriverHomeTask.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
