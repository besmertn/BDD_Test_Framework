Feature: 1.1. Bing Serach
	As an simple user
	I want to use the Bing to search through the Internet
	So the Bing serach should work properly


Scenario: 1.1. When the user opens the Bing main page, then the search field is displayed
	Given the application is available
	When the user opens the Search page
	Then the "Search" field is displayed on the "Search" page