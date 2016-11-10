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
        private readonly OrgBindingContext _context;

        public StepBindings(OrgBindingContext context)
        {
            _context = context;
        }

        [Given(@"I have the following organizations")]
        public void GivenIHaveTheFollowingOrganizations(Table table)
        {
            var orgRows = table.CreateSet<OrgRow>();
            _context.Orgs = GetOrgsFromOrgRows(orgRows);
        }

        [Given(@"I have the following levelled org structure")]
        public void GivenIHaveTheFollowingLevelledOrgStructure(Table table)
        {
            var orgRows = table.CreateSet<OrgRowColSkipped>();
            _context.Orgs = GetOrgsFromOrgRowsColSkipped(orgRows);
        }

        [Given(@"I have the following intended org structure")]
        public void GivenIHaveTheFollowingIntendedOrgStructure(Table table)
        {
            var orgRows = table.CreateSet<OrgRowIndented>();
            _context.Orgs = GetOrgsFromOrgRowsIndented(orgRows);
        }

        [Given(@"I have the following intended org structure as text")]
        public void GivenIHaveTheFollowingIntendedOrgStructureAsText(string asciiArt)
        {
            var orgRows = asciiArt.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(l => new OrgRowIndented {OrgAtLevel = l.TrimEnd()});
            _context.Orgs = GetOrgsFromOrgRowsIndented(orgRows);
        }

        [Given(@"I have the following intended org structure as text indenting by '(.*)'")]
        public void GivenIHaveTheFollowingIntendedOrgStructureAsTextIndentingBy(string indentationString, string asciiArt)
        {
            var indentStepLength = indentationString.Length;
            var whitespaces = new string(' ', indentStepLength);
            var searchPattern = $@"(({whitespaces})*({Regex.Escape(indentationString)}))(.*)";
            var replacePattern = "$4";

            var orgRows = asciiArt.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    l => new OrgRowIndented
                    {
                        OrgAtLevel = l.TrimEnd(),
                        SearchPattern = searchPattern,
                        IndentStepLength = indentStepLength,
                        ReplacePattern = replacePattern,
                    });
            _context.Orgs = GetOrgsFromOrgRowsIndented(orgRows);
        }

        [When(@"I execute the specs")]
        public void WhenIExecuteTheSpecs()
        {
            // Dummy step
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

        private Dictionary<string, Org> GetOrgsFromOrgRowsIndented(IEnumerable<OrgRowIndented> rows)
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
            var orgs = _context.Orgs;
            var orgBrd = orgs["Board"];
            var orgHOFin = orgs["HOFin"];
            var orgHOTech = orgs["HOTech"];
            var orgItInfra = orgs["ITInfra"];
            var orgSds = orgs["SWDevSvc"];
            var orgSwPmo = orgs["SWPmo"];
            var orgSwEng = orgs["SWEng"];

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

    public class OrgRowIndented
    {
        public string OrgAtLevel { get; set; }

        public string SearchPattern { get; set; } = @"([. ] )*(.*)";
        public int IndentStepLength { get; set; } = 2;
        public string ReplacePattern { get; set; } = "$2";

        public string Name => Regex.Replace(OrgAtLevel, SearchPattern, ReplacePattern);
        public int Level => (OrgAtLevel.Length - Name.Length)/IndentStepLength + 1;
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