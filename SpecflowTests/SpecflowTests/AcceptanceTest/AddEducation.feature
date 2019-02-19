Feature: AddEducation
Scenario: Check if user is able to add their education details 
Given I clicked on the education tab under Profile page
When I add educational background details
Then that educational details should be displayed on my listings
