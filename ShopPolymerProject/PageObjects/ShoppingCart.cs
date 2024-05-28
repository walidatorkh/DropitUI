using DropitUI.ShopPolymerProject.Extensions;
using DropitUI.ShopPolymerProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Text.RegularExpressions;


namespace DropitUI.ShopPolymerProject.PageObjects
{
    internal class ShoppingCart : CommonOps
    {

        public ShoppingCart()
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(Convert.ToDouble(GetData("TIME_OUT")))));
        }

        public IWebElement WaitForShadowHost(string cssSelector)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }

        private IWebElement GetElementInShadowRoot(ISearchContext shadowRoot, string cssSelector)
        {
            return shadowRoot.FindElement(By.CssSelector(cssSelector));
        }

        // Method to find and return the shopCartButton element using shadow DOM
        public IWebElement GetShopCartButtonInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='list']";
            string shadowElementCssSelector = "paper-icon-button[aria-label='Shopping cart: 0 items']";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }


        public IWebElement GetAddToCartButtonInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='detail']";
            string shadowElementCssSelector = "shop-detail[name='detail']";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }


        //public IWebElement GetSelectSizeInShadowDom()
        //{
        //    string shadowHostCSS = "shop-app";
        //    string shadowListCSS = "shop-detail[name='detail']";
        //    string shadowItemCSS = "#sizeSelect";
        //    int index = 2;
        //    return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        //}


        public IWebElement GetSelectSizeInShadowDom()
        {
            string[] shadowHostCSSSelectors = new string[]
            {
        "shop-app",
        "shop-detail[name='detail']"
            };
            string finalElementCssSelector = "#sizeLabel"; // #sizeSelect #sizeLabel
            return (IWebElement)CommonOps.GetElementsFromNestedShadowDom(driver, shadowHostCSSSelectors, finalElementCssSelector);
        }


        public IWebElement GetSelectQuantityInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='detail']";
            string shadowElementCssSelector = "#quantitySelect";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }


        public IWebElement GetViewCartButtonInShadowDom()
        {
            string shadowHostCSS = "shop-app[page='detail']";
            string shadowElementCssSelector = "#viewCartAnchor";

            return CommonOps.FindElementInShadowDom(driver, shadowHostCSS, shadowElementCssSelector);
        }

        public IWebElement GetAccountEmailInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout[name='checkout']";
            string shadowItemCSS = "#accountEmail";
            int index = 0;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }

        public IWebElement GetPhoneNumberInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout[name='checkout']";
            string shadowItemCSS = "#accountPhone";
            int index = 0;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }


        public IWebElement GetShipAddressInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout[name='checkout']";
            string shadowItemCSS = "#shipAddress";
            int index = 0;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }


        public IWebElement GetShipCityInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout[name='checkout']";
            string shadowItemCSS = "#shipCity";
            int index = 0;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }


        public IWebElement GetShipStateInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout[name='checkout']";
            string shadowItemCSS = "#shipState";
            int index = 0;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }


        public IWebElement GetZipInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout[name='checkout']";
            string shadowItemCSS = "#shipZip";
            int index = 0;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }


        public IWebElement GetCCNameInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout[name='checkout']";
            string shadowItemCSS = "#ccName";
            int index = 0;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }


        public IWebElement GetCCNumberInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout[name='checkout']";
            string shadowItemCSS = "#ccNumber";
            int index = 0;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }


        public IWebElement GetCCCVVInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout[name='checkout']";
            string shadowItemCSS = "#ccCVV";
            int index = 0;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }


        public IWebElement GetButtonPlaceOrderInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout[name='checkout']";
            string shadowItemCSS = "input[value='Place Order']";
            int index = 0;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }


        public IWebElement GetButtonFinishInShadowDom()
        {
            string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout[name='checkout']";
            string shadowItemCSS = "a[href='/']";
            int index = 0;
            return CommonOps.FindNthElementInShadowDom(driver, shadowHostCSS, shadowListCSS, shadowItemCSS, index);
        }


        public IWebElement GetCartQuantityInShadowDom() //string expectedQuantity
        {
            //string shadowHostCSS = "shop-app";
            string shadowListCSS = "shop-checkout"; // "shop-checkout[name='checkout']";
            string shadowItemCSS = ($"paper-icon-button[aria-label='Shopping cart: 6 item']"); // {expectedQuantity}
            return CommonOps.FindSecondElementInShadowDom(driver, shadowListCSS, shadowItemCSS);
        }


        public void ValidateCartQuantity(string expectedQuantity)
        {
            try
            {
                Console.WriteLine("Starting CartQuantityIn method...");
                extentTest.Log(LogStatus.Info, "Starting CartQuantityIn method...");

                // Wait for shadow host
                IWebElement shadowHost = WaitForShadowHost("shop-app");
                extentTest.Log(LogStatus.Info, "Shadow host located.");

                // Get shadow root for the shadow host
                ISearchContext shadowRoot1 = GetShadowRoot(shadowHost);
                extentTest.Log(LogStatus.Info, "Shadow root obtained.");

                // Locate checkout quantity element
                IWebElement checkoutQuantity = GetElementInShadowRoot(shadowRoot1, $"paper-icon-button[aria-label='Shopping cart: {expectedQuantity} items']");
                extentTest.Log(LogStatus.Info, $"Checkout quantity element located for expected quantity: {expectedQuantity}.");

                // Extract and print only the text "Shopping cart: x items"
                string buttonTextQuantity = checkoutQuantity.GetAttribute("aria-label");
                string quantityOfOrdered = Regex.Match(buttonTextQuantity, @"\d+").Value;
                extentTest.Log(LogStatus.Info, $"Extracted quantity of ordered: {quantityOfOrdered}");

                Console.WriteLine($"Quantity of ordered is: {quantityOfOrdered}");

                // Verify that expectedQuantity and quantityOfOrdered are equal
                Verifications.VerifyEquals(quantityOfOrdered, expectedQuantity);
                extentTest.Log(LogStatus.Pass, "Cart quantity validated successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception and fail the test
                Console.WriteLine("An error occurred: " + ex.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "An error occurred while validating cart quantity: " + ex.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw; // Re-throw the exception if you want to propagate it further
            }
        }

        public void ClickCheckoutButtonQuantity(string expectedQuantity)
        {
            try
            {
                Console.WriteLine("Starting ClickCheckoutQuantity method...");

                // Wait for shadow host
                IWebElement shadowHost = WaitForShadowHost("shop-app");
                extentTest.Log(LogStatus.Info, "Shadow host located.");

                // Get shadow root for the shadow host
                ISearchContext shadowRoot1 = GetShadowRoot(shadowHost);
                extentTest.Log(LogStatus.Info, "Shadow root obtained.");

                // Locate checkout quantity element
                IWebElement checkoutQuantity = GetElementInShadowRoot(shadowRoot1, $"paper-icon-button[aria-label='Shopping cart: {expectedQuantity} items']");
                extentTest.Log(LogStatus.Info, $"Checkout quantity element located for expected quantity: {expectedQuantity}.");

                // Click on checkout quantity element
                UIActions.ClickElement(checkoutQuantity);
                Console.WriteLine("Checkout quantity clicked successfully.");
                extentTest.Log(LogStatus.Pass, "Checkout quantity clicked successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception and fail the test
                Console.WriteLine("An error occurred: " + ex.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "An error occurred while clicking checkout quantity: " + ex.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw; // Re-throw the exception if you want to propagate it further
            }
        }

        public void ProceedCheckoutFromShopCart()
        {
            try
            {
                Console.WriteLine("Starting ProceedCheckoutFromShopCart method...");
                extentTest.Log(LogStatus.Info, "Starting ProceedCheckoutFromShopCart method...");

                // Wait for shadow host
                IWebElement shadowHost = WaitForShadowHost("shop-app");
                extentTest.Log(LogStatus.Info, "Shadow host located.");

                // Get shadow root for the shadow host
                ISearchContext shadowRoot1 = GetShadowRoot(shadowHost);
                extentTest.Log(LogStatus.Info, "Shadow root obtained.");

                // Locate the opened element in the shadow DOM
                IWebElement openedElement = shadowRoot1.FindElement(By.CssSelector("shop-cart[name='cart']"));
                extentTest.Log(LogStatus.Info, "Opened element located in the shadow DOM.");

                // Get the shadow root for the opened element
                ISearchContext shadowRoot4 = GetShadowRoot(openedElement);
                extentTest.Log(LogStatus.Info, "Shadow root for the opened element obtained.");

                // Locate the checkout button in the shop cart
                IWebElement checkoutButtonShopCart = GetElementInShadowRoot(shadowRoot4, "a[href='/checkout']");
                extentTest.Log(LogStatus.Info, "Checkout button located in the shop cart.");

                // Click on the checkout button
                UIActions.ClickElement(checkoutButtonShopCart);
                extentTest.Log(LogStatus.Pass, "Checkout button clicked successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception and fail the test
                Console.WriteLine("An error occurred: " + ex.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "An error occurred while proceeding to checkout from the shop cart: " + ex.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw; // Re-throw the exception if you want to propagate it further
            }
        }

        private ISearchContext GetShadowRoot(IWebElement shadowHost)
        {
            return (ISearchContext)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].shadowRoot", shadowHost);
        }

    }
}