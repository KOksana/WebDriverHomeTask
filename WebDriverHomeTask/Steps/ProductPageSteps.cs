using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverHomeTask.Pages;


namespace WebDriverHomeTask.Steps
{
    public class ProductPageSteps
    {
        private IWebDriver _driver;
        private ProductPage _productPage;
        private WebDriverWait _wait;


        public ProductPageSteps(IWebDriver driver)
        {
            _driver = driver;
            _productPage = new ProductPage(_driver);
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
        }

        public string GetProductTitle => _productPage.ProductTitle.Text;

        public string GetProductPrice => _productPage.ProductPrice.Text;

        public void WaitProductPageIsDisplayed()
        {
            _wait.Until(drv => _productPage.ProductTitle.Displayed);
        }
    }
}
