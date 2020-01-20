using SeleniumExtras.PageObjects;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Pages
{
    public class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}
