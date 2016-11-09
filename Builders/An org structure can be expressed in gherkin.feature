Feature: An org structure can be expressed in gherkin

Scenario: Seed an org tree using a table with a row for each org and parent relation
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


Scenario: Seed an org tree using a table with a row for each org and column skipping
	Given I have the following levelled org structure
		| Level1 | Level2 | Level3   | Level4 |
		| Board  |        |          |        |
		|        | HOFin  |          |        |
		|        | HOTech |          |        |
		|        |        | ITInfra  |        |
		|        |        | SWDevSvc |        |
		|        |        |          | SWPmo  |
		|        |        |          | SWEng  |

	When I execute the specs

	# This is just an aweful hack to get this spec to work quickly.
	Then I get the correct organizations.


Scenario: Seed an org tree using a table with a row for each org and indendation
	Given I have the following intended org structure
		| Org at level |
		| Board        |
		| . HOFin      |
		| . HOTech     |
		| . . ITInfra  |
		| . . SWDevSvc |
		| . . . SWPmo  |
		| . . . SWEng  |

	When I execute the specs

	# This is just an aweful hack to get this spec to work quickly.
	Then I get the correct organizations.


Scenario: Seed an org tree using a multiline text with a row for each org and indendation with dots
	Given I have the following intended org structure as text
		"""
		Board       
		. HOFin     
		. HOTech    
		. . ITInfra 
		. . SWDevSvc
		. . . SWPmo 
		. . . SWEng 
		"""

	When I execute the specs

	# This is just an aweful hack to get this spec to work quickly.
	Then I get the correct organizations.


Scenario: Seed an org tree using a multiline text with a row for each org and indendation
	Given I have the following intended org structure as text
		"""
		Board       
		  HOFin     
		  HOTech    
		    ITInfra 
		    SWDevSvc
		      SWPmo 
		      SWEng 
		"""

	When I execute the specs

	# This is just an aweful hack to get this spec to work quickly.
	Then I get the correct organizations.
