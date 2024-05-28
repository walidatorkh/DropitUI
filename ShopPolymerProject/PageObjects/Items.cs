using DropitUI.ShopPolymerProject.Extensions;
using DropitUI.ShopPolymerProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Reflection;
using System.Threading;


namespace DropitUI.ShopPolymerProject.PageObjects
{
    internal class Items : CommonOps
    {

        public Items()
        //{
        //    PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(Convert.ToDouble(GetData("TIME_OUT")))));
        //}
        {
            driver = driver ?? throw new ArgumentNullException(nameof(driver));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        private ISearchContext GetShadowRoot(IWebElement element)
        {
            return (ISearchContext)element.GetShadowRoot();
        }

        private IWebElement GetElementInShadowRoot(ISearchContext shadowRoot, string cssSelector)
        {
            return shadowRoot.FindElement(By.CssSelector(cssSelector));
        }

        public IWebElement WaitForShadowHost(string cssSelector)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }


        public IWebElement GetMTVLadiesYellowTShirtInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-list[name='list']";
            string shadowItemCSS = "li > a";
            int index = 17;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }


        public IWebElement GetYouTubeUltimateHoodedSweatshirtInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-list[name='list']";
            string shadowItemCSS = "li > a";
            int index = 4;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }

        public void SelectSize(string size)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for the shadow host to be available
            IWebElement shadowHost = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("shop-app")));

            // Get the shadow root 1
            ISearchContext shadowRoot1 = GetShadowRoot(shadowHost);

            // Find the shop detail element in shadow root 1
            IWebElement shopDetailElement = shadowRoot1.FindElement(By.CssSelector("shop-detail[name='detail']"));

            // Get the shadow root 2
            ISearchContext shadowRoot2 = GetShadowRoot(shopDetailElement);

            // Wait for the size select element to be available
            // Wait for the size select element to be available
            IWebElement sizeSelectElement = wait.Until(drv => shadowRoot2.FindElement(By.CssSelector("select#sizeSelect")));


            // Select the size using UIActions
            UIActions.SelectByText(driver, sizeSelectElement, size);
        }


        public void SelectQuantity(string quantity)
        {
            IWebElement shadowHost = WaitForShadowHost("shop-app");
            ISearchContext shadowRoot1 = GetShadowRoot(shadowHost);
            IWebElement shopDetailElement = GetElementInShadowRoot(shadowRoot1, "shop-detail[name='detail']");
            ISearchContext shadowRoot2 = GetShadowRoot(shopDetailElement);
            IWebElement quantitySelectElement = GetElementInShadowRoot(shadowRoot2, "select#quantitySelect");
            SelectElement quantitySelect = new SelectElement(quantitySelectElement);
            UIActions.SelectByText(driver, quantitySelectElement, quantity);
        }

        public void AddToCart()
        {
            IWebElement shadowHost = WaitForShadowHost("shop-app");
            ISearchContext shadowRoot1 = GetShadowRoot(shadowHost);
            IWebElement shopDetailElement = GetElementInShadowRoot(shadowRoot1, "shop-detail[name='detail']");
            ISearchContext shadowRoot2 = GetShadowRoot(shopDetailElement);
            IWebElement addToCartButton = GetElementInShadowRoot(shadowRoot2, "button[aria-label='Add this item to cart']");
            UIActions.ClickElement(addToCartButton);
        }

        public void ProceedCheckout()
        {
            IWebElement shadowHost = WaitForShadowHost("shop-app");
            ISearchContext shadowRoot1 = GetShadowRoot(shadowHost);
            IWebElement openedElement = shadowRoot1.FindElement(By.CssSelector(".opened"));
            ISearchContext shadowRoot4 = GetShadowRoot(openedElement);
            IWebElement checkoutButton = GetElementInShadowRoot(shadowRoot4, "a[href='/checkout']");
            UIActions.ClickElement(checkoutButton);
        }

        public void BackToShop()
        {

            // Wait for the shop-app element to be present
            IWebElement shadowHost = WaitForShadowHost("shop-app");

            // Get the shadow root of the shop-app element
            ISearchContext shadowRoot1 = GetShadowRoot(shadowHost);

            // Find the "SHOP Home" link within the shadow DOM of shop-app
            IWebElement shopHomeLink = shadowRoot1.FindElement(By.CssSelector("a[aria-label='SHOP Home']"));

            // Click the "SHOP Home" link
            UIActions.ClickElement(shopHomeLink);

        }


    }
}
