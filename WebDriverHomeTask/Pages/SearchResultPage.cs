using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverHomeTask.Pages
{
    public class SearchResultPage
    {
        private IWebDriver _driver;
      //  private const string SEARCH_FIELD_CSS = ".card-product-link a";

        public SearchResultPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement[] ItemTitles => _driver.FindElements(By.CssSelector(".short-itm-desc > .card-product-link")).ToArray();

      //  public IWebElement CategoryTitle => _driver.FindElement(By.ClassName("catalog__main-content"));

        public IWebElement SearchTitle => _driver.FindElement(By.ClassName("result-title"));
    }
}
