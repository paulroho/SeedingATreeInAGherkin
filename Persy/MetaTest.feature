Feature: The permission chain steps do what they are supposed to do
	In order to avoid maintain the correct functionality of the step bindings for permission chains
	As a PERSY-developer
	I want to be sure that each step bindings does exactly what it is supposed to do.



Scenario: Permission chain: group is inactive
	Given there is a permission chain 'Ben1 (MyDomain\Ben1) --- Grp1 (INACTIVE) --- Pos1 - ad.group1'.

	When I execute the SpecFlow-specs

	Then the following objects of hard entities are available:
		| Type     | Name      | Active-State |
		| User     | Ben1      | active       |
		| Group    | Grp1      | inactive     |
		| Position | Pos1      | active       |
		| AD-Group | ad.group1 | active       |
	And the AD-group 'ad.group1' is assigned to the position 'Pos1'
	And the following objects of weak entities are available:
		| Type            | Object1 | Object2 | Active-State |
		| UserToGroup     | Ben1    | Grp1    | active       |
		| GroupToPosition | Grp1    | Pos1    | active       |

	And in the AD there is an AD-user 'MyDomain\Ben1' and the AD-group 'ad.group1'.
