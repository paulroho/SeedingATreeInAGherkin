using SeedingATree.Domain;

namespace SpecifyingCSharpAPI.OrgComponent.Implementation
{
    public class OrgContext : IOrgContext
    {
        public OrgStruct OrgStructure { get; set; }
    }
}