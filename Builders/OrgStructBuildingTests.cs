using Builders.Builders;
using Builders.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builders
{
    [TestClass]
    public class OrgStructBuildingTests
    {
        [TestMethod]
        public void BuildTheOrgViaApi()
        {
            var orgBrd = new Org("Board", "Executive Board", 
                OrgType.Executive);
            var orgHOFin = new Org("HOFin", "Head Office Finance", 
                OrgType.Executive, orgBrd);
            var orgHOTech = new Org("HOTech", "Head Office Technology", 
                OrgType.Executive, orgBrd);
            var orgItInfra = new Org("ITInfra", "IT Infrastructure",
                OrgType.Department, orgHOTech);
            var orgSds = new Org("SWDevSvc", "Software Development Services", 
                OrgType.Department, orgHOTech);
            var orgSwPmo = new Org("SWPmo", "Software Development PMO", 
                OrgType.Normal, orgSds);
            var orgSwEng = new Org("SWEng", "Software Development Engineering", 
                OrgType.Normal, orgSds);

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

            var orgBrd = oestruct["Board"];
            var orgHOFin = oestruct["HOFin"];
            var orgHOTech = oestruct["HOTech"];
            var orgItInfra = oestruct["ITInfra"];
            var orgSds = oestruct["SWDevSvc"];
            var orgSwPmo = oestruct["SWPmo"];
            var orgSwEng = oestruct["SWEng"];

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
}
