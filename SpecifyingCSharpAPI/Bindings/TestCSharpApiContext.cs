using System.Collections.Generic;
using SeedingATree.Bindings;
using SeedingATree.Domain;
using SpecifyingCSharpAPI.OrgComponent;
using SpecifyingCSharpAPI.OrgComponent.Implementation;

namespace SpecifyingCSharpAPI.Bindings
{
    public class TestCSharpApiContext : OrgBindingContext
    {
        public IInfoManager GetInfoManager()
        {
            var orgContext = new OrgContext {OrgStructure = OrgStruct};
            return Facade.GetInfoManager(orgContext);
        }

        public IList<OrgUnit> ResultOrgUnits { get; set; }
    }
}