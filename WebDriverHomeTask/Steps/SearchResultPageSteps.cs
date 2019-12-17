using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using WebDriverHomeTask.Pages;

namespace WebDriverHomeTask.Steps
{
    class SearchResultPageSteps
    {
        private IWebDriver _driver;
        private SearchResultPage _searchResultPage;
        private WebDriverWait _wait;


        public SearchResultPageSteps(IWebDriver driver)
        {
            _driver = driver;
            _searchResultPage = new SearchResultPage(_driver);
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
        }

        public string[] GetResultItemTitles
            => _searchResultPage.ItemTitles.Select(i => i.Text).ToArray();

        public string[] GetFilterListForTV
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
