using OpenQA.Selenium;
using System.Linq;
using WebDriverHomeTask.Pages;

namespace WebDriverHomeTask.Steps
{
    public class ProductListPageSteps : BaseSteps
    {
        private ProductListPage _productListPage;


        public ProductListPageSteps(IWebDriver driver) : base(driver)
        {
            _productListPage = new ProductListPage(driver);
        }

        public string[] GetResultItemTitles
            => _productListPage.ItemTitles.Select(i => i.Text).ToArray();

        public void WaitCatalogPageIsDisplayed()
        {
            _wait.Until(drv => _productListPage.CategoryTitle.Displayed);
        }
    }
}
