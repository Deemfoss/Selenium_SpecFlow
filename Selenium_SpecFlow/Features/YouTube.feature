Feature: Youtube
These scenarios exercise the functionality of the searching in YouToobe

@Positive
Scenario: (1.1_01) Verify the searching in YouTube works properly
	Given I have navigated to YouTube website
	And I have entered NBA as search keywords
	When I press the search button
	Then I should be navigate to search result page