using BoDi;
using SeedingATree.Bindings;
using TechTalk.SpecFlow;

namespace SpecifyingCSharpAPI.Bindings
{
    [Binding]
    public class GlobalHooks
    {
        private readonly IObjectContainer _container;

        public GlobalHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _container.RegisterTypeAs<TestCSharpApiContext, OrgBindingContext>();
        }
    }
}