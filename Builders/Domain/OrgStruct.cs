using System;
using System.Collections.Generic;

namespace SeedingATree.Domain
{
    public class OrgStruct
    {
        private readonly Dictionary<string, Org> _orgs = new Dictionary<string, Org>();

        public void Add(Org org)
        {
            _orgs.Add(org.ShortName, org);
        }

        public Org this[string name]
        {
            get
            {
                Org org;
                if (!_orgs.TryGetValue(name, out org))
                    throw new ArgumentOutOfRangeException(nameof(name), name, $"There is no Org namend \"{name}\".");
                return _orgs[name];
            }
        }
    }
}