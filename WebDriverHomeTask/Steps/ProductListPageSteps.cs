using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverHomeTask.Pages;
using OpenQA.Selenium.Support.UI;

namespace WebDriverHomeTask.Steps
{
    public class ProductListPageSteps
    {
        private IWebDriver _driver;
        private ProductListPage _productListPage;
        private WebDriverWait _wait;


        public ProductListPageSteps(IWebDriver driver)
        {
            _driver = driver;
            _productListPage = new ProductListPage(_driver);
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
        }

        public string[] GetResultItemTitles()
        {
            return _productListPage.ItemTitles.Select(i => i.Text).ToArray();
        }
        public IWebElement GetResultFirstItem()
        {
            return _productListPage.ItemTitles[0];
        }
        public void WaitCatalogPageIsDisplayed()
        {
            _wait.Until(drv => _productListPage.CategoryTitle.Displayed);
        }
    }
}
