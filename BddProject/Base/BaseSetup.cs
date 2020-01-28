using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using static WebDriverHomeTask.Core.SeleniumDriver;

namespace BddProject.Base
{
    public class BaseSetup
    {
        [BeforeFeature]
        public void Setup()
        {
            Driver.Manage().Window.Maximize();
        }

        [AfterFeature]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
