using OpenQA.Selenium;
using WebDriverHomeTask.Core;
using WebDriverHomeTask.Pages;
using static WebDriverHomeTask.Core.CustomWait;

namespace WebDriverHomeTask.Steps
{
    public class HomePageSteps : BaseStep
    {
        private readonly HomePage _homePage;
        private readonly SeleniumActions _seleniumActions;

        public HomePageSteps()
        {
            _homePage = new HomePage();
            _seleniumActions = new SeleniumActions();
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

            _seleniumActions.MoveToElement(_homePage.CatalogItem(catalogItem)).ClickWithHold();
 

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
            => WaitForElementToBecomeVisibleWithinTimeout(_homePage.SearchField);
    }
}
