Feature: AddLanguage
Scenario: Check if user could able to add a language 
Given I clicked on the Language tab under Profile page
When I add a new language
Then that language should be displayed on my listings
	
Scenario: Check if user is able to delete a language
Given I clicked on the Language tab under Profile page
When I delete a language
Then that language should be removed from the listings

Scenario: Check if user is able to update a language
Given  I clicked on the Language tab under Profile page
When I update a language
Then that language should be updated in the listings

Scenario Outline: Check if user is able to add more than four languages
Given I clicked on the Language tab under Profile page
When I add a four new language with <language> and <level>
Then those <language> should be displayed on my listings
Examples: 
| language  | level          |
| English   | Fluent         |
| Tamil     | Conversational |
| Telugu    | Conversational |
| Malayalam | Basic          |


Scenario: Add a language which already exists with different level
Given I clicked on the Language tab under Profile page
When I add a language that already exists with different level
Then it should throw an error message 

Scenario: Add a language which already exists with same level
Given I clicked on the Language tab under Profile page
When I add a language that already exists with same level
Then it should throw an error message 
