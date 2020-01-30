Feature: Citrus home page search functionality

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

Scenario: Check navigation to subcatalog
	Given I am on home page
	When I navigate to catalog 'Телевизоры, фото, видео', subcatalog 'LG'
	Then All navigation results items contain 'LG' in title