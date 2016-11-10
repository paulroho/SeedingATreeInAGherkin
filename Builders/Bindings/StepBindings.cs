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

        [Given(@"I have the following org units")]
        public void GivenIHaveTheFollowingOrgUnits(Table table)
        {
            var orgRows = table.CreateSet<OrgRow>();
            _context.OrgStruct = GetOrgStructFromOrgRows(orgRows);
        }

        [Given(@"I have the following levelled org structure")]
        public void GivenIHaveTheFollowingLevelledOrgStructure(Table table)
        {
            var orgRows = table.CreateSet<OrgRowColSkipped>();
            _context.OrgStruct = GetOrgStructFromOrgRowsColSkipped(orgRows);
        }

        [Given(@"I have the following intended org structure")]
        public void GivenIHaveTheFollowingIntendedOrgStructure(Table table)
        {
            var orgRows = table.CreateSet<OrgRowIndented>();
            _context.OrgStruct = GetOrgStructFromOrgRowsIndented(orgRows);
        }

        [Given(@"I have the following intended org structure as text")]
        public void GivenIHaveTheFollowingIntendedOrgStructureAsText(string asciiArt)
        {
            var orgRows = asciiArt.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(l => new OrgRowIndented {OrgUnitAtLevel = l.TrimEnd()});
            _context.OrgStruct = GetOrgStructFromOrgRowsIndented(orgRows);
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
                        OrgUnitAtLevel = l.TrimEnd(),
                        SearchPattern = searchPattern,
                        IndentStepLength = indentStepLength,
                        ReplacePattern = replacePattern,
                    });
            _context.OrgStruct = GetOrgStructFromOrgRowsIndented(orgRows);
        }

        [When(@"I execute the specs")]
        public void WhenIExecuteTheSpecs()
        {
            // Dummy step
        }

        private OrgStruct GetOrgStructFromOrgRows(IEnumerable<OrgRow> rows)
        {
            var orgStruct = new OrgStruct();
            foreach (var row in rows)
            {
                var org = new OrgUnit(row.Name, row.Name, OrgUnitType.Normal);
                if (!string.IsNullOrEmpty(row.Parent))
                {
                    org.Parent = orgStruct[row.Parent];
                }
                orgStruct.Add(org);
            }
            return orgStruct;
        }

        private OrgStruct GetOrgStructFromOrgRowsColSkipped(IEnumerable<OrgRowColSkipped> rows)
        {
            var orgStruct = new OrgStruct();
            var levels = new Dictionary<int, OrgUnit>();
            foreach (var row in rows)
            {
                var name = row.Name;
                var org = new OrgUnit(name, name, OrgUnitType.Normal);
                var level = row.Level;
                if (level > 1)
                {
                    org.Parent = levels[level - 1];
                }
                orgStruct.Add(org);

                levels[level] = org;
            }
            return orgStruct;
        }

        private OrgStruct GetOrgStructFromOrgRowsIndented(IEnumerable<OrgRowIndented> rows)
        {
            var orgStruct = new OrgStruct();
            var levels = new Dictionary<int, OrgUnit>();
            foreach (var row in rows)
            {
                var name = row.Name;
                var org = new OrgUnit(name, name, OrgUnitType.Normal);
                var level = row.Level;
                if (level > 1)
                {
                    org.Parent = levels[level - 1];
                }
                orgStruct.Add(org);

                levels[level] = org;
            }
            return orgStruct;
        }

        [Then(@"I get the correct org units\.")]
        public void ThenIGetTheCorrectOrgUnits()
        {
            var orgUnits = _context.OrgStruct;
            var orgBrd = orgUnits["Board"];
            var orgHOFin = orgUnits["HOFin"];
            var orgHOTech = orgUnits["HOTech"];
            var orgItInfra = orgUnits["ITInfra"];
            var orgSds = orgUnits["SWDevSvc"];
            var orgSwPmo = orgUnits["SWPmo"];
            var orgSwEng = orgUnits["SWEng"];

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
        public string OrgUnitAtLevel { get; set; }

        public string SearchPattern { get; set; } = @"([. ] )*(.*)";
        public int IndentStepLength { get; set; } = 2;
        public string ReplacePattern { get; set; } = "$2";

        public string Name => Regex.Replace(OrgUnitAtLevel, SearchPattern, ReplacePattern);
        public int Level => (OrgUnitAtLevel.Length - Name.Length)/IndentStepLength + 1;
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