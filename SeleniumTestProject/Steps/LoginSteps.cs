using NUnit.Framework;
using RiverTestTestProject.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RiverTestTestProject.Steps
{
    [Binding]
    public sealed class LoginSteps
    {

        LoginPage loginPage = new LoginPage(Driver.InitDriver());

        [Then(@"I should see the Login Details")]
        public void ThenIShouldSeeTheLoginDetails()
        {
            Assert.That(loginPage.AreLoginDetailsVisible(), Is.True);
            Driver.CloseDriver();

        }

        [Given(@"I am on saucedemo application")]
        public void GivenILaunchTheApplication()
        {

            loginPage.LaunchApplication("https://www.saucedemo.com");
        }

        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.Login((string)data.UserName, (string)data.Password);
        }

        [Given(@"i click the login button")]
        public void GivenIClickTheLoginButton()
        {
            loginPage.ClickLogin();
        }

        [Then(@"i should not be logged in")]
        public void ThenIShouldNotBeLoggedIn()
        {
            Assert.That(loginPage.isErrorContainerVisible(), Is.True);
            Driver.CloseDriver();
        }

        [Then(@"I should see the Shopping cart link")]
        public void ThenIShouldSeeTheShoppingCartLink()
        {
            Assert.That(loginPage.isInventoryVisible(), Is.True);
            Driver.CloseDriver();
        }

    }
}
