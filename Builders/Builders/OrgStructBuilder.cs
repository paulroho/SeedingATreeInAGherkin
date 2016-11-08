using System;
using Builders.Domain;

namespace Builders.Builders
{
    public class OrgStructBuilder
    {
        private readonly OrgStruct _orgStruct = new OrgStruct();

        public OrgStruct OrgStruct(string name, params Action<OrgBuilder>[] builderActions)
        {
            var builder = new OrgBuilder(_orgStruct);
            builder.HasChild(name, builderActions);
            return _orgStruct;
        }
    }
}