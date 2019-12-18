using OpenQA.Selenium;
using WebDriverHomeTask.Pages;

namespace WebDriverHomeTask.Steps
{
    public class ProductPageSteps : BaseSteps
    {
        private ProductPage _productPage;

        public ProductPageSteps(IWebDriver driver) : base(driver)
        {
            _productPage = new ProductPage(driver);
        }

        public string GetProductTitle => _productPage.ProductTitle.Text;

        public string GetProductPrice => _productPage.ProductPrice.Text;

        public void WaitProductPageIsDisplayed()
        {
            _wait.Until(drv => _productPage.ProductTitle.Displayed);
        }
    }
}
