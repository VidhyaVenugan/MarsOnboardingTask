Feature: AddSkills
Scenario: Check if user is able to add a skill 
Given I clicked on the skills tab under Profile page
When I add a new skill
Then that skill should be displayed on my listings
