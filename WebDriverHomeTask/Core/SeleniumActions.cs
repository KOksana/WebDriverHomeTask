using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebDriverHomeTask.Core
{
    public class SeleniumActions
    {
        private Actions _driverActions;

        public Actions Action => _driverActions ?? (_driverActions = new Actions(SeleniumDriver.Driver));


        public SeleniumActions MoveToElement(IWebElement element)
        {
            Action.MoveToElement(element);
            return this;
        }

        public void ClickWithHold()
        {
            Action.ClickAndHold().Build().Perform();
        }
    }
}
