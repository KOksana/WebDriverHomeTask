using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Pages
{
    public class ProductListPage : BasePage
    {
        public IWebElement[] ItemTitles => Driver.FindElements(By.CssSelector(".product-card__name a")).ToArray();

        [FindsBy(How = How.ClassName, Using = "catalog__main-content")]
        public IWebElement CategoryTitle;
    }
}
