Feature: Feature2
	Process a lead

Scenario: Process a lead
	Given I am logged in to the sales app
	And I select the leads entity
	And I select an existing leads
	And I progress the lead to the close stage of the BPF
	When I selec to close the lead as a win
	Then the status of the record changes to read only
