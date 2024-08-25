using Mns.SeleniumBDD.ApplicationLayer.Pages;

using Mns.SeleniumBDD.FrameworkLayer.TestBase;
using OpenQA.Selenium;

namespace Mns.SeleniumBDD.ApplicationLayer.Pages
{
    public class UserHomepage:BasePage
    {
        IWebElement myAccountBtn => LocateElement("//button[@aria-label='My account']");
        public string GetAccountGreetingMessage()
        {
            MoveToAnElement(myAccountBtn);
            var userAccountGreetingMessageElement = LocateElement("//span[.='Orders & returns']/ancestor::ul/preceding-sibling::p");
            var userAccountGreetingMessage = GetElementsText(userAccountGreetingMessageElement);
            return userAccountGreetingMessage;
        }

        public ProductsPage SelectProductCategory(string productTabName, string productCategory)
        {
            MoveToAnElement(LocateElement($"//p[.='{productTabName}']"));
            MoveToElementAndClick(LocateElement($"//li//a[.='{productCategory}']"));
            return new ProductsPage();
        }
    }
}