using SeedingATree.Domain;

namespace SpecifyingCSharpAPI.OrgComponent
{
    public interface IOrgContext
    {
        OrgStruct OrgStructure { get; }
    }
}