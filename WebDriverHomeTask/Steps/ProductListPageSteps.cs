using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using WebDriverHomeTask.Pages;

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

        public string[] GetResultItemTitles
            => _productListPage.ItemTitles.Select(i => i.Text).ToArray();

        public void WaitCatalogPageIsDisplayed()
        {
            _wait.Until(drv => _productListPage.CategoryTitle.Displayed);
        }
    }
}
