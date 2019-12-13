using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverHomeTask.Core;
using WebDriverHomeTask.Steps;

namespace WebDriverHomeTask
{
    public class TestClass
    {
        private IWebDriver _driver;
        private const string URL = "https://www.citrus.ua/";

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = SeleniumDriver.Driver;
            _driver.Manage().Window.Maximize();
        }

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

            var resultList = resultPage.GetResultItemTitles();

            Assert.IsTrue(resultList.Length > 0, "No elements in result"); ;

            Assert.IsTrue(resultList.All(i => i.ToLower().Contains(searchProduct)), "Not All contain");
        }

        [Test]
        public void SearchTVLG()
        {
            string searchProduct = "LG";
            _driver.Url = URL;
            var homePage = new HomePageSteps(_driver);
            var resultPage = new SearchResultPageSteps(_driver);

            homePage.WaitPageIsDisplayed();

            homePage.Search(searchProduct);

            resultPage.WaitSearchPageIsDisplayed();

            var resultList = resultPage.GetResultItemTitles();

            Assert.IsTrue(resultList.Length > 0, "No elements in result"); ;

            Assert.IsTrue(resultList.All(i => i.ToLower().Contains(searchProduct)), "Not All contain");
        }

        [Test]
        public void SearchAndCheckTV()
        {
            string searchProduct = "TV";
            _driver.Url = URL;
            var homePage = new HomePageSteps(_driver);
            var resultPage = new SearchResultPageSteps(_driver);

            homePage.WaitPageIsDisplayed();

            homePage.Search(searchProduct);

            resultPage.WaitSearchPageIsDisplayed();

            var resultList = resultPage.GetResultItemTitles();

            Assert.IsTrue(resultList.All(i => i.Contains(searchProduct)));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            //_driver.Quit();
        }
    }
}
