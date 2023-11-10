Feature: Users

//@Author: Senzo Mbuzwa

@tag1
Scenario Outline: Add a new user
	Given that you are on the users page on the <browser> browser
	When you add new users and verify that the users has been successfully added to the list

Examples: 
	| browser |
	| chrome  |
