using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebDriverHomeTask.Pages
{
    public class ProductPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "product__title")]
        public IWebElement ProductTitle;

        [FindsBy(How = How.CssSelector, Using = ".el-tabs .price  span  span")]
        public IWebElement ProductPrice;
    }
}
