Feature: CheckoutFeature
	Simple calculator for adding two numbers

@CheckoutFeature

Scenario: Select the cart and assert that the item is present than click checkout
	Given that I am logged in on saucedemo homepage and added an item to cart
	And i click on the cart button
	When validate that the item is in my cart
	Then i click checkout and check that i am on the first step of the checkout page.

Scenario: Input firstname, lastname, postcode then click continue
	Given that I am logged in on saucedemo homepage and added an item to cart
	And i click on the cart button
	And i click checkout
	And i fill up the detials
	| firstName | lastName | zipCode |
	| sigmond   | gatt     | "1234"    |
	Then i should click continue and see the second step of the checkout page

Scenario: assert that the values on the second step checkout page are correctly
	Given that I am logged in on saucedemo homepage and added an item to cart
	And i click on the cart button
	And i click checkout
	And i fill up the detials
         | firstName | lastName | zipCode |
         |sigmond    |gatt      |"1234"	  |
	And i click the continue button
	Then I need to check that the following values matches
	| itemTotal | tax  | total |
	| 49.99     | 4.00 | 53.99 |
	
Scenario: Click finish and verify that order has been dispatched 
	Given that I am logged in on saucedemo homepage and added an item to cart
	And i click on the cart button
	And i click checkout
	And i fill up the detials
         | firstName | lastName | zipCode |
         |sigmond    |gatt      |"1234"	  |
	And i click the continue button
	And i click finish to complete the checkout
	Then i should see a message which verifies my checkout.
