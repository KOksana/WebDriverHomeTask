using NUnit.Framework;
using System.Linq;
using WebDriverHomeTask.Steps;

namespace WebDriverHomeTask.Tests
{
    public class TestClass : BaseTestClass
    {
        protected const string URL = "https://www.citrus.ua/";

        private static string searchProductMac = "macbook";
        private static string catalogItem = "Телевизоры, фото, видео";
        private static string itemSpecific = "LG";
        private static string searchProductTv = "TV";

        private readonly BaseSteps _baseSteps;
        private readonly HomePageSteps _homePageSteps;
        private readonly SearchResultPageSteps _searchResultPageSteps;
        private readonly ProductListPageSteps _productListPageSteps;
        private readonly ProductPageSteps _productPageSteps;

        public TestClass()
        {
            _baseSteps = new BaseSteps();
            _homePageSteps = new HomePageSteps();
            _searchResultPageSteps = new SearchResultPageSteps();
            _productListPageSteps = new ProductListPageSteps();
            _productPageSteps = new ProductPageSteps();
        }


        [SetUp]
        public void SetUp()
        {
            _baseSteps.NavigateToUrl(URL);
            _homePageSteps.WaitPageIsDisplayed();
        }

        [Test]
        public void SearchMacbookTest()
        {
            _homePageSteps.Search(searchProductMac);

            _searchResultPageSteps.WaitSearchPageIsDisplayed();

            var resultList = _searchResultPageSteps.GetResultItemTitles;

            Assert.IsTrue(resultList.Length > 0, "No elements in result");

            Assert.IsTrue(resultList.All(i => i.ToLower().Contains(searchProductMac)), "Not All contains product name");
        }

        [Test]
        public void NavigateTVLG()
        {
            _homePageSteps.NavigateTo(catalogItem, itemSpecific);

            _productListPageSteps.WaitCatalogPageIsDisplayed();

            var resultList = _productListPageSteps.GetResultItemTitles;

            Assert.IsTrue(resultList.Length > 0, "No elements in result");

            Assert.IsTrue(resultList.All(i => i.Contains(itemSpecific)), "Not All contains product name");
        }

        [Test]
        public void SearchAndCheckTV()
        {
            _homePageSteps.Search(searchProductTv);

            _searchResultPageSteps.WaitSearchPageIsDisplayed();

            var expectedName = _searchResultPageSteps.GetProductName(0);
            var expectedPrice = _searchResultPageSteps.GetProductPrice(0);

            _searchResultPageSteps.NavigateToProduct(0);

            _productPageSteps.WaitProductPageIsDisplayed();

            var actualName = _productPageSteps.GetProductTitle;
            var actualPrice = _productPageSteps.GetProductPrice;

            Assert.AreEqual(expectedName, actualName, "Product name is different");
            Assert.AreEqual(expectedPrice, actualPrice, "Product price is different");
        }

        [Test]
        public void SearchTVCheckFilter()
        {
            _homePageSteps.Search(searchProductTv);

            _searchResultPageSteps.WaitSearchPageIsDisplayed();

            var expectedFilterList = new string[] {
                "Смартфоны",
                "Мобильные телефоны",
                "Планшеты",
                "Ноутбуки и ультрабуки",
                "iMac"
            };

            var actualFilterList = _searchResultPageSteps.GetFilterListForTV;

            Assert.AreEqual(expectedFilterList.Length, actualFilterList.Length, "Filter list has different length");
            CollectionAssert.AreEquivalent(expectedFilterList,actualFilterList, "Different filter element name");
        }
    }
}
