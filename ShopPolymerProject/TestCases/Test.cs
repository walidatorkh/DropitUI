using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Zopa(string[] args)
    {
        // Initialize Chrome driver
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--disable-extensions");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--no-sandbox");
        IWebDriver driver = new ChromeDriver(options);

        try
        {
            // Open the URL
            string url = "https://shop.polymer-project.org/list/ladies_tshirts";
            driver.Navigate().GoToUrl(url);

            // Wait for the page to load
            System.Threading.Thread.Sleep(5000); // Adjust as needed

            // Execute JavaScript to access shadow DOM and retrieve the desired element
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string script = @"
                var host = document.querySelector('shop-app');
                var list = host.shadowRoot.querySelector('shop-list[name='list']').shadowRoot.querySelectorAll('li > a');
                return list[17].innerText;";

            string elementText = (string)js.ExecuteScript(script);

            // Print the text of the desired element
            Console.WriteLine("Text of element 18 from the list: " + elementText);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            // Close the browser
            driver.Quit();
        }
    }
}
