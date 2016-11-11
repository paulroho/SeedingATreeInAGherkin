using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeedingATree.Builders;
using SeedingATree.Domain;

namespace SeedingATree
{
    [TestClass]
    public class OrgStructBuildingTests
    {
        [TestMethod]
        public void BuildTheOrgViaApi()
        {
            var ouBrd = new OrgUnit("Board", "Executive Board", 
                OrgUnitType.Executive);
            var ouHOFin = new OrgUnit("HOFin", "Head Office Finance", 
                OrgUnitType.Executive, ouBrd);
            var ouFinContr = new OrgUnit("FinContr", "Finance Controlling", 
                OrgUnitType.Department, ouHOFin);
            var ouFinStrat = new OrgUnit("FinStrat", "Finance Strategy", 
                OrgUnitType.Department, ouHOFin);
            var ouHOTech = new OrgUnit("HOTech", "Head Office Technology", 
                OrgUnitType.Executive, ouBrd);
            var ouItInfra = new OrgUnit("ITInfra", "IT Infrastructure",
                OrgUnitType.Department, ouHOTech);
            var ouSds = new OrgUnit("SWDevSvc", "Software Development Services", 
                OrgUnitType.Department, ouHOTech);
            var ouSwPmo = new OrgUnit("SWPmo", "Software Development PMO", 
                OrgUnitType.Normal, ouSds);
            var ouSwEng = new OrgUnit("SWEng", "Software Development Engineering", 
                OrgUnitType.Normal, ouSds);

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

        [TestMethod]
        public void BuildTheOrgViaOrgUnitBuilder()
        {
            var an = BuilderRoot.A;

            var ouBrd = an.OrgUnit("Board").Build();
            var ouHOFin = an.OrgUnit("HOFin")
                .AsChildOf(ouBrd).Build();
            var ouFinContr = an.OrgUnit("FinContr")
                .AsChildOf(ouHOFin).Build();
            var ouFinStrat = an.OrgUnit("FinStrat")
                .AsChildOf(ouHOFin).Build();
            var ouHOTech = an.OrgUnit("HOTech")
                .AsChildOf(ouBrd).Build();
            var ouItInfra = an.OrgUnit("ITInfra")
                .AsChildOf(ouHOTech).Build();
            var ouSds = an.OrgUnit("SWDevSvc")
                .AsChildOf(ouHOTech).Build();
            var ouSwPmo = an.OrgUnit("SWPmo")
                .AsChildOf(ouSds).Build();
            var ouSwEng = an.OrgUnit("SWEng")
                .AsChildOf(ouSds).Build();

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

        [TestMethod]
        public void TestTheOrgStructBuilder()
        {
            var an = new OrgStructBuilder();

            var oestruct = an.OrgStruct("Board",
                brd => brd.HasChild("HOFin",
                    fin => fin.HasChild("FinContr"),
                    fin => fin.HasChild("FinStrat")),
                brd => brd.HasChild("HOTech",
                    tech => tech.HasChild("ITInfra"),
                    tech => tech.HasChild("SWDevSvc",
                        sds => sds.HasChild("SWPmo"),
                        sds => sds.HasChild("SWEng"))));

            var ouBrd = oestruct["Board"];
            var ouHOFin = oestruct["HOFin"];
            var ouFinContr = oestruct["FinContr"];
            var ouFinStrat = oestruct["FinStrat"];
            var ouHOTech = oestruct["HOTech"];
            var ouItInfra = oestruct["ITInfra"];
            var ouSds = oestruct["SWDevSvc"];
            var ouSwPmo = oestruct["SWPmo"];
            var ouSwEng = oestruct["SWEng"];

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
}
