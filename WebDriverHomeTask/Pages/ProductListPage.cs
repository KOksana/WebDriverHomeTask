using OpenQA.Selenium;
using System.Linq;

namespace WebDriverHomeTask.Pages
{
    public class ProductListPage
    {
        private IWebDriver _driver;

        public ProductListPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement[] ItemTitles => _driver.FindElements(By.CssSelector(".product-card__name a")).ToArray();

        public IWebElement CategoryTitle => _driver.FindElement(By.ClassName("catalog__main-content"));
    }
}
