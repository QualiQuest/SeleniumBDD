using Mns.SeleniumBDD.FrameworkLayer.TestBase;
using OpenQA.Selenium;

namespace Mns.SeleniumBDD.ApplicationLayer.Pages
{
    public class BasketPage : BasePage
    {
        IWebElement removeItemFromBagBtn => LocateElement("//button[@aria-label='Move Item to wish list Kitten Heel Pointed Court Shoes, Silver, Size 4']");
        IWebElement moveItemToWishlistBtn => LocateElement("//button[@aria-label='Move Item to wish list Kitten Heel Pointed Court Shoes, Silver, Size 4']");

        public void SelectQuantity(string quantity)

        {
            var dropdowm = LocateElement("//select[@id='quantityDropdown-2004383297']");
            SelectItemFromDropdown(dropdowm, quantity);
        }

        public WishListPage MoveItemToWishlistPage()
        {
            ClickOnElement(moveItemToWishlistBtn);
            return new WishListPage();
        }
    }
}

