using Mns.SeleniumBDD.ApplicationLayer.Pages;

using Mns.SeleniumBDD.FrameworkLayer.TestBase;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mns.SeleniumBDD.ApplicationLayer.Pages
{
    public class LandingPage:BasePage
    {
        IWebElement signinBtn => LocateElement("//p[.='Sign in']");

        public LoginPage GotoLoginPage()
        {
            ClickOnElement(signinBtn);
           return new LoginPage();
        }
    }
}
