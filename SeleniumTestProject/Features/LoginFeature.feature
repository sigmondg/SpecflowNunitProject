Feature: LoginPage
	When entering the url provided , i should see the login details

@LoginPageScenarios
Scenario:Launch Application
	Given I am on saucedemo application
	Then I should see the Login Details


Scenario: Perform Login for SauceDemo Application
	Given I am on saucedemo application
	And I enter the following details
	| UserName | Password |
	|standard_user|secret_sauce|
	And i click the login button
	Then I should see the Shopping cart link

Scenario: Perform Login for SauceDemo with invalid Credentials
	Given I am on saucedemo application
	And I enter the following details
	| UserName | Password |
	| sigmond  | gatt     |
	And i click the login button
	Then i should not be logged in


