using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumTest
    {
        private IWebDriver driver;
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = WebDriverFactory.Create();
            baseURL = WebDriverSettingsReader.GetBaseUrl();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Close();
                driver.Quit();
            }
            catch (Exception ex)
            {
                Logger.Log("Error closing " + WebDriverSettingsReader.GetBrowserType() + " driver, ex: " + ex.Message);
            }
        }

        [Test]
        [Category("Cheese")]
        public void Assert_Cheese_Search1()
        {
            Logger.Log("Navigating to page " + baseURL);
            driver.Navigate().GoToUrl(baseURL);

            // Find the text input element by its name
            IWebElement query = driver.FindElement(By.Name("q"));

            // Enter something to search for
            query.SendKeys("Cheese");

            // Now submit the form. WebDriver will find the form for us from the element
            query.Submit();

            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 10 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.Title.ToLower().StartsWith("cheese"); });

            // Should see: "Cheese - Google Search"
            //System.Console.WriteLine("Page title is: " + driver.Title);
            Assert.IsTrue(driver.Title == "Cheese - Google Search");

            // take a snapshot
            WebDriverScreenShotTaker.TakeScreenshot(driver);
        }


        [Test]
        [Category("Ham")]
        public void Assert_Ham_Search()
        {
            Logger.Log("Navigating to page " + baseURL);
            driver.Navigate().GoToUrl(baseURL);

            // Find the text input element by its name
            IWebElement query = driver.FindElement(By.Name("q"));

            // Enter something to search for
            query.SendKeys("Ham");

            // Now submit the form. WebDriver will find the form for us from the element
            query.Submit();

            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 10 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.Title.ToLower().StartsWith("ham"); });

            // Should see: "Ham - Google Search"
            //System.Console.WriteLine("Page title is: " + driver.Title);
            Assert.IsTrue(driver.Title == "Ham - Google Search");

            // take a snapshot
            WebDriverScreenShotTaker.TakeScreenshot(driver);
        }

        
    }
}
