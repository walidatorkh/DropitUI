
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using RelevantCodes.ExtentReports.Model;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Xml;

namespace DropitUI.ShopPolymerProject.Utilities
{
    internal class CommonOps : Base
    {
        public class DataRetriever
        {
            private readonly string xmlFilePath;

            public DataRetriever(string xmlFilePath)
            {
                this.xmlFilePath = xmlFilePath;
            }

            public string GetData(string nodeName)
            {
                using (XmlReader reader = XmlReader.Create(xmlFilePath))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement() && reader.Name.Equals(nodeName, StringComparison.OrdinalIgnoreCase))
                        {
                            return reader.ReadElementContentAsString();
                        }
                    }
                }
                return "NULL";
            }
        }
        public static string GetData(string nodeName)
        {
            string xmlFilePath = @"C:\Automation\DropitUI\ShopPolymerProject\Configurations\data.xml";
            using (XmlReader reader = XmlReader.Create(xmlFilePath))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name.ToString().Equals(nodeName))
                            return reader.ReadString();
                    }
                }
            }
            return "NULL";
        }


        public static XmlDocument LoadXmlDocument()
        {
            string filePath = @"C:\Automation\DropitUI\ShopPolymerProject\Configurations\data.xml";
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filePath);

                // Check if the document is loaded and has a root element
                if (xmlDoc.DocumentElement == null)
                {
                    throw new InvalidOperationException("The XML document is empty.");
                }
            }
            catch (XmlException ex)
            {
                throw new InvalidOperationException("Failed to load the XML document.", ex);
            }

            return xmlDoc;
        }

        public static XmlNode SelectSingleNode(XmlDocument xmlDoc, string xpath)
        {
            XmlNode node = xmlDoc.SelectSingleNode(xpath);
            if (node == null)
            {
                throw new InvalidOperationException($"Node not found for XPath: {xpath}");
            }
            return node;
        }


        public void InitBrowser(string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    {
                        driver = new ChromeDriver();
                        break;
                    }
                case "firefox":
                    {
                        driver = new FirefoxDriver();
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Browser not supported");
                    }
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(GetData("URL"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(GetData("TIME_OUT")));
        }


        public static IWebElement FindElementInShadowDom(IWebDriver driver, string shadowHostCSS, string shadowElementCssSelector, int timeoutInSeconds = 20)
        {
            // Step 1: Find the shadow DOM host
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            IWebElement shadowHost = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(shadowHostCSS)));

            // Step 2: Run JavaScript to access the shadow root and find the element inside it
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string script = @"
            return arguments[0].shadowRoot.querySelector(arguments[1]);
        ";
            IWebElement shadowElement = (IWebElement)js.ExecuteScript(script, shadowHost, shadowElementCssSelector);

            //Step 3: Check if element is found inside shadow DOM
            if (shadowElement == null)
            {
                throw new NoSuchElementException("Element inside shadow DOM not found.");
            }

            return shadowElement;
        }


        public static IWebElement FindSecondElementInShadowDom(IWebDriver driver, string shadowHostCSS, string shadowElementCssSelector, int timeoutInSeconds = 20)
        {
            // Step 1: Find the shadow host
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            IWebElement shadowHost = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(shadowHostCSS)));

            // Step 2: Execute JavaScript to access the shadow root and find the element inside it
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string script = @"
        const shadowHost = arguments[0];
        const shadowRoot = shadowHost.shadowRoot || shadowHost.attachShadow({ mode: 'open' });
        return shadowRoot.querySelector(arguments[1]);
    ";
            IWebElement shadowElement = (IWebElement)js.ExecuteScript(script, shadowHost, shadowElementCssSelector);

            // Step 3: Check if the element is found inside the shadow DOM
            if (shadowElement == null)
            {
                throw new NoSuchElementException("Element inside the shadow DOM was not found.");
            }

            return shadowElement;
        }

        public static List<IWebElement> GetElementsFromNestedShadowDom(IWebDriver driver, string[] shadowHostCSSSelectors, string finalElementCssSelector, int timeoutInSeconds = 20)
        {
            ShadowRoot currentShadowRoot = null;

            foreach (string shadowHostCSS in shadowHostCSSSelectors)
            {
                currentShadowRoot = GetShadowRoot(driver, shadowHostCSS, currentShadowRoot, timeoutInSeconds);
            }

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            ReadOnlyCollection<IWebElement> elements = (ReadOnlyCollection<IWebElement>)js.ExecuteScript(
                "return arguments[0].querySelectorAll(arguments[1]);",
                currentShadowRoot,
                finalElementCssSelector
            );

            if (elements == null || elements.Count == 0)
            {
                throw new NoSuchElementException("Elements inside shadow DOM not found.");
            }

            return new List<IWebElement>(elements);
        }


        public static IWebElement FindNthElementInShadowDom(IWebDriver driver, string shadowHostCSS, string shadowListCSS, string shadowItemCSS, int index, int timeoutInSeconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement shadowHost = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(shadowHostCSS)));
            ISearchContext shadowRoot1 = shadowHost.GetShadowRoot();
            IWebElement shadowList = shadowRoot1.FindElement(By.CssSelector(shadowListCSS));
            ISearchContext shadowRoot2 = shadowList.GetShadowRoot();
            var items = shadowRoot2.FindElements(By.CssSelector(shadowItemCSS));
            if (index < 0 || index >= items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is out of range of elements..");
            }

            return items[index];
        }

        public static ShadowRoot GetShadowRoot(IWebDriver driver, string cssSelector, ShadowRoot parentShadowRoot = null, int timeoutInSeconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            IWebElement shadowHost;

            if (parentShadowRoot == null)
            {
                shadowHost = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
            }
            else
            {
                shadowHost = wait.Until(drv => parentShadowRoot.FindElement(By.CssSelector(cssSelector)));
            }

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return (ShadowRoot)js.ExecuteScript("return arguments[0].shadowRoot;", shadowHost);
        }


        // Example implementation of GetShadowRoot
        public ISearchContext GetShadowRoot(IWebElement element)
        {
            return (ISearchContext)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].shadowRoot", element);
        }



        [OneTimeSetUp]
        public void LoadDriver()
        {
            InitBrowser(GetData("BROWSER_TYPE"));
            ManagePages.InitElements();
            InitReport();
        }



        [OneTimeTearDown]
        public void UnloadDriver()
        {
            extent.Flush();
            extent.Close();
            driver.Quit();
        }

        [SetUp]
        public void BeforeMethod()
        {
            string testName = TestContext.CurrentContext.Test.Name.Split('_')[0];
            string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
            extentTest = extent.StartTest(testName, testDescription);
        }

        [TearDown]
        public void AfterMethod()
        {
            extent.EndTest(extentTest);
        }

        public static void InitReport()
        {
            if (!Directory.Exists(GetData("REPORT_FILE_PATH") + timeStamp))
            {
                Directory.CreateDirectory(GetData("REPORT_FILE_PATH") + timeStamp);
            }
            extent = new ExtentReports(GetData("REPORT_FILE_PATH") + timeStamp + GetData("REPORT_FILE_NAME"));
        }

        public static string ScreenShot(string testDescription)
        {
            try
            {
                // Standardized timestamp format
                // string timeStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string reportPath = (GetData("REPORT_FILE_PATH") + timeStamp);
                string location = $"{reportPath} screen_{timeStamp}_{testDescription}.png";

                // Capture the screenshot
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(location);

                Console.WriteLine($"Screenshot saved at: {location}");
                return location;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while taking a screenshot: {ex.Message}");
                return null;
            }
        }
    }
}

