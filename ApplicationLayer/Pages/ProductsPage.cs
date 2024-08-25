﻿using Mns.SeleniumBDD.ApplicationLayer.Pages;

using Mns.SeleniumBDD.FrameworkLayer.TestBase;

namespace Mns.SeleniumBDD.ApplicationLayer.Pages
{
    public class ProductsPage:BasePage
    {
        public void FilterProduct(string filterCategory,string filterCriteria)
        {
            ClickOnElement(LocateElement($"//button[span[.='{filterCategory}']]"));
            MoveToElementAndClick(LocateElement($"//input[@value='{filterCriteria}']"));
            ClickOnElement(LocateElement("//button[.='View Items']"));
        }

        public void SortProductBy(string sortCategory)
        {
            var sortDropdown = LocateElement("//select[@id='sortBy']");
            SelectItemFromDropdown(sortDropdown, sortCategory);
        }

        public ProductPage SelectProduct(string productName)
        {
            ClickOnElement(LocateElement($"//h2[.='{productName}']"));
            return new ProductPage();
        } 
    }
}