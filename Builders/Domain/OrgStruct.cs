using System;
using System.Collections.Generic;

namespace SeedingATree.Domain
{
    public class OrgStruct
    {
        public OrgStruct()
        {
            Orgs = new Dictionary<string, Org>();
        }

        public Dictionary<string, Org> Orgs { get; }

        public void Add(Org org)
        {
            Orgs.Add(org.ShortName, org);
        }

        public Org this[string name]
        {
            get
            {
                Org org;
                if (!Orgs.TryGetValue(name, out org))
                    throw new ArgumentOutOfRangeException(nameof(name), name, $"There is no Org namend \"{name}\".");
                return Orgs[name];
            }
        }
    }
}