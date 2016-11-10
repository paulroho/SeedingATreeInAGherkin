using System;
using System.Collections.Generic;
using SeedingATree.Domain;

namespace SeedingATree.Builders
{
    public class OrgStructBuilder
    {
        private readonly OrgStruct _orgStruct = new OrgStruct();

        public OrgStruct OrgStruct(string shortName, params Action<OrgBuilder>[] builderActions)
        {
            var builder = new OrgBuilder(_orgStruct);
            builder.HasChild(shortName, builderActions);
            return _orgStruct;
        }

        public class OrgBuilder
        {
            private readonly OrgStruct _orgStruct;
            private readonly OrgUnit _orgUnit;

            public OrgBuilder(OrgStruct orgStruct, OrgUnit orgUnit = null)
            {
                _orgStruct = orgStruct;
                _orgUnit = orgUnit;
            }

            public void HasChild(string shortName, params Action<OrgBuilder>[] builderActions)
            {
                var childOrg = new OrgUnit(shortName, "Long" + shortName, OrgUnitType.Normal, _orgUnit);
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
}