using OpenQA.Selenium;

namespace RiverTestTestProject.Pages
{
    class LoginPage
    {
        IWebDriver driver;


        public LoginPage(IWebDriver d)
        {
            this.driver = d;
        }
        // ui element
        public IWebElement txtUsername => driver.FindElement(By.Name("user-name"));
        public IWebElement txtPassword => driver.FindElement(By.Name("password"));
        public IWebElement btnLogin => driver.FindElement(By.Id("login-button"));
        public IWebElement InventoryList => driver.FindElement(By.ClassName("inventory_list"));
        public IWebElement txtErrorLoginContainer => driver.FindElement(By.ClassName("error-message-container"));


        //actions
        public void LaunchApplication(string base_url)
        {

            driver.Navigate().GoToUrl(base_url);
        }

        public bool AreLoginDetailsVisible()
        {
            if (txtPassword.Displayed && txtUsername.Displayed)
            {
                return true;
            }
            return false;
        }
        public void Login(string userName, string password)
        {
            txtUsername.SendKeys(userName);
            txtPassword.SendKeys(password);
        }

        public void ClickLogin() => btnLogin.Submit();

        public bool isInventoryVisible() => InventoryList.Displayed;

        public bool isErrorContainerVisible() => txtErrorLoginContainer.Displayed;

    }
}
