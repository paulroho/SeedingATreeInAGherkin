namespace Builders.Domain
{
    public class Org
    {
        public Org(string name, Org parent = null)
        {
            Parent = parent;
            Name = name;
        }

        public string Name { get; }
        public Org Parent { get; }
    }
}