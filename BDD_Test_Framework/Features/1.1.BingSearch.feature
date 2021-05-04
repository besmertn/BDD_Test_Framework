

@F1234
Feature: 1. Bing Search
	As an simple user
	I want to use the Bing to search through the Internet
	So the Bing serach should work properly

@US12345_Version_1.0.0
@Scenario_1.1
@UserReq_URS001
Scenario: 1.1. When the user opens the Bing search page, then the search field and button are displayed
	Given the application is available
	When the user opens the Search page
	Then the "Search" field is displayed on the "Search" page
		And the "Search" button is displayed on the "Search" page

@US12345_Version_1.0.0
@Scenario_1.2
@UserReq_URS001
Scenario: 1.2. When the user types the text in the search field, then 8 search suggestions are displayed
	Given the application is available
		And the user is on the Search page
	When the user types "star" text in the Search field
	Then "8" search suggestions are displayed on the Search page

@US12345_Version_1.0.0
@Scenario_1.3
@UserReq_URS001
Scenario: 1.3. When the user types the text in the search field, then all search suggestions started from the typed text
	Given the application is available
		And the user is on the Search page
	When the user types "star" text in the Search field
	Then all search suggestions started from the text "star"

@US12345_Version_1.0.0
@Scenario_1.4
@UserReq_URS001
Scenario: 1.4. When the user initiates the search, then the 10 results are displayed on the Search Result page
	Given the application is available
		And the user is on the Search page
		And the search field containt the "star" text
	When the user clicks on the "Search" button on the "Search" page
	Then the "Result" list is displayed on the "Search Result" page
		And "10" search results are displayed on the Search Result page


