using OpenQA.Selenium;
using System.Linq;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Pages
{
    public class ProductListPage : BasePage
    {
        public IWebElement[] ItemTitles => Driver.FindElements(By.CssSelector(".product-card__name a")).ToArray();

        public IWebElement CategoryTitle => Driver.FindElement(By.ClassName("catalog__main-content"));
    }
}
