Feature: AddDescription
Scenario: Check if user is able to add their description 
Given I clicked on description under Profile page
When I enter a brief decription about myself
Then the description should be displayed