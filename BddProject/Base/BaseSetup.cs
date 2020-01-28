using TechTalk.SpecFlow;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace BddProject.Base
{
    [Binding]
    public class BaseSetup
    {
        [BeforeFeature]
        public static void FeatureSetup()
        {
            Driver.Manage().Window.Maximize();
        }

        [AfterFeature]
        public static void FeatureTearDown()
        {
            Driver.Quit();
        }
    }
}
