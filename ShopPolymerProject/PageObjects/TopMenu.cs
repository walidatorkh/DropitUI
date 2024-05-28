using DropitUI.ShopPolymerProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Drawing;


namespace DropitUI.ShopPolymerProject.PageObjects
{
    internal class TopMenu : CommonOps
    {
        public TopMenu()
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(Convert.ToDouble(GetData("TIME_OUT")))));
        }

        // Method to find and return the shopCartButton element using shadow DOM
        public IWebElement GetLinkMensOutwearInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='home']";
            string shadowElementCssSelector = "a[href='/list/mens_outerwear']";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
        public IWebElement GetLinkLadiesTShirtsInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='home']"; // "shop-list[name='list']";
            string shadowElementCssSelector = "a[href='/list/ladies_tshirts']";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
        public IWebElement GetMenSOuterwearInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='home']"; // "shop-list[name='list']";
            string shadowElementCssSelector = "a[href='/list/mens_outerwear']";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
    }
}
