Feature: Login

In order to verify that Login feature is behaving as expected
	as a quality engineer
		I want to design various scenarios that will fully exercise the login features

#Scenario: Verify that users are able to successfully login to their account
#	Given I launch the m and s site
#	And I click on signin button
#	And I confirm that i am on the login page
#	When I enter valid username into the username field
#	And I enter valid password into the password field
#	And I click on login button
#	Then I should be logged in to the application
#	Your email address or password is incorrect. Please try again. 

Background:
	Given User is already on the login page

Scenario: QQRisk-3654 Verify that users are able to successfully login to their account
	#Given User is already on the login page
	When User attempt to login with valid credential
	Then User should see a customise login welcome message to confirm that they have successfull been able to access their account

Scenario Outline: QQRisk-3655 Verify that unregistered users are not able to login to the application
	#Given User is already on the login page
	When User attempt to login with invalid credential
		| username   | password   |
		| <Username> | <Password> |
	Then User should be shown the error message "Your email address or password is incorrect. Please try again."

Examples:
	| Username                      | Password         |
	| Jennifer_chukwudum""yahoo.com | Jenny@m&s24      |
	| Jennifer_chukwudum@yahoo.co   | Jenny@m&s24      |
	| Jennifer_chukwudum@yahoo.com  | Jennyxxxxx@m&s24 |
