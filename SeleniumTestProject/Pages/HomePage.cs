using OpenQA.Selenium;

namespace RiverTestTestProject.Pages
{
    class HomePage
    {
        IWebDriver driver;
        LoginPage loginPage = null;
        public HomePage(IWebDriver pardriver)
        {
            driver = pardriver;
            loginPage = new LoginPage(driver);
        }


        // ui element
        public IWebElement btnAddToCart => driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket"));
        //public IWebElement btnRemoveFromCart=> driver.FindElement(By.Id("remove-sauce-labs-fleece-jacket"));


        //actions
        public void LaunchApplicationAndLogin()
        {
            loginPage.LaunchApplication("https://www.saucedemo.com");
            loginPage.Login("standard_user", "secret_sauce");
            loginPage.ClickLogin();
        }

        public void ClickAddToCartButton() => btnAddToCart.Click();

        public bool CheckBtnHasBeenChangedToRemove()
        {

            if (driver.FindElement(By.Id("remove-sauce-labs-fleece-jacket")) != null)
            {
                return true;
            }

            return false;
        }


    }
}
