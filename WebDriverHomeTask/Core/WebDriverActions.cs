using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebDriverHomeTask.Core
{
    public static class WebDriverActions
    {
        public static IWebDriver Hover(this IWebDriver driver, IWebElement element)
        {
            var action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
            return driver;
        }

        public static IWebDriver ClickWithHold(this IWebDriver driver, IWebElement element) 
        {
            var action = new Actions(driver);
            action.ClickAndHold(element).Build().Perform();
            return driver;
        }
    }
}
