using Mns.SeleniumBDD.FrameworkLayer.TestBase;
using OpenQA.Selenium;
using System.Drawing;

namespace Mns.SeleniumBDD.ApplicationLayer.Pages
{
    public class BagPage:BasePage
    {
        IWebElement continueShoppingBTn => LocateElement("//button[.='Continue shopping']");
        IWebElement checkoutBTn => LocateElement("//a/span[.='Checkout']");
 

        public BasketPage GotoCheckout()
        {
            ClickOnElement(checkoutBTn);

            return new BasketPage();
        }

        public ProductPage ContinueShopping()
        { 
          ClickOnElement(continueShoppingBTn);
            return new ProductPage();
        }
    }
}