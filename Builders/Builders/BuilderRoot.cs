namespace SeedingATree.Builders
{
    public class BuilderRoot
    {
        public static BuilderRoot A => new BuilderRoot();

        public OrgUnitBuilder OrgUnit(string shortName)
        {
            return new OrgUnitBuilder(shortName);
        }
    }
}