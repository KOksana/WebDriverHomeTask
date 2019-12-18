using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverHomeTask.Steps
{
    public class BaseSteps
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        public BaseSteps(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
        }
    }
}
