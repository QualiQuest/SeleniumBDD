using Mns.SeleniumBDD.FrameworkLayer.TestBase;
using TechTalk.SpecFlow;

namespace Mns.SeleniumBDD.TestHook
{
    [Binding]
    public sealed class Hooks:BasePage
    {
        ScenarioContext _scenarioContext;
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [BeforeScenario]
        public void Setup()
        {
             LaunchBrowser();
             LaunchSite();
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            
        }

        [AfterScenario]
        public void AfterScenario()
        {

            TakeScreenshot(_scenarioContext.ScenarioInfo.Title);
            Driver.Quit();
        }
    }
}