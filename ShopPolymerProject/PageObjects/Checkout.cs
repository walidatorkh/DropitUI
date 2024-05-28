using DropitUI.ShopPolymerProject.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;


namespace DropitUI.ShopPolymerProject.PageObjects
{
    internal class Checkout : CommonOps
    {

        public Checkout()
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(Convert.ToDouble(GetData("TIME_OUT")))));
        }

        // Method to find and return the shopCartButton element using shadow DOM
        public IWebElement GetAccountEmailInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='checkout']";
            string shadowElementCssSelector = "#accountEmail";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
        public IWebElement GetAccountPhoneInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='checkout']";
            string shadowElementCssSelector = "#accountPhone";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
        public IWebElement GetAccountAddressInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='checkout']";
            string shadowElementCssSelector = "#shipAddress";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
        public IWebElement GetAccountCityInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='checkout']";
            string shadowElementCssSelector = "#shipCity";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
        public IWebElement GetAccountStateInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='checkout']";
            string shadowElementCssSelector = "#shipState";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
        public IWebElement GetAccountZipInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='checkout']";
            string shadowElementCssSelector = "#shipZip";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
        public IWebElement GetAccountChNumberInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='checkout']";
            string shadowElementCssSelector = "#ccNumber";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
        public IWebElement GetAccountChCVVInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='checkout']";
            string shadowElementCssSelector = "#ccCVV";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
        public IWebElement GetAccountPlaceOrderButtonInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='checkout']";
            string shadowElementCssSelector = "input[value='Place Order']";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
        public IWebElement GetAccountFinishButtonInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='checkout']";
            string shadowElementCssSelector = "a[href='/']";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }
    }
}