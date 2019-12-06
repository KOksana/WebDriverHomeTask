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
            //_homePage.CatalogButton.Click();

            Actions actions = new Actions(_driver);
            
            actions.MoveToElement(_homePage.CatalogItem(catalogItem)).Perform();

           // _wait.Until(drv => _homePage.CatalogItemSpecific(itemSpecific).Enabled);

           // _wait.Until(drv => _driver.FindElements(By.CssSelector(".menu-aim__item-submenu .wrap"))[0].Displayed);

          //  actions.MoveToElement(_homePage.CatalogItemSpecific(itemSpecific)).Perform();

           // var elem = _homePage.CatalogItemSpecific(itemSpecific);

            var elem = _driver.FindElement(By.CssSelector(".menu-aim__item-submenu a[title ='LG']"));
           actions.MoveToElement(elem).Click().Build().Perform();
          
            
            
            // _driver.FindElement(By.CssSelector(".menu-aim__item-submenu a[title ='LG']")).Click();
            //elem.Click();

           // _homePage.CatalogItemSpecific(itemSpecific).Click();
        }

        public void WaitPageIsDisplayed()
        {
            _wait.Until(drv => _homePage.SearchField.Displayed);
        }
    }
}
