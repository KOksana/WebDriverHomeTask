using System.Linq;
using WebDriverHomeTask.Pages;
using static WebDriverHomeTask.Core.CustomWait;

namespace WebDriverHomeTask.Steps
{
    public class ProductListPageSteps : BaseStep
    {
        private readonly ProductListPage _productListPage;

        public ProductListPageSteps()
        {
            _productListPage = new ProductListPage();
        }

        public string[] GetResultItemTitles
            => _productListPage.ItemTitles.Select(i => i.Text).ToArray();

        public void WaitCatalogPageIsDisplayed() 
            => WaitForElementToBecomeVisibleWithinTimeout(_productListPage.CategoryTitle);
    }
}
