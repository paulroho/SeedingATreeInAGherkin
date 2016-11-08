namespace Builders.Domain
{
    public class Org
    {
        public Org(string shortName, Org parent = null)
        {
            Parent = parent;
            ShortName = shortName;
        }

        public string ShortName { get; }
        public Org Parent { get; }
    }
}