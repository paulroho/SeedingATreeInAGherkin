using System;

namespace SeedingATree.Builders
{
    public class BuilderRoot
    {
        public static BuilderRoot A => new BuilderRoot();

        public OrgBuilder OrgBuilder(string shortName)
        {
            return new OrgBuilder(shortName);
        }

        public object OrgStruct(string board, Func<object, object> func, Func<object, object> func1)
        {
            throw new NotImplementedException();
        }
    }
}