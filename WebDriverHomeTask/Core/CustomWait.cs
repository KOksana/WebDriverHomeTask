using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Core
{
    public static class CustomWait
    {
        public static void WaitForElementToBecomeVisibleWithinTimeout(IWebElement element, int timeout = 5)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ElementIsVisible(element));
        }

        public static bool IsElementBecomeVisibleInTimeout(IWebElement element, int timeout = 5)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            var isVisible = wait.Until(ElementIsVisible(element));
            return isVisible;
        }

        private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return driver => {
                try
                {
                    return element.Displayed;              
                }
                catch(Exception)
                {
                    // If element is null, stale or if it cannot be located
                    return false;
                }
            };
        }

    }
}
