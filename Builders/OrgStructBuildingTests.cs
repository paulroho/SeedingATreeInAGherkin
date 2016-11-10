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
            Assert.AreEqual("HOTech", ouHOTech.ShortName);
            Assert.AreEqual("ITInfra", ouItInfra.ShortName);
            Assert.AreEqual("SWDevSvc", ouSds.ShortName);
            Assert.AreEqual("SWPmo", ouSwPmo.ShortName);
            Assert.AreEqual("SWEng", ouSwEng.ShortName);

            Assert.IsNull(ouBrd.Parent);
            Assert.AreSame(ouBrd, ouHOFin.Parent);
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
            Assert.AreEqual("HOTech", ouHOTech.ShortName);
            Assert.AreEqual("ITInfra", ouItInfra.ShortName);
            Assert.AreEqual("SWDevSvc", ouSds.ShortName);
            Assert.AreEqual("SWPmo", ouSwPmo.ShortName);
            Assert.AreEqual("SWEng", ouSwEng.ShortName);

            Assert.IsNull(ouBrd.Parent);
            Assert.AreSame(ouBrd, ouHOFin.Parent);
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
                brd => brd.HasChild("HOFin"),
                brd => brd.HasChild("HOTech",
                    tech => tech.HasChild("ITInfra"),
                    tech => tech.HasChild("SWDevSvc",
                        sds => sds.HasChild("SWPmo"),
                        sds => sds.HasChild("SWEng"))));

            var ouBrd = oestruct["Board"];
            var ouHOFin = oestruct["HOFin"];
            var ouHOTech = oestruct["HOTech"];
            var ouItInfra = oestruct["ITInfra"];
            var ouSds = oestruct["SWDevSvc"];
            var ouSwPmo = oestruct["SWPmo"];
            var ouSwEng = oestruct["SWEng"];

            Assert.AreEqual("Board", ouBrd.ShortName);
            Assert.AreEqual("HOFin", ouHOFin.ShortName);
            Assert.AreEqual("HOTech", ouHOTech.ShortName);
            Assert.AreEqual("ITInfra", ouItInfra.ShortName);
            Assert.AreEqual("SWDevSvc", ouSds.ShortName);
            Assert.AreEqual("SWPmo", ouSwPmo.ShortName);
            Assert.AreEqual("SWEng", ouSwEng.ShortName);

            Assert.IsNull(ouBrd.Parent);
            Assert.AreSame(ouBrd, ouHOFin.Parent);
            Assert.AreSame(ouBrd, ouHOTech.Parent);
            Assert.AreSame(ouHOTech, ouItInfra.Parent);
            Assert.AreSame(ouHOTech, ouSds.Parent);
            Assert.AreSame(ouSds, ouSwPmo.Parent);
            Assert.AreSame(ouSds, ouSwEng.Parent);
        }
    }
}
