using NUnit.Framework;
using RiverTestTestProject.Pages;
using TechTalk.SpecFlow;

namespace RiverTestTestProject.Steps
{
    [Binding]
    public sealed class HomeSteps
    {

        LoginPage loginPage = new LoginPage(Driver.InitDriver());
        HomePage homePage = new HomePage(Driver.InitDriver());

        [Given(@"that I am logged in on saucedemo homepage")]
        public void GivenThatIAmLoggedInOnSaucedemoHomepage()
        {
            homePage.LaunchApplicationAndLogin();
        }

        [When(@"i click on the add to cart button")]
        public void GivenIClickOnTheAddToCartButton()
        {
            homePage.ClickAddToCartButton();
        }


        [Then(@"the button should be changed to remove item")]
        public void TheButtonShouldBeChangedToRemoveItem()
        {
            Assert.That(homePage.CheckBtnHasBeenChangedToRemove(), Is.True);
            Driver.CloseDriver();
        }

    }
}
