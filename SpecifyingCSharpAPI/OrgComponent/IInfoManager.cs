using System.Collections.Generic;
using SeedingATree.Domain;

namespace SpecifyingCSharpAPI.OrgComponent
{
    public interface IInfoManager
    {
        IList<OrgUnit> GetDirectChildren(OrgUnit orgUnit);
        IList<OrgUnit> GetDirectChildren(string orgUnitShortName);
        IList<OrgUnit> GetAllChildren(OrgUnit orgUnit, bool includeSelf = false);
        IList<OrgUnit> GetAllChildren(string orgUnitShortName, bool includeSelf = false);
    }
}