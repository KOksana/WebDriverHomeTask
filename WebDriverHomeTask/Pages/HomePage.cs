using OpenQA.Selenium;

namespace WebDriverHomeTask.Pages
{
    public class HomePage
    {
        private IWebDriver _driver;
        
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SearchField => _driver.FindElement(By.Id("search-input"));

        public IWebElement CatalogButton => _driver.FindElement(By.CssSelector(".menu--desktop__title i"));

        public IWebElement CatalogItem(string titleName) => _driver.FindElement(By.CssSelector($"a[title=\'{titleName}\']"));

        public IWebElement CatalogItemSpecific(string titleName) => _driver.FindElement(By.CssSelector($".menu-aim__item-submenu a[title =\'{titleName}\']"));

    }
}
