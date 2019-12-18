using OpenQA.Selenium;
using System.Linq;

namespace WebDriverHomeTask.Pages
{
    public class ProductListPage : BasePage
    {
        public ProductListPage(IWebDriver driver) : base(driver) { }
       
        public IWebElement[] ItemTitles => _driver.FindElements(By.CssSelector(".product-card__name a")).ToArray();

        public IWebElement CategoryTitle => _driver.FindElement(By.ClassName("catalog__main-content"));
    }
}
