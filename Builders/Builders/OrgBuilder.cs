using SeedingATree.Domain;

namespace SeedingATree.Builders
{
    public class OrgBuilder
    {
        private readonly Org _org;

        public OrgBuilder(string shortName)
        {
            _org = new Org(shortName, "Long" + shortName, OrgType.Normal);
        }

        public OrgBuilder AsChildOf(Org parent)
        {
            _org.Parent = parent;
            return this;
        }

        public Org Build() => _org;
    }
}