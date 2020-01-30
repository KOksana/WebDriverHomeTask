Feature: BDDTestSearch

Scenario: Check search product
	Given I am on home page
	When I search for 'macbook'
	Then All results items contain 'macbook' in title

Scenario: Search and check product details
	Given I am on home page
	When I search for 'TV'
	And I navigate to first product item
	Then Product info is the same as on search page

Scenario: Search product and check filter list
	Given I am on home page
	When I search for 'TV'
	Then I check filter list