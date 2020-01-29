using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;
using WebDriverHomeTask.Steps;

namespace BddProject.Steps
{
    [Binding]
    public class BDDTestSearchDefinition : TechTalk.SpecFlow.Steps
    {
        protected const string URL = "https://www.citrus.ua/";

        //private static string searchProductMac = "macbook";
        private static string catalogItem = "Телевизоры, фото, видео";
        private static string itemSpecific = "LG";
        private static string searchProductTv = "TV";

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
           // ScenarioContext.Current.Pending();
        }
        
        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string searchProduct)
        {
            _homePageSteps.Search(searchProduct);

            _searchResultPageSteps.WaitSearchPageIsDisplayed();

          //  ScenarioContext.Current.Pending();
        }
        
        [Then(@"All results items contain '(.*)' in title")]
        public void ThenAllResultsItemsContainSearchProductInTitle(string searchProduct)
        {
            var resultList = _searchResultPageSteps.GetResultItemTitles;

            Assert.IsTrue(resultList.Length > 0, "No elements in result");

            Assert.IsTrue(resultList.All(i => i.ToLower().Contains(searchProduct)), "Not All contains product name");
           // ScenarioContext.Current.Pending();
        }
    }
}
