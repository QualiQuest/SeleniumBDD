using Mns.SeleniumBDD.FrameworkLayer.TestBase;
using TechTalk.SpecFlow;

namespace Mns.SeleniumBDD.TestHook
{
    [Binding]
    public sealed class Hooks:BasePage
    {
        [BeforeScenario]
        public void LaunchSite()
        {
             LaunchBrowser();
             LaunchSite();
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}