using NUnit.Framework;
using System.Linq;
using WebDriverHomeTask.Steps;
using WebDriverHomeTask.Tests;

namespace WebDriverHomeTask
{
    public class TestClass : BaseTestClass
    {
        [Test]
        public void SearchMacbookTest()
        {
            string searchProduct = "macbook";
            _driver.Url = URL;
            var homePage = new HomePageSteps(_driver);
            var resultPage = new SearchResultPageSteps(_driver);

            homePage.WaitPageIsDisplayed();

            homePage.Search(searchProduct);

            resultPage.WaitSearchPageIsDisplayed();

            var resultList = resultPage.GetResultItemTitles;

            Assert.IsTrue(resultList.Length > 0, "No elements in result");

            Assert.IsTrue(resultList.All(i => i.ToLower().Contains(searchProduct)), "Not All contains product name");
        }

        [Test]
        public void NavigateTVLG()
        {
            string catalogItem = "Телевизоры, фото, видео";
            string itemSpecific = "LG";

            _driver.Url = URL;
            var homePage = new HomePageSteps(_driver);
            var resultPage = new ProductListPageSteps(_driver);

            homePage.WaitPageIsDisplayed();

            homePage.NavigateTo(catalogItem, itemSpecific);

            resultPage.WaitCatalogPageIsDisplayed();

            var resultList = resultPage.GetResultItemTitles;

            Assert.IsTrue(resultList.Length > 0, "No elements in result");

            Assert.IsTrue(resultList.All(i => i.Contains(itemSpecific)), "Not All contains product name");
        }

        [Test]
        public void SearchAndCheckTV()
        {
            string searchProduct = "TV";
            _driver.Url = URL;
            var homePage = new HomePageSteps(_driver);
            var resultPage = new SearchResultPageSteps(_driver);
            var productPage = new ProductPageSteps(_driver);

            homePage.WaitPageIsDisplayed();

            homePage.Search(searchProduct);

            resultPage.WaitSearchPageIsDisplayed();

            var expectedName = resultPage.GetProductName(0);
            var expectedPrice = resultPage.GetProductPrice(0);

            resultPage.NavigateToProduct(0);

            productPage.WaitProductPageIsDisplayed();

            var actualName = productPage.GetProductTitle;
            var actualPrice = productPage.GetProductPrice;

            Assert.AreEqual(expectedName, actualName, "Product name is different");
            Assert.AreEqual(expectedPrice, actualPrice, "Product price is different");
        }

        [Test]
        public void SearchTVCheckFilter()
        {
            string searchProduct = "TV";
            _driver.Url = URL;
            var homePage = new HomePageSteps(_driver);
            var resultPage = new SearchResultPageSteps(_driver);

            homePage.WaitPageIsDisplayed();

            homePage.Search(searchProduct);

            resultPage.WaitSearchPageIsDisplayed();

            var expectedFilterList = new string[] {
                "Смартфоны",
                "Мобильные телефоны",
                "Планшеты",
                "Ноутбуки и ультрабуки",
                "iMac"
            };

            var actualFilterList = resultPage.GetFilterListForTV;

            Assert.AreEqual(expectedFilterList.Length, actualFilterList.Length, "Filter list has different length");

            if (expectedFilterList.Length == actualFilterList.Length)
            {
                for (int i = 0; i < expectedFilterList.Length; i++)
                {
                    Assert.AreEqual(expectedFilterList[i], actualFilterList[i], "Different filter element name");
                }
            }
        }
    }
}
