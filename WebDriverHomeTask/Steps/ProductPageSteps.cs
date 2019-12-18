using WebDriverHomeTask.Pages;
using static WebDriverHomeTask.Core.CustomWait;

namespace WebDriverHomeTask.Steps
{
    public class ProductPageSteps : BaseSteps
    {
        private readonly ProductPage _productPage;

        public ProductPageSteps()
        {
            _productPage = new ProductPage();
        }

        public string GetProductTitle 
            => _productPage.ProductTitle.Text;

        public string GetProductPrice 
            => _productPage.ProductPrice.Text;

        public void WaitProductPageIsDisplayed() 
            => WaitForElementToBecomeVisibleWithinTimeout(_productPage.ProductTitle);
    }
}
