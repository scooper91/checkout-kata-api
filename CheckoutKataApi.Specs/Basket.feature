Feature: Basket
	In order to know how much I'm spending
	As a customer
	I want to be told the price of my basket

Scenario: Empty basket
	Given I have an empty basket
	When I check my basket
	Then the price should be 0

Scenario: Single item in basket
	Given I have a basket with item A in
	When I check my basket
	Then the price should be 50