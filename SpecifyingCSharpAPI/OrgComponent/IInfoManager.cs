using System.Collections.Generic;
using SeedingATree.Domain;

namespace SpecifyingCSharpAPI.OrgComponent
{
    public interface IInfoManager
    {
        IList<Org> GetDirectChildren(string orgShortName);
        IList<Org> GetAllChildren(string orgShortName);
    }
}