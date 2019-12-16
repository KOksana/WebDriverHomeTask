using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

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

       // public IWebElement SearchTitle => _driver.FindElement(By.ClassName("result-title"));

    }
}
