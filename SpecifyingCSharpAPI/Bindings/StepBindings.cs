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

        [When(@"I call GetDirectChildren\(([A-Za-z]*)\)")]
        public void WhenICallGetDirectChildrenOrgUnit(string orgUnitShortName)
        {
            var orgUnit = _context.OrgStruct[orgUnitShortName];

            var infoManager = _context.GetInfoManager();

            _context.ResultOrgUnits = infoManager.GetDirectChildren(orgUnit);
        }

        [When(@"I call GetDirectChildren\(""([A-Za-z]*)""\)")]
        public void WhenICallGetDirectChildrenString(string orgUnitShortName)
        {
            var infoManager = _context.GetInfoManager();

            _context.ResultOrgUnits = infoManager.GetDirectChildren(orgUnitShortName);
        }

        [When(@"I call GetAllChildren\(([A-Za-z]*)\)")]
        public void WhenICallGetAllChildrenOrgUnit(string orgUnitShortName)
        {
            var orgUnit = _context.OrgStruct[orgUnitShortName];

            var infoManager = _context.GetInfoManager();

            _context.ResultOrgUnits = infoManager.GetAllChildren(orgUnit);
        }

        [When(@"I call GetAllChildren\(([A-Za-z]*), includeSelf:(true|false)\)")]
        public void WhenICallGetAllChildrenOrgUnit(string orgUnitShortName, bool includeSelf)
        {
            var orgUnit = _context.OrgStruct[orgUnitShortName];

            var infoManager = _context.GetInfoManager();

            _context.ResultOrgUnits = infoManager.GetAllChildren(orgUnit, includeSelf);
        }

        [When(@"I call GetAllChildren\(""([A-Za-z]*)""\)")]
        public void WhenICallGetAllChildrenString(string orgUnitShortName)
        {
            var infoManager = _context.GetInfoManager();

            _context.ResultOrgUnits = infoManager.GetAllChildren(orgUnitShortName);
        }

        [When(@"I call GetAllChildren\(""([A-Za-z]*)"", includeSelf:(true|false)\)")]
        public void WhenICallGetAllChildrenString(string orgUnitShortName, bool includeSelf)
        {
            var infoManager = _context.GetInfoManager();

            _context.ResultOrgUnits = infoManager.GetAllChildren(orgUnitShortName, includeSelf);
        }

        [Then(@"I get the org units")]
        public void ThenIGetTheOrgUnits(Table table)
        {
            table.RenameColumn("Org Unit", "ShortName");
            table.CompareToSet(_context.ResultOrgUnits);
        }
    }
}