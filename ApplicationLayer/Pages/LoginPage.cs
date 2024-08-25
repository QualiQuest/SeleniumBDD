﻿using Mns.SeleniumBDD.ApplicationLayer.Pages;

using Mns.SeleniumBDD.FrameworkLayer.TestBase;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mns.SeleniumBDD.ApplicationLayer.Pages
{
    public class LoginPage : BasePage
    {
        IWebElement signinItem => LocateElement("//span[.='Sign in']");
        public IWebElement UsernameEmailAddressField => LocateElement("//input[@id='usernameInput']");
        IWebElement userPasswordField => LocateElement("//input[@id='passwordInput']");
        IWebElement signinBtn => LocateElement("//button[@id='submitButton']//span[text()='Sign in']");
        IWebElement createAccountLink => LocateElement("//a[.='Create an account']");
        IWebElement forgottenPasswordLink => LocateElement("//a[.='Forgot your password?']");
        IWebElement customerDataPromiseLink => LocateElement("//a[.='View our Customer Data Promise']");
        public UserHomepage LoginToApplication(string username, string password)
        {
            EnterTextToInputField(UsernameEmailAddressField, username); // no wait time because its on the same page and click/perform because user have to input password before any action.
            EnterTextToInputField(userPasswordField, password);
            ClickOnElement(signinBtn);

            return new UserHomepage();
        }

        public CreateAccountPage GotoCreateAccountPage()
        {
            ClickOnElement(createAccountLink);
            return new CreateAccountPage();
        }

        public ForgottenPasswordPage GoToForgottenPasswordPage()
        {
            ClickOnElement(forgottenPasswordLink);
            return new ForgottenPasswordPage();
        }

        public string GetLoginFailureMessage()
        {
            return GetElementsText(LocateElement("//div[@id='alertBanner']//span[starts-with(text(),'Your')]"));
        }
        public CustomerDataPromisePage GoToCustomerDatapromisePage()
        {
            ClickOnElement(customerDataPromiseLink);
            return new CustomerDataPromisePage();
        }

        public string EnterInvalidEmailAddress(string invalidEmailAddress)
        {
            EnterTextToInputField(UsernameEmailAddressField, invalidEmailAddress);
            var displayedErrorMessage = GetElementsText(LocateElement("//div[@id='usernameInput_error']//div"));
            return displayedErrorMessage;
        }

    }
}
