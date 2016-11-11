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
            var orgUnitRows = table.CreateSet<OrgUnitRow>();
            _context.OrgStruct = GetOrgStructFromOrgUnitRows(orgUnitRows);
        }

        [Given(@"I have the following levelled org structure")]
        public void GivenIHaveTheFollowingLevelledOrgStructure(Table table)
        {
            var orgUnitRows = table.CreateSet<OrgUnitRowColSkipped>();
            _context.OrgStruct = GetOrgStructFromOrgUnitRowsColSkipped(orgUnitRows);
        }

        [Given(@"I have the following intended org structure")]
        public void GivenIHaveTheFollowingIntendedOrgStructure(Table table)
        {
            var orgUnitRows = table.CreateSet<OrgUnitRowIndented>();
            _context.OrgStruct = GetOrgStructFromOrgUnitRowsIndented(orgUnitRows);
        }

        [Given(@"I have the following intended org structure as text")]
        public void GivenIHaveTheFollowingIntendedOrgStructureAsText(string asciiArt)
        {
            var orgUnitRows = asciiArt.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(l => new OrgUnitRowIndented {OrgUnitAtLevel = l.TrimEnd()});
            _context.OrgStruct = GetOrgStructFromOrgUnitRowsIndented(orgUnitRows);
        }

        [Given(@"I have the following intended org structure as text indenting by '(.*)'")]
        public void GivenIHaveTheFollowingIntendedOrgStructureAsTextIndentingBy(string indentationString, string asciiArt)
        {
            var indentStepLength = indentationString.Length;
            var whitespaces = new string(' ', indentStepLength);
            var searchPattern = $@"(({whitespaces})*({Regex.Escape(indentationString)}))(.*)";
            var replacePattern = "$4";

            var orgUnitRows = asciiArt.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    l => new OrgUnitRowIndented
                    {
                        OrgUnitAtLevel = l.TrimEnd(),
                        SearchPattern = searchPattern,
                        IndentStepLength = indentStepLength,
                        ReplacePattern = replacePattern,
                    });
            _context.OrgStruct = GetOrgStructFromOrgUnitRowsIndented(orgUnitRows);
        }

        [When(@"I execute the specs")]
        public void WhenIExecuteTheSpecs()
        {
            // Dummy step
        }

        private OrgStruct GetOrgStructFromOrgUnitRows(IEnumerable<OrgUnitRow> rows)
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

        private OrgStruct GetOrgStructFromOrgUnitRowsColSkipped(IEnumerable<OrgUnitRowColSkipped> rows)
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

        private OrgStruct GetOrgStructFromOrgUnitRowsIndented(IEnumerable<OrgUnitRowIndented> rows)
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
            var ouUnits = _context.OrgStruct;
            var ouBrd = ouUnits["Board"];
            var ouHOFin = ouUnits["HOFin"];
            var ouFinContr = ouUnits["FinContr"];
            var ouFinStrat = ouUnits["FinStrat"];
            var ouHOTech = ouUnits["HOTech"];
            var ouItInfra = ouUnits["ITInfra"];
            var ouSds = ouUnits["SWDevSvc"];
            var ouSwPmo = ouUnits["SWPmo"];
            var ouSwEng = ouUnits["SWEng"];

            Assert.AreEqual("Board", ouBrd.ShortName);
            Assert.AreEqual("HOFin", ouHOFin.ShortName);
            Assert.AreEqual("FinContr", ouFinContr.ShortName);
            Assert.AreEqual("FinStrat", ouFinStrat.ShortName);
            Assert.AreEqual("HOTech", ouHOTech.ShortName);
            Assert.AreEqual("ITInfra", ouItInfra.ShortName);
            Assert.AreEqual("SWDevSvc", ouSds.ShortName);
            Assert.AreEqual("SWPmo", ouSwPmo.ShortName);
            Assert.AreEqual("SWEng", ouSwEng.ShortName);

            Assert.IsNull(ouBrd.Parent);
            Assert.AreSame(ouBrd, ouHOFin.Parent);
            Assert.AreSame(ouHOFin, ouFinContr.Parent);
            Assert.AreSame(ouHOFin, ouFinStrat.Parent);
            Assert.AreSame(ouBrd, ouHOTech.Parent);
            Assert.AreSame(ouHOTech, ouItInfra.Parent);
            Assert.AreSame(ouHOTech, ouSds.Parent);
            Assert.AreSame(ouSds, ouSwPmo.Parent);
            Assert.AreSame(ouSds, ouSwEng.Parent);
        }
    }

    public class OrgUnitRowIndented
    {
        public string OrgUnitAtLevel { get; set; }

        public string SearchPattern { get; set; } = @"([. ] )*(.*)";
        public int IndentStepLength { get; set; } = 2;
        public string ReplacePattern { get; set; } = "$2";

        public string Name => Regex.Replace(OrgUnitAtLevel, SearchPattern, ReplacePattern);
        public int Level => (OrgUnitAtLevel.Length - Name.Length)/IndentStepLength + 1;
    }

    public class OrgUnitRowColSkipped
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

    public class OrgUnitRow
    {
        public string Name { get; set; }
        public string Parent { get; set; }
    }
}