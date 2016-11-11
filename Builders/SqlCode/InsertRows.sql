INSERT INTO dbo.OrgUnit (Id, ShortName, Name, OrgUnitType, Fk_IdParentOrgUnit)
   VALUES ('2EA2966F-64D1-4CA9-A87B-790F697E18B4', 'Board', 'Executive Board', 1, NULL)
INSERT INTO dbo.OrgUnit (Id, ShortName, Name, OrgUnitType, Fk_IdParentOrgUnit)
   VALUES ('2B70C1E0-54D8-4DFB-8C29-7050E80D63E9', 'HOFin', 'Head Office Finance', 2, '2EA2966F-64D1-4CA9-A87B-790F697E18B4')
INSERT INTO dbo.OrgUnit (Id, ShortName, Name, OrgUnitType, Fk_IdParentOrgUnit)
   VALUES ('1D34A69F-A2DF-407B-A0A1-6C912BCE86EC', 'FinContr', 'Finance Controlling', 3, '2B70C1E0-54D8-4DFB-8C29-7050E80D63E9')
INSERT INTO dbo.OrgUnit (Id, ShortName, Name, OrgUnitType, Fk_IdParentOrgUnit)
   VALUES ('01E28D9E-EED9-4A36-B586-BBAC9FC26E37', 'FinStrat', 'Finance Strategty', 3, '2B70C1E0-54D8-4DFB-8C29-7050E80D63E9')
INSERT INTO dbo.OrgUnit (Id, ShortName, Name, OrgUnitType, Fk_IdParentOrgUnit)
   VALUES ('9B2EB209-6486-4B8A-91B8-6A1706F91012', 'HOTech', 'Head Office Technology', 2, '2EA2966F-64D1-4CA9-A87B-790F697E18B4')
INSERT INTO dbo.OrgUnit (Id, ShortName, Name, OrgUnitType, Fk_IdParentOrgUnit)
   VALUES ('DF142721-993D-44EC-AF42-8995D70128A8', 'ITInfra', 'IT Infrastructure', 3, '9B2EB209-6486-4B8A-91B8-6A1706F91012')
INSERT INTO dbo.OrgUnit (Id, ShortName, Name, OrgUnitType, Fk_IdParentOrgUnit)
   VALUES ('12C970B9-C1AB-44FE-960A-1492FF104F0B', 'SWDevSvc', 'Software Development Services', 3, '9B2EB209-6486-4B8A-91B8-6A1706F91012')
INSERT INTO dbo.OrgUnit (Id, ShortName, Name, OrgUnitType, Fk_IdParentOrgUnit)
   VALUES ('DA1610C9-C8F7-4B23-AB77-FFE4D404DE04', 'SWPmo', 'Software Development PMO', 3, '12C970B9-C1AB-44FE-960A-1492FF104F0B')
INSERT INTO dbo.OrgUnit (Id, ShortName, Name, OrgUnitType, Fk_IdParentOrgUnit)
   VALUES ('BBD441A3-EE6F-4F87-BA34-8D102E03555A', 'SWEng', 'Software Development Engineering', 3, '12C970B9-C1AB-44FE-960A-1492FF104F0B')


--SELECT newid()
--DELETE FROM OrgUnit
SELECT * FROM OrgUnit ORDER BY Fk_IdParentOrgUnit
