using OpenQA.Selenium;
namespace WebDriverHomeTask.Pages
{
    public class ProductPage
    {
        private IWebDriver _driver;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ProductTitle => _driver.FindElement(By.ClassName("product__title"));

        public IWebElement ProductPrice => _driver.FindElement(By.CssSelector(".el-tabs .price  span  span"));
    }
}
