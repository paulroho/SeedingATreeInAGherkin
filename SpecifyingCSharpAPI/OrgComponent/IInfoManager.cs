using System.Collections.Generic;
using SeedingATree.Domain;

namespace SpecifyingCSharpAPI.OrgComponent
{
    public interface IInfoManager
    {
        IList<Org> GetDirectChildren(Org org);
        IList<Org> GetDirectChildren(string orgShortName);
        IList<Org> GetAllChildren(Org org);
        IList<Org> GetAllChildren(string orgShortName);
    }
}