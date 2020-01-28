using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "search-input")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".menu--desktop__title i")]
        public IWebElement CatalogButton;

        public IWebElement CatalogItem(string titleName) => Driver.FindElement(By.CssSelector($"a[title='{titleName}']"));

        public IWebElement CatalogItemSpecific(string titleName) => Driver.FindElement(By.CssSelector($".menu-aim__item-submenu a[title ='{titleName}']"));
    }
}
