using System.Collections.Generic;
using System.Linq;
using SeedingATree.Domain;

namespace SpecifyingCSharpAPI.OrgComponent.Implementation
{
    public class InfoManager : IInfoManager
    {
        private readonly IOrgContext _context;
        private readonly OrgStruct _orgStructure;

        public InfoManager(IOrgContext context)
        {
            _context = context;
            _orgStructure = context.OrgStructure;
        }

        public IList<OrgUnit> GetDirectChildren(OrgUnit orgUnit)
        {
            return _orgStructure.OrgUnits.Where(ou => ou.Parent == orgUnit).ToList();
        }

        public IList<OrgUnit> GetDirectChildren(string orgUnitShortName)
        {
            return GetDirectChildren(_orgStructure[orgUnitShortName]);
        }

        public IList<OrgUnit> GetAllChildren(OrgUnit orgUnit)
        {
            var orgUnits = _orgStructure.OrgUnits.Where(ou => ou.Parent == orgUnit).ToList();
            foreach (var ou in orgUnits.ToList())
            {
                orgUnits.AddRange(GetAllChildren(ou.ShortName));
            }
            return orgUnits;
        }

        public IList<OrgUnit> GetAllChildren(string orgUnitShortName)
        {
            var orgUnit = _orgStructure[orgUnitShortName];
            return GetAllChildren(orgUnit);
        }
    }
}