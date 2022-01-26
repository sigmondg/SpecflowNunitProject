using NUnit.Framework;
using RiverTestTestProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RiverTestTestProject.Steps
{
    [Binding]
    public sealed class CheckoutSteps
    {
        //init classes

        LoginPage loginPage = new LoginPage(Driver.InitDriver());
        HomePage homePage = new HomePage(Driver.InitDriver());
        CheckoutPage checkoutPage = new CheckoutPage(Driver.InitDriver());
        [Given(@"that I am logged in on saucedemo homepage and added an item to cart")]
        public void GivenThatIAmLoggedInOnSaucedemoHomepageAndAddedAnItemToCart()
        {
            
            homePage.LaunchApplicationAndLogin();
            homePage.ClickAddToCartButton();
        }

        [Given(@"i click on the cart button")]
        public void GivenIClickOnTheCartButton()
        {

            checkoutPage.ClickCartButton();
        }

        [When(@"validate that the item is in my cart")]
        public void WhenValidateThatTheItemIsInMyCart()
        {
            Assert.That(checkoutPage.CheckIfItemIsValid(), Is.True);
        }

        [Then(@"i click checkout and check that i am on the first step of the checkout page\.")]
        public void ThenIClickCheckoutAndCheckThatIAmOnTheFirstStepOfTheCheckoutPage_()
        {
            checkoutPage.ClickBtnCheckout();
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-one.html", checkoutPage.isUrlFirstStepValid());
            Driver.CloseDriver();
        }

        [Given(@"i click checkout")]
        public void GivenIClickCheckout()
        {
            checkoutPage.ClickBtnCheckout();
        }

        [Given(@"i fill up the detials")]
        public void GivenIFillUpTheDetials(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            checkoutPage.FillCheckoutInformation((string)data.firstName,(string)data.lastName,(string)data.zipCode);
        }

        [Then(@"i should click continue and see the second step of the checkout page")]
        public void ThenIShouldClickContinueAndSeeTheSecondStepOfTheCheckoutPage()
        {
            checkoutPage.ClickbtnContinue();
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-two.html", checkoutPage.isUrlSecondStepValid());
            Driver.CloseDriver();
            

        }

        [Given(@"i click the continue button")]
        public void GivenIClickTheContinueButton()
        {
            checkoutPage.ClickbtnContinue();
        }

        [Then(@"I need to check that the following values matches")]
        public void ThenINeedToCheckThatTheFollowingValuesMatches(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            Assert.AreEqual(data.itemTotal,checkoutPage.returnItemTotal());
            Assert.AreEqual(data.tax, checkoutPage.returnTax());
            Assert.AreEqual(data.total, checkoutPage.returnTotal());
            Driver.CloseDriver();
        }

       

        [Given(@"i click finish to complete the checkout")]
        public void GivenIClickFinishToCompleteTheCheckout()
        {
            checkoutPage.clickBtnFinish();
        }

        [Then(@"i should see a message which verifies my checkout\.")]
        public void ThenIShouldSeeAMessageWhichVerifiesMyCheckout_()
        {
            Assert.AreEqual("COMPLETE!",checkoutPage.returnOrderStatus());
            Driver.CloseDriver();
        }

        //need to test it out.
        //[AfterScenario("CheckoutFeature")]
        //public void AfterScenario() 
        //{
        //    Driver.CloseDriver();
        //}
    }
}
