using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;
using WebDriverHomeTask.Steps;

namespace BddProject.Steps
{
    [Binding]
    public class BDDTestSearchDefinition : BaseSteps
    {
        private static string URL = "https://www.citrus.ua/";

        private readonly BaseSteps _baseSteps;
        private readonly HomePageSteps _homePageSteps;
        private readonly SearchResultPageSteps _searchResultPageSteps;
        private readonly ProductListPageSteps _productListPageSteps;
        private readonly ProductPageSteps _productPageSteps;

        public BDDTestSearchDefinition()
        {
            _baseSteps = new BaseSteps();
            _homePageSteps = new HomePageSteps();
            _searchResultPageSteps = new SearchResultPageSteps();
            _productListPageSteps = new ProductListPageSteps();
            _productPageSteps = new ProductPageSteps();
        }


        [Given("I am on home page")]
        public void GivenIAmOnHomePage()
        {
            _baseSteps.NavigateToUrl(URL);
            _homePageSteps.WaitPageIsDisplayed();
        }
        
        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string searchProduct)
        {
            _homePageSteps.Search(searchProduct);
            _searchResultPageSteps.WaitSearchPageIsDisplayed();
        }

        [When(@"I navigate to first product item")]
        public void WhenINavigateToFirstProductItem()
        {
            var expectedName = _searchResultPageSteps.GetProductName(0);
            var expectedPrice = _searchResultPageSteps.GetProductPrice(0);

            ScenarioContext.Current.Add("product_expectedName", expectedName);
            ScenarioContext.Current.Add("product_expectedPrice", expectedPrice);

            _searchResultPageSteps.NavigateToProduct(0);
            _productPageSteps.WaitProductPageIsDisplayed();
        }

        [When(@"I navigate to catalog '(.*)', subcatalog '(.*)'")]
        public void WhenINavigateToGatalogItem(string catalogItem, string itemSpecific)
        {
            _homePageSteps.NavigateTo(catalogItem, itemSpecific);
            _productListPageSteps.WaitCatalogPageIsDisplayed();
        }

        [Then(@"All results items contain '(.*)' in title")]
        public void ThenAllResultsItemsContainSearchProductInTitle(string searchProduct)
        {
            var resultList = _searchResultPageSteps.GetResultItemTitles;

            Assert.IsTrue(resultList.Length > 0, "No elements in result");
            Assert.IsTrue(resultList.All(i => i.ToLower().Contains(searchProduct)), "Not All contains product name");
        }

        [Then(@"All navigation results items contain '(.*)' in title")]
        public void ThenAllNavigationResultsItemsContainProductNameInTitle(string itemSpecific)
        {
            var resultList = _productListPageSteps.GetResultItemTitles();

            Assert.IsTrue(resultList.Length > 0, "No elements in result");
            Assert.IsTrue(resultList.All(i => i.Contains(itemSpecific)), "Not All contains product name");
        }

        [Then(@"Product info is the same as on search page")]
        public void ThenProductInfoIsTheSameAsOnSearchPage()
        {
            var expectedName = ScenarioContext.Current.Get<string>("product_expectedName");
            var expectedPrice = ScenarioContext.Current.Get<string>("product_expectedPrice");

            var actualName = _productPageSteps.GetProductTitle;
            var actualPrice = _productPageSteps.GetProductPrice;

            Assert.AreEqual(expectedName, actualName, "Product name is different");
            Assert.AreEqual(expectedPrice, actualPrice, "Product price is different");
        }

        [Then(@"I check filter list")]
        public void ThenICheckFilterList()
        {
            var expectedFilterList = new string[] {
                "Смартфоны",
                "Мобильные телефоны",
                "Планшеты",
                "Ноутбуки и ультрабуки",
                "iMac"
            };

            var actualFilterList = _searchResultPageSteps.GetFilterListForTV();

            Assert.AreEqual(expectedFilterList.Length, actualFilterList.Length, "Filter list has different length");
            CollectionAssert.AreEquivalent(expectedFilterList, actualFilterList, "Different filter element name");
        }
    }
}
