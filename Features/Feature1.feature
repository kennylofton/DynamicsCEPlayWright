Feature: Feature1

Scenario: Create new contact with Tagged record
	Given I ahve logged into the system
	And I select the contact entity
	And I select to create a new contact
	And I provide the neccessary details
	And I save the contact 
	Then the new contact is created with the new tagged record
