@featureTag1
Feature: FeaturesSet01
	Features set 01

@fs102
Scenario: C102-Contact Us
	Given I run test 'C102'
	When I click the link
	Then the information is displayed

@fs103
Scenario: C103-Products
	Given I run test 'C103'
	When I click the link
	Then the information is displayed

@fs101
Scenario: C101-About Us
	Given I run test 'C101'
	When I click the link
	Then the information is displayed
