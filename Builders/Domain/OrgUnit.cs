namespace SeedingATree.Domain
{
    public class OrgUnit
    {
        public OrgUnit(string shortName, string name, OrgUnitType type, OrgUnit parent = null)
        {
            ShortName = shortName;
            Name = name;
            Type = type;
            Parent = parent;
        }


        public string ShortName { get; }
        public string Name { get; }
        public OrgUnitType Type { get; }
        public OrgUnit Parent { get; set; }
    }

    public enum OrgUnitType
    {
        Executive,
        Department,
        Normal,
    }
}