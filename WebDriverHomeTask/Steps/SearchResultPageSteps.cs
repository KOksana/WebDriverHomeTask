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

        public string[] GetResultItemTitles()
        {
            return _searchResultPage.ItemTitles.Select(i => i.Text).ToArray();
        }
        public void WaitCatalogPageIsDisplayed()
        {
            _wait.Until(drv => _searchResultPage.CategoryTitle.Displayed);
        }

        public void WaitSearchPageIsDisplayed()
        {
            _wait.Until(drv => _searchResultPage.SearchTitle.Displayed);
        }
    }
}
