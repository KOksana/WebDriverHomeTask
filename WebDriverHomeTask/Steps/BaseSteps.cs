using OpenQA.Selenium.Support.UI;
using System;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Steps
{
    public class BaseSteps
    {
        protected WebDriverWait _wait;

        public BaseSteps()
        {
            _wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));
        }

        public void NavigateToUrl(string URL)
        {
            Driver.Navigate().GoToUrl(URL);
        }
    }
}
