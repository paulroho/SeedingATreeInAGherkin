Feature: Querying the Org structure using the APIs provided by the InfoManager

Background:
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


Scenario: Querying the direct children of an org unit using the method InfoManager.GetDirectChildren(OrgUnit orgUnit)

	Given for each org unit I have an OrgUnit object named orgUnit.Shortname

	When I call `GetDirectChildren(HOTech)`

	Then I get the org units
		| Org Unit |
		| ITInfra  |
		| SWDevSvc |


Scenario: Querying the direct children of an org unit using the method InfoManager.GetDirectChildren(string orgUnitShortName)

	When I call `GetDirectChildren("HOTech")`

	Then I get the org units
		| Org Unit |
		| ITInfra  |
		| SWDevSvc |


Scenario: Querying all children of an org unit using the method InfoManager.GetAllChildren(OrgUnit orgUnit)

	Given for each org unit I have an OrgUnit object named orgUnit.Shortname

	When I call `GetAllChildren(HOTech)`

	Then I get the org units
		| Org Unit |
		| ITInfra  |
		| SWDevSvc |
		| SWPmo    |
		| SWEng    |


Scenario: Querying all children of an org unit using the method InfoManager.GetAllChildren(OrgUnit orgUnit, bool includeSelf)

	Given for each org unit I have an OrgUnit object named orgUnit.Shortname

	When I call `GetAllChildren(HOTech, includeSelf:true)`

	Then I get the org units
		| Org Unit |
		| HOTech   |
		| ITInfra  |
		| SWDevSvc |
		| SWPmo    |
		| SWEng    |


Scenario: Querying all the children of an org unit using the method InfoManager.GetAllChildren(string orgUnitShortName)

	When I call `GetAllChildren("HOTech")`

	Then I get the org units
		| Org Unit |
		| ITInfra  |
		| SWDevSvc |
		| SWPmo    |
		| SWEng    |


Scenario: Querying all the children of an org unit using the method InfoManager.GetAllChildren(string orgUnitShortName, bool includeSelf)

	When I call `GetAllChildren("HOTech", includeSelf:true)`

	Then I get the org units
		| Org Unit |
		| HOTech   |
		| ITInfra  |
		| SWDevSvc |
		| SWPmo    |
		| SWEng    |
