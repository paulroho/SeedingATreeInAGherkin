using SeedingATree.Domain;

namespace SeedingATree.Builders
{
    public class OrgUnitBuilder
    {
        private readonly OrgUnit _orgUnit;

        public OrgUnitBuilder(string shortName)
        {
            _orgUnit = new OrgUnit(shortName, "Long" + shortName, OrgUnitType.Normal);
        }

        public OrgUnitBuilder AsChildOf(OrgUnit parent)
        {
            _orgUnit.Parent = parent;
            return this;
        }

        public OrgUnit Build() => _orgUnit;
    }
}