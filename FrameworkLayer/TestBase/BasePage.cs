﻿using Mns.SeleniumBDD.FrameworkLayer.Utility;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mns.SeleniumBDD.ApplicationLayer.Pages;
using TechTalk.SpecFlow;

namespace Mns.SeleniumBDD.FrameworkLayer.TestBase
{
    public class BasePage
    {
        public static IWebDriver Driver;
        private Actions _actions;
        public static string PathToFileEnvironmentVariableFile = PathHelper.GetPathToFile("EnvironmentVariable.json", @"FrameworkLayer/Resource");

        public void LaunchBrowser()
        {
            //var pathToFile = PathHelper.GetPathToFile("EnvironmentVariable.json", @"FrameworkLayer\Resource");
            var browserTolaunch = VariableValueReader.ReadVariableValue(PathToFileEnvironmentVariableFile, "browser");
            switch (browserTolaunch.ToLower())
            {
                case "chrome":
                    Driver = new ChromeDriver();
                    break;
                case "firefox":
                    Driver = new FirefoxDriver();
                    break;
                case "egde":
                    Driver = new EdgeDriver();
                    break;
                default:
                    Console.WriteLine("The browser type specified is not supported by the framework");
                    break;
            }

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.0);
            Driver.Manage().Window.Maximize();
        }

        public LandingPage LaunchSite()
        {
            //var pathToFile = PathHelper.GetPathToFile("EnvironmentVariable.json", @"FrameworkLayer/Resource");
            var siteToLaunch = VariableValueReader.ReadVariableValue(PathToFileEnvironmentVariableFile, TestContext.Parameters["siteUrl"]);
            Driver.Navigate().GoToUrl(siteToLaunch);
            var acceptCookieBtn = LocateElement("//button[@id='onetrust-accept-btn-handler']");
            ClickOnElement(acceptCookieBtn);
            Thread.Sleep(1000);
            return new LandingPage();
        }

        /// <summary>
        /// Locate element by the xpath argument supplied to it when the method is invoked
        /// </summary>
        /// <param name="xpathOftheElementToLocate"></param>
        /// <returns></returns>
        public IWebElement LocateElement(string xpathOftheElementToLocate)
        {
            return Driver.FindElement(By.XPath(xpathOftheElementToLocate));
        }



        public void MoveToAnElement(IWebElement elementtoMoveTo)
        {
            _actions = new Actions(Driver);
            _actions.MoveToElement(elementtoMoveTo).Perform();
        }

        public void MoveToElementAndClick(IWebElement elementtoMoveTo)
        {
            _actions = new Actions(Driver);
            _actions.MoveToElement(elementtoMoveTo).Click().Perform();
        }

        public void EnterTextToInputField(IWebElement elementtoEnterTextTo, string textToEnter)
        {
            elementtoEnterTextTo.SendKeys(textToEnter);
        }

        public void ClickOnElement(IWebElement elementToClickOn)
        {
            elementToClickOn.Click();
        }

        /// <summary>
        /// get the text contained in the web element specified to it as parameter when invoked
        /// </summary>
        /// <param name="elementToGetTextFor"></param>
        /// <returns></returns>
        public string GetElementsText(IWebElement elementToGetTextFor)
        {
            return elementToGetTextFor.Text;
        }

        public void SelectItemFromDropdown(IWebElement dropdownToSelectFrom, string itemNameToSelect)
        {
            SelectElement selectElement = new SelectElement(dropdownToSelectFrom);
            selectElement.SelectByText(itemNameToSelect);
        }

      

    }
}
