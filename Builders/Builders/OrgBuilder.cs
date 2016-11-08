using System;
using System.Collections.Generic;
using Builders.Domain;

namespace Builders.Builders
{
    public class OrgBuilder
    {
        private readonly OrgStruct _orgStruct;
        private readonly Org _org;

        public OrgBuilder(OrgStruct orgStruct, Org org = null)
        {
            _orgStruct = orgStruct;
            _org = org;
        }

        public void HasChild(string shortName, params Action<OrgBuilder>[] builderActions)
        {
            var childOrg = new Org(shortName, _org);
            _orgStruct.Add(childOrg);
            var builder = new OrgBuilder(_orgStruct, childOrg);
            ExecuteActions(builder, builderActions);
        }

        private void ExecuteActions(OrgBuilder builder, IEnumerable<Action<OrgBuilder>> builderActions)
        {
            foreach (var buildAction in builderActions)
            {
                buildAction(builder);
            }
        }
    }
}