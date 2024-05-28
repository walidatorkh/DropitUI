using DropitUI.ShopPolymerProject.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropitUI.ShopPolymerProject.Utilities
{
    internal class Base
    {
        protected static IWebDriver driver;
        protected static WebDriverWait wait;
        protected static IWebElement shadowHost;
        protected static ExtentReports extent;
        protected static ExtentTest extentTest;
        protected static string timeStamp = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd_HH-mm-ss");

        // Page Objects
        protected static Items items;
        protected static ShoppingCart shoppingCart;
        protected static TopMenu topMenu;
        // protected static SortDisplay sortDisplay;
        protected static Checkout checkout;
    }
}
