using SeleniumExtras.PageObjects;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace WebDriverHomeTask.Pages
{
    public class BasePage
    {
        protected BasePage()
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}
