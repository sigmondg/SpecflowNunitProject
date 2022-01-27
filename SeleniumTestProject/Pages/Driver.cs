using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace RiverTestTestProject.Pages
{
    public static class Driver
    {
        public static IWebDriver driver = new ChromeDriver(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\drivers\");


        public static IWebDriver InitDriver()
        {
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Close();
        }

    }
}
