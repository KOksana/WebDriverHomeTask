using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverHomeTask.Pages;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Steps
{
    public class HomePageSteps : BaseSteps
    {
        private HomePage _homePage;

        public HomePageSteps()
        {
            _homePage = new HomePage();
        }

        public void Search(string searchText)
        {
            _homePage.SearchField.SendKeys(searchText);
            _homePage.SearchField.SendKeys(Keys.Enter);
        }

        public void NavigateTo(string catalogItem, string itemSpecific)
        {
            Actions actions = new Actions(Driver);
            
            actions.MoveToElement(_homePage.CatalogItem(catalogItem)).ClickAndHold().Build().Perform();

            _homePage.CatalogItemSpecific(itemSpecific).Click();
        }

        public void WaitPageIsDisplayed()
        {
            _wait.Until(drv => _homePage.SearchField.Displayed);
        }
    }
}
