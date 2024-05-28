using DropitUI.ShopPolymerProject.Extensions;
using DropitUI.ShopPolymerProject.PageObjects;
using DropitUI.ShopPolymerProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace DropitUI.ShopPolymerProject.WorkFlows
{
    class UIFlows : CommonOps
    {
        public static void SelectItem(IWebElement elem, string size)
        {
            try
            {
                UIActions.Click(elem);
                Console.WriteLine("Item clicked successfully");
                extentTest.Log(LogStatus.Pass, "Item clicked successfully");

                UIActions.UpdateDropDown(shoppingCart.GetSelectSizeInShadowDom(), size);
                Console.WriteLine($"Size '{size}' selected");
                extentTest.Log(LogStatus.Pass, $"Size '{size}' selected");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "SelectItem failed: " + ex.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw;
            }
        }
        public static void SelectItem(IWebElement elem, int number)
        {
            try
            {
                UIActions.Click(elem);
                Console.WriteLine("Item clicked successfully");
                extentTest.Log(LogStatus.Pass, "Item clicked successfully");

                UIActions.UpdateDropDown(shoppingCart.GetSelectQuantityInShadowDom(), number.ToString());
                Console.WriteLine($"Number '{number}' selected");
                extentTest.Log(LogStatus.Pass, $"Number '{number}' selected");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "SelectItem failed: " + ex.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw;
            }
        }

        public static void ClickElement(IWebElement elem)
        {
            try
            {
                UIActions.Click(elem);
                Console.WriteLine("Element clicked successfully");
                extentTest.Log(LogStatus.Pass, "Element clicked successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "ClickElement failed: " + ex.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw;
            }
        }



        public static void AddToCartProduct(IWebElement elem, string size, string quantity)
        {
            try
            {
                // Initialize WebDriverWait for waiting until elements are visible and clickable
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Check if the provided element is enabled and clickable
                wait.Until(ExpectedConditions.ElementToBeClickable(elem));

                if (elem.Enabled)
                {
                    extentTest.Log(LogStatus.Pass, "Element is enabled and clickable");
                    Console.WriteLine("Element is enabled and clickable");

                    // Click the element
                    UIActions.ClickElement(elem);
                    extentTest.Log(LogStatus.Pass, "Clicked on the element");
                }
                else
                {
                    extentTest.Log(LogStatus.Fail, "Element is not enabled");
                    Console.WriteLine("Element is not enabled");
                    return; // Exit the function if the element is not enabled
                }

                // Select the size of the product
                items.SelectSize(size);
                extentTest.Log(LogStatus.Pass, $"Selected size: {size}");

                // Select the quantity of the product
                items.SelectQuantity(quantity);
                extentTest.Log(LogStatus.Pass, $"Selected quantity: {quantity}");

                // Add the product to the cart
                items.AddToCart();
                extentTest.Log(LogStatus.Pass, "Product added to the cart");
            }
            catch (Exception ex)
            {
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                string screenshotPath = ScreenShot(testDescription);
                extentTest.Log(LogStatus.Fail, "Function AddToCartProduct failed: " + ex.Message + extentTest.AddScreenCapture(screenshotPath));
                Console.WriteLine("An error occurred: " + ex.Message);
                Assert.Fail("Function AddToCartProduct failed: " + ex.Message);
            }
        }


        public static void SelectProductType(IWebElement elem)
        {
            try
            {
                if (elem.Enabled)
                {
                    ClickElement(elem);
                    Console.WriteLine($"Clicked: {elem.Text}");
                    extentTest.Log(LogStatus.Pass, $"Clicked: {elem.Text}");
                }
                else
                {
                    Console.WriteLine("Element is not enabled");
                    extentTest.Log(LogStatus.Warning, "Element is not enabled");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "SelectProductType failed: " + ex.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw;
            }
        }

        public static void PlaceOrder(string xmlFilePath)
        {
            try
            {
                var dataRetriever = new CommonOps.DataRetriever(xmlFilePath: xmlFilePath);

                IWebElement shopCartEmail = shoppingCart.GetAccountEmailInShadowDom();
                string email = dataRetriever.GetData("EMAIL");
                Console.WriteLine($"Email: {email}");
                UIActions.UpdateText(shopCartEmail, email);
                extentTest.Log(LogStatus.Pass, "Email updated successfully.");

                IWebElement shopPhoneNumber = shoppingCart.GetPhoneNumberInShadowDom();
                string phoneNumber = dataRetriever.GetData("PHONENUMBER");
                Console.WriteLine($"Phone number: {phoneNumber}");
                UIActions.UpdateText(shopPhoneNumber, phoneNumber);
                extentTest.Log(LogStatus.Pass, "Phone number updated successfully.");



                // Get and update address
                IWebElement shopAddress = shoppingCart.GetShipAddressInShadowDom();
                string address = dataRetriever.GetData("ADDRESS");
                Console.WriteLine($"Address: {address}");
                UIActions.UpdateText(shopAddress, address);
                extentTest.Log(LogStatus.Pass, "Address updated successfully.");

                // Get and update city
                IWebElement shopCity = shoppingCart.GetShipCityInShadowDom();
                string city = dataRetriever.GetData("CITY");
                Console.WriteLine($"City: {city}");
                UIActions.UpdateText(shopCity, city);
                extentTest.Log(LogStatus.Pass, "City updated successfully.");

                // Get and update state
                IWebElement shopState = shoppingCart.GetShipStateInShadowDom();
                string state = dataRetriever.GetData("STATE");
                Console.WriteLine($"State: {state}");
                UIActions.UpdateText(shopState, state);
                extentTest.Log(LogStatus.Pass, "State updated successfully.");

                // Get and update ZIP
                IWebElement shopZip = shoppingCart.GetZipInShadowDom();
                string zip = dataRetriever.GetData("ZIP");
                Console.WriteLine($"ZIP: {zip}");
                UIActions.UpdateText(shopZip, zip);
                extentTest.Log(LogStatus.Pass, "ZIP updated successfully.");

                // Get and update credit card name
                IWebElement shopCCName = shoppingCart.GetCCNameInShadowDom();
                string ccName = dataRetriever.GetData("CCName");
                Console.WriteLine($"Credit Card Name: {ccName}");
                UIActions.UpdateText(shopCCName, ccName);
                extentTest.Log(LogStatus.Pass, "Credit Card Name updated successfully.");

                // Get and update credit card number
                IWebElement shopCCNumber = shoppingCart.GetCCNumberInShadowDom();
                string ccNumber = dataRetriever.GetData("CCNUMBER");
                Console.WriteLine($"Credit Card Number: {ccNumber}");
                UIActions.UpdateText(shopCCNumber, ccNumber);
                extentTest.Log(LogStatus.Pass, "Credit Card Number updated successfully.");

                // Get and update CVV
                IWebElement shopCCCVV = shoppingCart.GetCCCVVInShadowDom();
                string ccCVV = dataRetriever.GetData("CCCVV");
                Console.WriteLine($"Credit Card CVV: {ccCVV}");
                UIActions.UpdateText(shopCCCVV, ccCVV);
                extentTest.Log(LogStatus.Pass, "Credit Card CVV updated successfully.");

                IWebElement shopButtonPlaceOrder = shoppingCart.GetButtonPlaceOrderInShadowDom();
                UIActions.ClickElement(shopButtonPlaceOrder);
                Console.WriteLine("Place order button clicked.");
                extentTest.Log(LogStatus.Pass, "Place order button clicked successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "PlaceOrder failed: " + ex.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw;
            }
        }

    }
}
