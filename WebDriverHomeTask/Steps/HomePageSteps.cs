using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverHomeTask.Pages;

namespace WebDriverHomeTask.Steps
{
    public class HomePageSteps
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private WebDriverWait _wait;

        public HomePageSteps(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver);
            _wait =  new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
        }

        public void Search(string searchText)
        {
            _homePage.SearchField.SendKeys(searchText);
            _homePage.SearchField.SendKeys(Keys.Enter);
        }

        public void NavigateTo(string catalogItem, string itemSpecific)
        {
            // Wasn't able to navigate to sub catalog 

            //_homePage.CatalogButton.Click();

            //_homePage.CatalogItem(catalogItem).ClickA

            Actions actions = new Actions(_driver);
            
            actions.MoveToElement(_homePage.CatalogItem(catalogItem)).ClickAndHold().Build().Perform();

            // _wait.Until(drv => _homePage.CatalogItemSpecific(itemSpecific).Enabled);


            //var elem = _driver.FindElement(By.CssSelector(".menu-aim__item-submenu a[title ='LG']"));
            //actions.MoveToElement(elem).Click().Build().Perform();

           // Actions actions2 = new Actions(_driver);
            //actions2.MoveToElement(_homePage.CatalogItemSpecific(itemSpecific)).Build().Perform();
            //actions2.MoveToElement(_driver.FindElement(By.CssSelector(".menu-aim__item-submenu a[title ='LG']"))).Perform();
            //actions2.Click().Perform();

            _homePage.CatalogItemSpecific(itemSpecific).Click();
        }

        public void WaitPageIsDisplayed()
        {
            _wait.Until(drv => _homePage.SearchField.Displayed);
        }
    }
}
