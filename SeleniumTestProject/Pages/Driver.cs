using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverTestTestProject.Pages
{
    public static class Driver
    {
        public static IWebDriver driver = new ChromeDriver(@"C:\Users\Sigmond\Documents\GitHub\SeleniumProject2\SpecflowNunitProject\SeleniumTestProject\Drivers\");
        

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
