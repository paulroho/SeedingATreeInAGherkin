using SeedingATree.Domain;
using SpecifyingCSharpAPI.OrgComponent.Implementation;

namespace SpecifyingCSharpAPI.OrgComponent
{
    public static class Facade
    {
        public static IInfoManager GetInfoManager(IOrgContext context)
        {
            return new InfoManager(context);
        }

        public static IOrgContext CreateOrgContext(OrgStruct orgStruct)
        {
            return new OrgContext {OrgStructure = orgStruct};
        }
    }
}