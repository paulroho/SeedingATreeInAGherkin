using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        private IEnumerable<OrgRowColSkipped> _orgRowsColSkip;
        private IEnumerable<OrgRowIndended> _orgRowsIndended;
        private IEnumerable<OrgRowIndended> _orgRowsMultiline;

        [Given(@"I have the following organizations")]
        public void GivenIHaveTheFollowingOrganizations(Table table)
        {
            _orgRows = table.CreateSet<OrgRow>();
        }

        [Given(@"I have the following levelled org structure")]
        public void GivenIHaveTheFollowingLevelledOrgStructure(Table table)
        {
            _orgRowsColSkip = table.CreateSet<OrgRowColSkipped>();
        }

        [Given(@"I have the following intended org structure")]
        public void GivenIHaveTheFollowingIntendedOrgStructure(Table table)
        {
            _orgRowsIndended = table.CreateSet<OrgRowIndended>();
        }

        [Given(@"I have the following intended org structure as text")]
        public void GivenIHaveTheFollowingIntendedOrgStructureAsText(string asciiArt)
        {
            _orgRowsMultiline = asciiArt.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(l => new OrgRowIndended {OrgAtLevel = l.Trim()});
        }

        [When(@"I execute the specs")]
        public void WhenIExecuteTheSpecs()
        {
            // HACK
            if (_orgRows != null)
            {
                _orgs = GetOrgsFromOrgRows(_orgRows);
            }
            if (_orgRowsColSkip != null)
            {
                _orgs = GetOrgsFromOrgRowsColSkipped(_orgRowsColSkip);
            }
            if (_orgRowsIndended != null)
            {
                _orgs = GetOrgsFromOrgRowsIndended(_orgRowsIndended);
            }
            if (_orgRowsMultiline != null)
            {
                _orgs = GetOrgsFromOrgRowsIndended(_orgRowsMultiline);
            }
        }

        private Dictionary<string, Org> GetOrgsFromOrgRows(IEnumerable<OrgRow> rows)
        {
            var orgs = new Dictionary<string, Org>();
            foreach (var row in rows)
            {
                var org = new Org(row.Name, row.Name, OrgType.Normal);
                if (!string.IsNullOrEmpty(row.Parent))
                {
                    org.Parent = orgs[row.Parent];
                }
                orgs.Add(org.ShortName, org);
            }
            return orgs;
        }

        private Dictionary<string, Org> GetOrgsFromOrgRowsColSkipped(IEnumerable<OrgRowColSkipped> rows)
        {
            var orgs = new Dictionary<string, Org>();
            var levels = new Dictionary<int, Org>();
            foreach (var row in rows)
            {
                var name = row.Name;
                var org = new Org(name, name, OrgType.Normal);
                var level = row.Level;
                if (level > 1)
                {
                    org.Parent = levels[level - 1];
                }
                orgs.Add(org.ShortName, org);

                levels[level] = org;
            }
            return orgs;
        }

        private Dictionary<string, Org> GetOrgsFromOrgRowsIndended(IEnumerable<OrgRowIndended> rows)
        {
            var orgs = new Dictionary<string, Org>();
            var levels = new Dictionary<int, Org>();
            foreach (var row in rows)
            {
                var name = row.Name;
                var org = new Org(name, name, OrgType.Normal);
                var level = row.Level;
                if (level > 1)
                {
                    org.Parent = levels[level - 1];
                }
                orgs.Add(org.ShortName, org);

                levels[level] = org;
            }
            return orgs;
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

    public class OrgRowIndended
    {
        public string OrgAtLevel { get; set; }

        public string Name => Regex.Replace(OrgAtLevel, @"(. )*(.*)", "$2");

        public int Level => (OrgAtLevel.Length - Name.Length)/2 + 1;
    }

    public class OrgRowColSkipped
    {
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public string Level4 { get; set; }
        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(Level1)) return Level1;
                if (!string.IsNullOrEmpty(Level2)) return Level2;
                if (!string.IsNullOrEmpty(Level3)) return Level3;
                return Level4;
            }
        }

        public int Level
        {
            get
            {
                if (!string.IsNullOrEmpty(Level1)) return 1;
                if (!string.IsNullOrEmpty(Level2)) return 2;
                if (!string.IsNullOrEmpty(Level3)) return 3;
                return 4;
            }
        }
    }

    public class OrgRow
    {
        public string Name { get; set; }
        public string Parent { get; set; }
    }
}