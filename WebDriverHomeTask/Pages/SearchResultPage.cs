using OpenQA.Selenium;
using System.Linq;

namespace WebDriverHomeTask.Pages
{
    public class SearchResultPage
    {
        private IWebDriver _driver;

        public SearchResultPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement[] ItemTitles => _driver.FindElements(By.CssSelector(".short-itm-desc > .card-product-link")).ToArray();

        public IWebElement[] ItemPrices => _driver.FindElements(By.ClassName("price-number")).ToArray();

        public IWebElement[] FilterListForTV => _driver.FindElements(By.CssSelector(".filter-itm a")).ToArray();

        public IWebElement SearchTitle => _driver.FindElement(By.ClassName("result-title"));
    }
}
