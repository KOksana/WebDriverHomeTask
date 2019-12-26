using WebDriverHomeTask.Pages;

namespace WebDriverHomeTask.Steps
{
    public class ProductPageSteps : BaseSteps
    {
        private ProductPage _productPage;

        public ProductPageSteps()
        {
            _productPage = new ProductPage();
        }

        public string GetProductTitle => _productPage.ProductTitle.Text;

        public string GetProductPrice => _productPage.ProductPrice.Text;

        public void WaitProductPageIsDisplayed()
        {
            _wait.Until(drv => _productPage.ProductTitle.Displayed);
        }
    }
}
