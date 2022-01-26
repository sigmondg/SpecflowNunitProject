using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverTestTestProject.Pages
{
    class CheckoutPage
    {
        IWebDriver driver;
        LoginPage loginPage = null;
   
        public CheckoutPage(IWebDriver pardriver)
        {
            driver = pardriver;
            loginPage = new LoginPage(driver);
            //homePage = new HomePage(driver);
        }

        public IWebElement btnCart => driver.FindElement(By.Id("shopping_cart_container"));
        public IWebElement txtFleeceJacket => driver.FindElement(By.Id("item_5_title_link"));
        public IWebElement btnCheckout => driver.FindElement(By.Id("checkout"));
        public IWebElement inptFirstName => driver.FindElement(By.Id("first-name"));
        public IWebElement inptLastName => driver.FindElement(By.Id("last-name"));
        public IWebElement inptZipCode => driver.FindElement(By.Id("postal-code"));
        public IWebElement btnContinue => driver.FindElement(By.Id("continue"));
        public IWebElement txtItemTotal => driver.FindElement(By.ClassName("summary_subtotal_label"));
        public IWebElement txtTax => driver.FindElement(By.ClassName("summary_tax_label"));
        public IWebElement txtTotal => driver.FindElement(By.ClassName("summary_total_label"));
        public IWebElement btnFinish => driver.FindElement(By.Id("finish"));
        public IWebElement txtOrderStatus => driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/span"));



        public void ClickCartButton() => btnCart.Click();

        public bool CheckIfItemIsValid() {

            if (txtFleeceJacket != null)
            {
                return true;
            }
            return false;
        }

        public void ClickBtnCheckout() => btnCheckout.Click();

        public String isUrlFirstStepValid(){return driver.Url;}

        public void FillCheckoutInformation(string firstName, string lastName,string zipCode) 
        {
            inptFirstName.SendKeys(firstName);
            inptLastName.SendKeys(lastName);
            inptZipCode.SendKeys(zipCode);
        }

        public void ClickbtnContinue() => btnContinue.Click();

        public String isUrlSecondStepValid() { return driver.Url;}

        public double returnItemTotal() => Convert.ToDouble(txtItemTotal.Text.Substring(txtItemTotal.Text.IndexOf('$')+1, txtItemTotal.Text.Length - (txtItemTotal.Text.IndexOf('$')+1))); 

        public double returnTax() =>  Convert.ToDouble(txtTax.Text.Substring(txtTax.Text.IndexOf('$') + 1, txtTax.Text.Length - (txtTax.Text.IndexOf('$') + 1)));

        public double returnTotal() => Convert.ToDouble(txtTotal.Text.Substring(txtTotal.Text.IndexOf('$') + 1, txtTotal.Text.Length - (txtTotal.Text.IndexOf('$') + 1)));
       
        public void clickBtnFinish() => btnFinish.Click();

        public string returnOrderStatus() => txtOrderStatus.Text.Substring(txtOrderStatus.Text.IndexOf(":") + 2, txtOrderStatus.Text.Length - (txtOrderStatus.Text.IndexOf(":") + 2));




    }
}
