using Mns.SeleniumBDD.ApplicationLayer.Pages;
using Mns.SeleniumBDD.FrameworkLayer.TestBase;
using Mns.SeleniumBDD.FrameworkLayer.Utility;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Mns.SeleniumBDD.TestLayer.StepDefinition
{
    [Binding]
    public class LoginStepDefinitions
    {

        string username = VariableValueReader.ReadVariableValue(BasePage.PathToFileEnvironmentVariableFile, TestContext.Parameters["loginUsername"]);
        string password = VariableValueReader.ReadVariableValue(BasePage.PathToFileEnvironmentVariableFile, TestContext.Parameters["loginPassword"]);
        LoginPage loginPage;
        UserHomepage userHomepage;

        [Given(@"User is already on the login page")]
        public void GotoMnSLoginPage()
        {
            loginPage = new LandingPage().GotoLoginPage();  
        }

        [When(@"User attempt to login with valid credential")]
        public void LoginToApplication()
        {
            userHomepage = loginPage.LoginToApplication(username, password);
        }

        [When(@"User attempt to login with invalid credential")]
        public void WhenUserAttemptToLoginWithInvalidCredential(Table table)
        {
            dynamic credential = table.CreateDynamicInstance();
            userHomepage = loginPage.LoginToApplication(Convert.ToString(credential.username),
                                                        Convert.ToString(credential.password));
        }

        [Then(@"User should see a customise login welcome message to confirm that they have successfull been able to access their account")]
        public void VerifyUsserSuccessfullyLogin()
        {
            var actulMessage = userHomepage.GetAccountGreetingMessage();
            var expectedMessage = "Hello again, Jennifer";
            Assert.That(actulMessage, Is.EqualTo(expectedMessage));
        }

        [Then(@"User should be shown the error message ""([^""]*)""")]
        public void ThenUserShouldBeShownTheErrorMessage(string expectedErrorMessage)
        {
            var actualErrorMessage = loginPage.GetLoginFailureMessage();
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        }
    }
}
