Feature: BrowserLaunch

A short summary of the feature

@google
Scenario: Launch google application
	Given I have "google" url
	When I launch url in browser
	Then "google" application is launched

	@facebook
Scenario: Launch facebook application
	Given I have "facebook" url
	When I launch url in browser
	Then "facebook" application is launched

	@amazon
Scenario: Launch amazon application
	Given I have "amazon" url
	When I launch url in browser
	Then "amazon" application is launched
