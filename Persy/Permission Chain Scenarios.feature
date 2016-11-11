Feature: A permission chain can be expressed tersely

Scenario: Permission chain, all objects active
	Given there is a permission chain 'Ben (Domain\MyUser) --- Grp --- Pos - ad.grp.target'.

	Given there is a permission chain 'Ben (Domain\MyUser) --- Grp (INACTIVE) --- Pos - ad.grp.target'.
	
	Given there is a permission chain 'Ben (Domain\MyUser) xxx Grp            --- Pos - ad.grp.target'.
	
	Given there is a permission chain 'Ben (Domain\MyUser) xxx Grp (INACTIVE) --- Pos - ad.grp.target'.