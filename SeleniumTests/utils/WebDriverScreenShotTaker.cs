using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SeleniumTests.utils
{
    public class WebDriverScreenShotTaker
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            var screehShot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = DateTime.Now.Ticks + ".png";
			var currentDir = GetCurrentDir();
            var filePath = Path.Combine(currentDir, DateTime.Now.Ticks + ".png");

            //screehShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);

            byte[] imageBytes = Convert.FromBase64String(screehShot.ToString());

            using (BinaryWriter bw = new BinaryWriter(new FileStream(filePath, FileMode.Append,
            FileAccess.Write)))
            {
                bw.Write(imageBytes);
                bw.Close();
            }
        }

		private static string GetCurrentDir() {
			string codeBase = Assembly.GetExecutingAssembly().Location;
			return Path.GetDirectoryName(codeBase);
		}
    }
}
