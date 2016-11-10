Feature: Querying the Org structure using the APIs provided by the InfoManager

Background:
	Given I have the following intended org structure as text indenting by '-> '
		"""
		Board       
		-> HOFin     
		-> HOTech    
		   -> ITInfra 
		   -> SWDevSvc
		      -> SWPmo 
		      -> SWEng 
		"""


Scenario: Querying the direct children of an org unit using the method InfoManager.GetDirectChildren(OrgUnit orgUnit)

	Given for each org unit I have an OrgUnit object named orgUnit.Shortname

	When I call GetDirectChildren(HOTech)

	Then I get the org units
		| Org Unit |
		| ITInfra  |
		| SWDevSvc |
