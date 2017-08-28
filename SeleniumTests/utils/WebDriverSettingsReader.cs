using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeleniumTests.utils
{
    public class WebDriverSettingsReader
    {
        public static string GetBrowserType()
        {
            var file = getSettingsFilePath();
            var xel = XElement.Load(file);
            return xel.Element("browser").Element("type").Value;
        }
        public static string GetBaseUrl()
        {
            var file = getSettingsFilePath();
            var xel = XElement.Load(file);
            var url = xel.Element("url").Element("base").Value;
            return url;
        }
        private static string getSettingsFilePath()
        {
            // the settings file is at the same level as the executing assembly
            var settingsFileDir = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            var settingsFilePath = Path.Combine(settingsFileDir, "webDriverSettings.xml");
            return settingsFilePath;
        }
    }
}
