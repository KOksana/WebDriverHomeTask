using OpenQA.Selenium;
using System.Linq;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Pages
{
    public class SearchResultPage : BasePage
    { 
        public IWebElement[] ItemTitles 
            => Driver.FindElements(By.CssSelector(".short-itm-desc > .card-product-link")).ToArray();

        public IWebElement[] ItemPrices 
            => Driver.FindElements(By.ClassName("price-number")).ToArray();

        public IWebElement[] FilterListForTV 
            => Driver.FindElements(By.CssSelector(".filter-itm a")).ToArray();

        public IWebElement SearchTitle 
            => Driver.FindElement(By.ClassName("result-title"));
    }
}
