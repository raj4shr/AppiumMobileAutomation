Feature: Appium Automation
Mobile automation of messages app for Pixel 4 API 30

Background: App is open
	Given Message app is open

Scenario: Send a new message
	
	When User clicks on new message
	And  User selects a '<Contact>'
	And User enters a '<Message>' and clicks send
	Then The message is sent succesfully

	Examples: 
	| Contact   | Message                                           |
	| 021111111 | This is a data driven mobile automation message 1 |
	| 022222222 | This is a data driven mobile automation message 2 |

Scenario Outline: Delete a Message Thread

	When User clicks on the '<Contact>' message thread
	And clicks on more opens
	And clicks on delete
	Then The message thread should be deleted successfully

	Examples: 
	| Contact   |
	| 021111111 |
	| 022222222 |

Scenario: Send a new message to invalid number

	When User clicks on new message
	And  User selects an invalid '<Contact>'
	Then The message is not sent succesfully

	Examples: 
	| Contact           | Message                                           |
	| Invalid123456     | This is a data driven mobile automation message 1 |
	| invalid@gmail.com | This is an Invalid Message                        |
