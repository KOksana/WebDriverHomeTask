using System;
using WebDriverHomeTask.Core;
using WebDriverHomeTask.Pages;

namespace WebDriverHomeTask.Steps
{
    public class BaseSteps
    {
        private readonly BasePage _basePage;

        public BaseSteps()
        {
            _basePage = new BasePage();
        }

        public void ClosePopup()
        {
            try
            {
                var isPopupPresent = CustomWait.IsElementBecomeVisibleInTimeout(_basePage.ClosePopupButton, 10);
                if (isPopupPresent) _basePage.ClosePopupButton.Click();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}