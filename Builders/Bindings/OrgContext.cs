using System.Collections.Generic;
using SeedingATree.Domain;

namespace SeedingATree.Bindings
{
    public class OrgContext
    {
        public Dictionary<string, Org> Orgs { get; set; }
    }
}