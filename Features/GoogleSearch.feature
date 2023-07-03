Feature: GoogleSearch



@GoogleSearchTesting
Scenario: Google 
	Given go to link adress "https://www.google.com.tr/"
	When click the search "Nasa"
	And click the web adress 
	Then click the moontomars
	