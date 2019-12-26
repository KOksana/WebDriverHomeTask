using OpenQA.Selenium;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Pages
{
    public class HomePage : BasePage
    {
       // public HomePage(IWebDriver driver) : base(driver) { }

        public IWebElement SearchField => Driver.FindElement(By.Id("search-input"));

        public IWebElement CatalogButton => Driver.FindElement(By.CssSelector(".menu--desktop__title i"));

        public IWebElement CatalogItem(string titleName) => Driver.FindElement(By.CssSelector($"a[title='{titleName}']"));

        public IWebElement CatalogItemSpecific(string titleName) => Driver.FindElement(By.CssSelector($".menu-aim__item-submenu a[title ='{titleName}']"));

    }
}
