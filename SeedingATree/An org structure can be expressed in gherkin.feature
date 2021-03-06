﻿Feature: An org structure can be expressed in gherkin

Scenario: Seed an org tree using a table with a row for each org unit and parent relation
	Given I have the following org units
		| Name     | Parent   |
		| Board    |          |
		| HOFin    | Board    |
		| FinContr | HOFin    |
		| FinStrat | HOFin    |
		| HOTech   | Board    |
		| ITInfra  | HOTech   |
		| SWDevSvc | HOTech   |
		| SWPmo    | SWDevSvc |
		| SWEng    | SWDevSvc |

	When I execute the specs

	# This is just an aweful hack to get this spec to work quickly.
	Then I get the correct org units.


Scenario: Seed an org tree using a table with a row for each org unit and column skipping
	Given I have the following levelled org structure
		| Level1 | Level2 | Level3   | Level4 |
		| Board  |        |          |        |
		|        | HOFin  |          |        |
		|        |        | FinContr |        |
		|        |        | FinStrat |        |
		|        | HOTech |          |        |
		|        |        | ITInfra  |        |
		|        |        | SWDevSvc |        |
		|        |        |          | SWPmo  |
		|        |        |          | SWEng  |

	When I execute the specs

	# This is just an aweful hack to get this spec to work quickly.
	Then I get the correct org units.


Scenario: Seed an org tree using a table with a row for each org unit and indentation
	Given I have the following intended org structure
		| Org unit at level |
		| Board             |
		| . HOFin           |
		| . . FinContr      |
		| . . FinStrat      |
		| . HOTech          |
		| . . ITInfra       |
		| . . SWDevSvc      |
		| . . . SWPmo       |
		| . . . SWEng       |

	When I execute the specs

	# This is just an aweful hack to get this spec to work quickly.
	Then I get the correct org units.


Scenario: Seed an org tree using a multiline text with a row for each org unit and indentation with dots
	Given I have the following intended org structure as text
		"""
		Board       
		. HOFin     
		. . FinContr
		. . FinStrat
		. HOTech    
		. . ITInfra 
		. . SWDevSvc
		. . . SWPmo 
		. . . SWEng 
		"""

	When I execute the specs

	# This is just an aweful hack to get this spec to work quickly.
	Then I get the correct org units.


Scenario: Seed an org tree using a multiline text with a row for each org unit and indentation
	Given I have the following intended org structure as text
		"""
		Board       
		  HOFin     
		    FinContr
		    FinStrat
		  HOTech    
		    ITInfra 
		    SWDevSvc
		      SWPmo 
		      SWEng 
		"""

	When I execute the specs

	# This is just an aweful hack to get this spec to work quickly.
	Then I get the correct org units.


Scenario: Seed an org tree using a multiline text with a row for each org unit and indentation with arrows
	Given I have the following intended org structure as text indenting by '-> '
		"""
		Board       
		-> HOFin     
		   -> FinContr
		   -> FinStrat
		-> HOTech    
		   -> ITInfra 
		   -> SWDevSvc
		      -> SWPmo 
		      -> SWEng 
		"""

	When I execute the specs

	# This is just an aweful hack to get this spec to work quickly.
	Then I get the correct org units.