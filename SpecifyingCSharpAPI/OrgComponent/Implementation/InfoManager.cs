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

        public IList<Org> GetDirectChildren(Org org)
        {
            return _orgStructure.Orgs.Where(o => o.Parent == org).ToList();
        }

        public IList<Org> GetDirectChildren(string orgShortName)
        {
            return GetDirectChildren(_orgStructure[orgShortName]);
        }

        public IList<Org> GetAllChildren(Org org)
        {
            var orgs = _orgStructure.Orgs.Where(o => o.Parent == org).ToList();
            foreach (var o in orgs.ToList())
            {
                orgs.AddRange(GetAllChildren(o.ShortName));
            }
            return orgs;
        }

        public IList<Org> GetAllChildren(string orgShortName)
        {
            var org = _orgStructure[orgShortName];
            return GetAllChildren(org);
        }
    }
}