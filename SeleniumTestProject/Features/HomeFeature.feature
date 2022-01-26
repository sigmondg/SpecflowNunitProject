Feature: HomeFeature
	Testing home features such as: adding products to card, checkout , input data in the chehout form and validation of cart items,dispatched status

@HomeFeautres
Scenario: Add the 'Sauce Labs Fleece Jacket' item to the cart
	Given that I am logged in on saucedemo homepage
	When i click on the add to cart button
	Then the button should be changed to remove item