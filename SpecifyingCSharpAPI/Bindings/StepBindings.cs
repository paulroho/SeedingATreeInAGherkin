using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecifyingCSharpAPI.Bindings
{
    [Binding]
    public class StepBindings
    {
        private readonly TestCSharpApiContext _context;

        public StepBindings(TestCSharpApiContext context)
        {
            _context = context;
        }

        [Given(@"for each org unit I have an OrgUnit object named orgUnit\.Shortname")]
        public void GivenForEachOrgUnitIHaveAnOrgUnitObjectNamedOrgUnit_Shortname()
        {
            // dummy step
        }

        [When(@"I call GetDirectChildren\((.*)\)")]
        public void WhenICallGetDirectChildren(string orgUnitShortName)
        {
            var orgUnit = _context.OrgStruct[orgUnitShortName];

            var infoManager = _context.GetInfoManager();

            _context.ResultOrgUnits = infoManager.GetDirectChildren(orgUnit);
        }

        [Then(@"I get the org units")]
        public void ThenIGetTheOrgUnits(Table table)
        {
            table.RenameColumn("Org Unit", "ShortName");
            table.CompareToSet(_context.ResultOrgUnits);
        }
    }
}