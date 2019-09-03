using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.utils
{
    public class WebDriverFactory
    {
        public static IWebDriver Create()
        {
            var browserType = WebDriverSettingsReader.GetBrowserType();
            IWebDriver driver;
            Logger.Log("Creating web driver for " + browserType);
            switch (browserType)
            {
                case "Firefox":
                    //DesiredCapabilities capabilites = DesiredCapabilities.Firefox();
                    //var opts = new FirefoxOptions();
                    //opts.UseLegacyImplementation = true;
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    var options = new ChromeOptions();
                    options.AddArgument("start-maximized");
                    driver = new ChromeDriver();
                    break;
                case "IE":
                    var ieOptions = new InternetExplorerOptions
                    {
                        ForceCreateProcessApi = true,
                        BrowserCommandLineArguments = "-private"
                    };
                    driver = (IWebDriver)new InternetExplorerDriver(ieOptions);
                    break;
                default:
                    throw new InvalidOperationException("Unable to find driver for '" + browserType);
            }
            return driver;
        }
    }
}
