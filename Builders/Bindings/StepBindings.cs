using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeedingATree.Domain;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeedingATree.Bindings
{
    [Binding]
    public class StepBindings
    {
        private IEnumerable<OrgRow> _orgRows;
        private Dictionary<string, Org> _orgs;

        [Given(@"I have the following organizations")]
        public void GivenIHaveTheFollowingOrganizations(Table table)
        {
            _orgRows = table.CreateSet<OrgRow>();
        }

        [Given(@"I have the following org structure")]
        public void GivenIHaveTheFollowingOrgStructure(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I execute the specs")]
        public void WhenIExecuteTheSpecs()
        {
            _orgs = new Dictionary<string, Org>();
            foreach (var row in _orgRows)
            {
                var org = new Org(row.Name, row.Name, OrgType.Normal);
                if (!string.IsNullOrEmpty(row.Parent))
                {
                    org.Parent = _orgs[row.Parent];
                }
                _orgs.Add(org.ShortName, org);
            }
        }

        [Then(@"I get the correct organizations\.")]
        public void ThenIGetTheCorrectOrganizations_()
        {
            var orgBrd = _orgs["Board"];
            var orgHOFin = _orgs["HOFin"];
            var orgHOTech = _orgs["HOTech"];
            var orgItInfra = _orgs["ITInfra"];
            var orgSds = _orgs["SWDevSvc"];
            var orgSwPmo = _orgs["SWPmo"];
            var orgSwEng = _orgs["SWEng"];

            Assert.AreEqual("Board", orgBrd.ShortName);
            Assert.AreEqual("HOFin", orgHOFin.ShortName);
            Assert.AreEqual("HOTech", orgHOTech.ShortName);
            Assert.AreEqual("ITInfra", orgItInfra.ShortName);
            Assert.AreEqual("SWDevSvc", orgSds.ShortName);
            Assert.AreEqual("SWPmo", orgSwPmo.ShortName);
            Assert.AreEqual("SWEng", orgSwEng.ShortName);

            Assert.IsNull(orgBrd.Parent);
            Assert.AreSame(orgBrd, orgHOFin.Parent);
            Assert.AreSame(orgBrd, orgHOTech.Parent);
            Assert.AreSame(orgHOTech, orgItInfra.Parent);
            Assert.AreSame(orgHOTech, orgSds.Parent);
            Assert.AreSame(orgSds, orgSwPmo.Parent);
            Assert.AreSame(orgSds, orgSwEng.Parent);
        }
    }

    public class OrgRow
    {
        public string Name { get; set; }
        public string Parent { get; set; }
    }
}