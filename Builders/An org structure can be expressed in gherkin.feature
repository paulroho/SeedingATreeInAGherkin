Feature: An org structure can be expressed in gherkin

Scenario: Seed a org tree using a table with a row for each org and parent relation
	Given I have the following organizations
		| Name     | Parent   |
		| Board    |          |
		| HOFin    | Board    |
		| HOTech   | Board    |
		| ITInfra  | HOTech   |
		| SWDevSvc | HOTech   |
		| SWPmo    | SWDevSvc |
		| SWEng    | SWDevSvc |

	When I execute the specs

	# This is just an aweful hack to get this spec to work quickly.
	Then I get the correct organizations.
