using OpenQA.Selenium;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Pages
{
    public class BasePage
    {
        public IWebElement ClosePopupButton
            => Driver.FindElement(By.XPath("//i[@class='el-dialog__close el-icon el-icon-close']"));
    }
}