using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.utils
{
    public class WebDriverScreenShotTaker
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            var screehShot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = DateTime.Now.Ticks + ".png";
            //fileName = Path.Combine(@"C:\Users\Jorge\Pictures", DateTime.Now.Ticks + ".png");

            //screehShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);

            byte[] imageBytes = Convert.FromBase64String(screehShot.ToString());

            using (BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Append,
            FileAccess.Write)))
            {
                bw.Write(imageBytes);
                bw.Close();
            }
        }
    }
}
