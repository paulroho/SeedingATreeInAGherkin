namespace BuilderSample.TestInfrastructure
{
    public class BuilderRoot
    {
        public static BuilderRoot A { get; } = new BuilderRoot();
        public static BuilderRoot An => A;

        private BuilderRoot() { }

        public AddressBuilder Address => new AddressBuilder();
        public CustomerBuilder Customer => new CustomerBuilder();
    }
}