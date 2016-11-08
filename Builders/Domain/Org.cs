namespace Builders.Domain
{
    public class Org
    {
        public Org(string shortName, string name, OrgType type, Org parent = null)
        {
            ShortName = shortName;
            Name = name;
            Type = type;
            Parent = parent;
        }


        public string ShortName { get; }
        public string Name { get; }
        public OrgType Type { get; }
        public Org Parent { get; }
    }

    public enum OrgType
    {
        Executive,
        Department,
        Normal,
    }
}