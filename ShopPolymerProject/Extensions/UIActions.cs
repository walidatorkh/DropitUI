using System;
using System.Collections.Generic;
using DropitUI.ShopPolymerProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.WaitHelpers;

namespace DropitUI.ShopPolymerProject.Extensions
{
    class UIActions : CommonOps
    {
        public static void Click(IWebElement elem)
        {
            try
            {
                elem.Click();
                Console.WriteLine("Clicked successfully");
                extentTest.Log(LogStatus.Pass, "Clicked successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Click action failed, " + e.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "Click action failed: " + e.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw;
            }
        }

        public static void UpdateText(IWebElement elem, string text)
        {
            try
            {
                elem.SendKeys(text);
                Console.WriteLine("Text updated successfully");
                extentTest.Log(LogStatus.Pass, "Text updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Text update failed, " + e.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "Text update failed: " + e.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw;
            }

        }
        public static void UpdateDropDown(IWebElement elem, string text)
        {
            try
            {
                SelectElement dropDown = new SelectElement(elem);
                dropDown.SelectByText(text);
                Console.WriteLine("Drop Down updated successfully");
                extentTest.Log(LogStatus.Pass, "Drop Down updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Drop Down update failed, " + e.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "Drop Down update failed: " + e.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw;
            }

        }
        public static void UpdateDropDown(IWebElement elem, int index)
        {
            try
            {
                SelectElement dropDown = new SelectElement(elem);
                dropDown.SelectByIndex(index);
                Console.WriteLine("Drop Down updated successfully");
                extentTest.Log(LogStatus.Pass, "Drop Down updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Drop Down update failed, " + e.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "Drop Down update failed: " + e.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw;
            }

        }

        public static int GetListCount(IList<IWebElement> elems)
        {
            return elems.Count;
        }
        public static void SelectByText(IWebDriver driver, IWebElement element, string text)
        {
            try
            {
                SelectElement selectElement = new SelectElement(element);
                selectElement.SelectByText(text);
                Console.WriteLine($"Drop Down by text: {text} updated successfully");
                extentTest.Log(LogStatus.Pass, $"Drop Down by text: {text} updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Drop Down by text update failed, " + e.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "Drop Down by text update failed: " + e.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                throw;
            }
        }

        public static void ClickElement(IWebElement element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Validate that the element is clickable
                IWebElement clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(element));

                // Click the element
                clickableElement.Click();

                Console.WriteLine($"Click element: {clickableElement} succeeded");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Element is not clickable: {element}");
                extentTest.Log(LogStatus.Fail, "Verification failed, " + "WebDriverTimeoutException");
                throw; // Rethrow the exception to indicate failure
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while clicking element: {element}");
                Console.WriteLine($"Error message: {ex.Message}");
                extentTest.Log(LogStatus.Fail, $"Error message: {ex.Message}");
                throw; // Rethrow the exception to indicate failure
            }

        }

    }

}
