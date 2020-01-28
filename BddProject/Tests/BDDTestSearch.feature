Feature: BDDTestSearch

@mytag
Scenario: Check search product
	Given I am on home page
	When I search for 'macbook'
	Then All results items contain 'macbook' in title
