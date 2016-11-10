CREATE TABLE OrgUnit
(
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	ShortName nvarchar(20) NOT NULL,
	Name nvarchar(100) NOT NULL,
	OrgUnitType int NOT NULL,
	Fk_IdParentOrgUnit uniqueidentifier NULL
)

ALTER TABLE OrgUnit
ADD FOREIGN KEY (Fk_IdParentOrgUnit)
REFERENCES OrgUnit (Id)

