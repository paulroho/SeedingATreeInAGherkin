CREATE TABLE Org
(
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	ShortName nvarchar(20) NOT NULL,
	Name nvarchar(100) NOT NULL,
	OrgType int NOT NULL,
	Fk_IdParentOrg uniqueidentifier NULL
)

ALTER TABLE Org
ADD FOREIGN KEY (Fk_IdParentOrg)
REFERENCES Org (Id)

