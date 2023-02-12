using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeFinancas.BDD.Helpers
{
    public static class TestHelper
    {

        public static string? BASE_URL => @"http://centraldefinancascoti.azurewebsites.net/";

        public static void CreateScreeShot(WebDriver driver, string fileName)
        {
            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            screenShot.SaveAsFile($"c:\\temp\\{fileName}.png", ScreenshotImageFormat.Png);
        }

    }
}
