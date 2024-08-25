using Mns.SeleniumBDD.ApplicationLayer.Pages;
using Mns.SeleniumBDD.FrameworkLayer.TestBase;
using Mns.SeleniumBDD.FrameworkLayer.Utility;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Mns.SeleniumBDD.TestLayer.StepDefinition
{
    [Binding]
    public class LoginStepDefinitions:BasePage
    {
        ScenarioContext  _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

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


        [When(@"User enters an invalid email address ""([^""]*)""")]
        public void WhenUserEntersAnInvalidEmailAddress(string invalidEmail)
        {
           EnterTextToInputField(loginPage.UsernameEmailAddressField, invalidEmail);
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

            Assert.That(actualErrorMessage.Contains(expectedErrorMessage), Is.True);
            TakeScreenshot(_scenarioContext.ScenarioInfo.Title);
        }

        [Then(@"User should be shown the error message ""([^""]*)"" to confirm that only valid email address is accepted")]
        public void ThenUserShouldBeShownTheErrorMessageToConfirmThatOnlyValidEmailAddressIsAccepted(string expectedErrorMessage)
        {
            var actualErrorMessage = GetElementsText(LocateElement("//div[@id='usernameInput_error']//div"));
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));  
        }

    }
}
