using NUnit.Framework;
using System.Linq;
using WebDriverHomeTask.Steps;
using WebDriverHomeTask.Tests;

namespace WebDriverHomeTask
{
    public class TestSuite : BaseTest
    {
        // string items
        private static string SearchProduct   =>  "macbook";
        private static string CatalogItem     =>  "Телевизоры, фото, видео";
        private static string ItemSpecific    =>  "LG";
        private static string SearchProductTv =>  "TV";

        // pages
        private readonly HomePageSteps _homePageSteps;
        private readonly SearchResultPageSteps _searchResultPageSteps;
        private readonly ProductListPageSteps _productListPageSteps;
        private readonly ProductPageSteps _productPageSteps;

        public TestSuite()
        {
            _homePageSteps = new HomePageSteps();
            _searchResultPageSteps = new SearchResultPageSteps();
            _productListPageSteps = new ProductListPageSteps();
            _productPageSteps = new ProductPageSteps();
        }

        [SetUp]
        public void SetUp()
        {
            _homePageSteps.WaitPageIsDisplayed();
        }

        [Test]
        public void SearchMacBookTest()
        {
            // Arrange
            _homePageSteps.Search(SearchProduct);
            _searchResultPageSteps.WaitSearchPageIsDisplayed();

            // Act
            var resultList = _searchResultPageSteps.GetResultItemTitles;

            // Assert
            Assert.IsTrue(resultList.Length > 0, "No elements in result");
            Assert.IsTrue(resultList.All(i => i.ToLower().Contains(SearchProduct)), "Not All contains product name");
        }

        [Test]
        public void NavigateTvLg()
        {
            // Arrange
            _homePageSteps.NavigateTo(CatalogItem, ItemSpecific);
            _productListPageSteps.WaitCatalogPageIsDisplayed();

            // Act
            var resultList = _productListPageSteps.GetResultItemTitles;

            // Assert
            Assert.IsTrue(resultList.Length > 0, "No elements in result");
            Assert.IsTrue(resultList.All(i => i.Contains(ItemSpecific)), "Not All contains product name");
        }

        [Test]
        public void SearchAndCheckTv()
        {
            // Arrange
            _homePageSteps.Search(SearchProductTv);
            _searchResultPageSteps.WaitSearchPageIsDisplayed();
            var expectedName  = _searchResultPageSteps.GetProductName(0);
            var expectedPrice = _searchResultPageSteps.GetProductPrice(0);

            // Act
            _searchResultPageSteps.NavigateToProduct(0);
            _productPageSteps.WaitProductPageIsDisplayed();
            var actualName = _productPageSteps.GetProductTitle;
            var actualPrice = _productPageSteps.GetProductPrice;

            // Assert
            Assert.AreEqual(expectedName, actualName, "Product name is different");
            Assert.AreEqual(expectedPrice, actualPrice, "Product price is different");
        }

        [Test]
        public void SearchTvCheckFilter()
        {
            // Arrange
            _homePageSteps.Search(SearchProductTv);
            _searchResultPageSteps.WaitSearchPageIsDisplayed();
            var expectedFilterList = new[] { "Смартфоны", "Мобильные телефоны", "Планшеты", "Ноутбуки и ультрабуки", "iMac" };

            // Act
            var actualFilterList = _searchResultPageSteps.GetFilterListForTv;

            // Assert
            Assert.AreEqual(expectedFilterList.Length, actualFilterList.Length, "Filter list has different length");
            CollectionAssert.AreEquivalent(expectedFilterList, actualFilterList);
        }
    }
}
