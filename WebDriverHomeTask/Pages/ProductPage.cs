using OpenQA.Selenium;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Pages
{
    public class ProductPage : BasePage
    {
        public IWebElement ProductTitle 
            => Driver.FindElement(By.ClassName("product__title"));

        public IWebElement ProductPrice 
            => Driver.FindElement(By.CssSelector(".el-tabs .price  span  span"));
    }
}
