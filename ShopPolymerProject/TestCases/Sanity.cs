using DropitUI.ShopPolymerProject.Utilities;
using DropitUI.ShopPolymerProject.TestCases;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using SeleniumExtras.WaitHelpers;
using DropitUI.ShopPolymerProject.WorkFlows;
using DropitUI.ShopPolymerProject.Extensions;
using DropitUI.ShopPolymerProject.PageObjects;
using System.Xml;
using System.IO;
using RelevantCodes.ExtentReports;


namespace DropitUI.ShopPolymerProject.TestCases
{
    [TestFixture]
    class Sanity : CommonOps
    {

        [Test]

        public void Test01_FullFlowPositive()
        {
            try
            {
                Thread.Sleep(5000);
                IWebElement menSOuterwear = topMenu.GetMenSOuterwearInShadowDom();
                UIFlows.SelectProductType(menSOuterwear);
                Thread.Sleep(5000);

                IWebElement youTubeUltimateHoodedSweatshirt = items.GetYouTubeUltimateHoodedSweatshirtInShadowDom();
                UIFlows.AddToCartProduct(youTubeUltimateHoodedSweatshirt, "XL", "3");
                items.BackToShop();
                Thread.Sleep(5000);

                IWebElement ladiesTShirts = topMenu.GetLinkLadiesTShirtsInShadowDom();
                UIFlows.SelectProductType(ladiesTShirts);
                Thread.Sleep(5000);

                IWebElement ladiesYellowTShirt = items.GetMTVLadiesYellowTShirtInShadowDom();
                UIFlows.AddToCartProduct(ladiesYellowTShirt, "S", "3");

                // Proceed to checkout
                items.ProceedCheckout();
                Thread.Sleep(5000);
                shoppingCart.ValidateCartQuantity((GetData("CART_VALID_QUANTITY")));

                UIFlows.PlaceOrder((@"C:\Automation\DropitUI\ShopPolymerProject\Configurations\dataValidOrder.xml"));
                IWebElement buttonFinish = shoppingCart.GetButtonFinishInShadowDom();
                UIActions.Click(buttonFinish);
                Thread.Sleep(5000);
                extentTest.Log(LogStatus.Pass, "Test passed: Button Finish Order is clicked as expected");


            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, ("An error occurred: " + ex.Message) + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                Assert.Fail("Test Full Flow failed: " + ex.Message);
            }

        }

        [Test]


        public void Test02_FullFlowNegative()
        {
            try
            {

                // Wait and interact with the page elements
                Thread.Sleep(5000);
                IWebElement menSOuterwear = topMenu.GetMenSOuterwearInShadowDom();
                UIFlows.SelectProductType(menSOuterwear);
                Thread.Sleep(5000);

                IWebElement youTubeUltimateHoodedSweatshirt = items.GetYouTubeUltimateHoodedSweatshirtInShadowDom();
                UIFlows.AddToCartProduct(youTubeUltimateHoodedSweatshirt, "XL", "1");
                items.BackToShop();
                Thread.Sleep(5000);

                IWebElement ladiesTShirts = topMenu.GetLinkLadiesTShirtsInShadowDom();
                UIFlows.SelectProductType(ladiesTShirts);
                Thread.Sleep(5000);

                IWebElement ladiesYellowTShirt = items.GetMTVLadiesYellowTShirtInShadowDom();
                UIFlows.AddToCartProduct(ladiesYellowTShirt, "S", "1");
                Thread.Sleep(5000);

                shoppingCart.ClickCheckoutButtonQuantity("3");
                shoppingCart.ProceedCheckoutFromShopCart();
                UIFlows.PlaceOrder(@"C:\Automation\DropitUI\ShopPolymerProject\Configurations\dataNonValidOrder.xml");

                Thread.Sleep(5000);

                IWebElement buttonPlaceOrder = shoppingCart.GetButtonPlaceOrderInShadowDom();

                // Check if the "Place Order" button is present and displayed
                if (buttonPlaceOrder != null && buttonPlaceOrder.Displayed)
                {
                    Console.WriteLine("Button Place Order is still present.");
                    extentTest.Log(LogStatus.Pass, "Test passed: Button Place Order is still present as expected");
                }
                else
                {
                    Console.WriteLine("Button Place Order is not present when it should be.");
                    string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                    extentTest.Log(LogStatus.Fail, "Test failed: Button Place Order is not present when it should be." + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                    Assert.Fail("Test failed: Button Place Order is not present when it should be.");
                }

                Thread.Sleep(5000);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine($"Test failed due to missing element: {e.Message}");
                if (extentTest != null)
                {
                    extentTest.Log(LogStatus.Fail, "Test failed due to missing element: " + e.Message);
                    extentTest.Log(LogStatus.Fail, extentTest.AddScreenCapture(ScreenShot("missing_element")));
                }
                Assert.Fail("Test failed due to missing element: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Test failed: {e.Message}");
                if (extentTest != null)
                {
                    extentTest.Log(LogStatus.Fail, "Test failed: " + e.Message);
                    extentTest.Log(LogStatus.Fail, extentTest.AddScreenCapture(ScreenShot("test_failure")));
                }
                Assert.Fail("Test failed: " + e.Message);
            }
        }


    }
}

