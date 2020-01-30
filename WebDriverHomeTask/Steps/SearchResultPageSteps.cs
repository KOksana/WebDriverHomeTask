using System.Linq;
using WebDriverHomeTask.Pages;

namespace WebDriverHomeTask.Steps
{
    public class SearchResultPageSteps : BaseSteps
    {
        private SearchResultPage _searchResultPage;

        public SearchResultPageSteps()
        {
            _searchResultPage = new SearchResultPage();
        }

        public string[] GetResultItemTitles
            => _searchResultPage.ItemTitles.Select(i => i.Text).ToArray();

        public string[] GetFilterListForTV()
            => _searchResultPage.FilterListForTV.Select(i => i.Text).ToArray();

        public void NavigateToProduct(int productIndex) {
            _searchResultPage.ItemTitles[productIndex].Click();
        }

        public string GetProductName(int productIndex) 
            =>_searchResultPage.ItemTitles[productIndex].Text;

        public string GetProductPrice(int productIndex)
            => _searchResultPage.ItemPrices[productIndex].Text;

        public void WaitSearchPageIsDisplayed()
        {
            _wait.Until(drv => _searchResultPage.SearchTitle.Displayed);
        }
    }
}
