﻿using Mns.SeleniumBDD.ApplicationLayer.Pages;
using Mns.SeleniumBDD.FrameworkLayer.TestBase;

namespace Mns.SeleniumBDD.ApplicationLayer.Pages
{
    public class ProductPage : BasePage
    {
        public void SelectProductColour(string color)
        {
            /*var colourItem = LocateElement($"//label[starts-with(@id,'{color}')]");
            ClickOnElement(colourItem);*/
            ClickOnElement(LocateElement($"//label[starts-with(@id,'{color}')]"));
        }

        public void SelectProductSize(string size)
        {
            ClickOnElement(LocateElement($"//input[@value='{size}']"));
        }

        public void SelectProductQuantity(string quantity)
        {
            var dropdown = LocateElement("//select[@id='quantitySelector']");
            SelectItemFromDropdown(dropdown, quantity);
        }

        public BagPage AddProductToBag()
        {
            ClickOnElement(LocateElement("//button[.='Drop in my bag' or .='Add to bag']"));
            return new BagPage();
        }
    }
}
 