using Builders.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builders
{
    [TestClass]
    public class OrgStructBuildingTests
    {
        [TestMethod]
        public void TestTheOrgStructBuilder()
        {
            var an = new OrgStructBuilder();

            var oestruct = an.OrgStruct("Board",
                brd => brd.HasChild("HOFin"),
                brd => brd.HasChild("HOTech",
                    tech => tech.HasChild("SWDevSvc",
                        sds => sds.HasChild("SWPmo"),
                        sds => sds.HasChild("SWEng"))));

            var orgBrd = oestruct["Board"];
            var orgHOFin = oestruct["HOFin"];
            var orgHOTech = oestruct["HOTech"];
            var orgSds = oestruct["SWDevSvc"];
            var orgSwPmo = oestruct["SWPmo"];
            var orgSwEng = oestruct["SWEng"];

            Assert.AreEqual("Board", orgBrd.Name);
            Assert.AreEqual("HOFin", orgHOFin.Name);
            Assert.AreEqual("HOTech", orgHOTech.Name);
            Assert.AreEqual("SWDevSvc", orgSds.Name);
            Assert.AreEqual("SWPmo", orgSwPmo.Name);
            Assert.AreEqual("SWEng", orgSwEng.Name);

            Assert.IsNull(orgBrd.Parent);
            Assert.AreSame(orgBrd, orgHOFin.Parent);
            Assert.AreSame(orgBrd, orgHOTech.Parent);
            Assert.AreSame(orgHOTech, orgSds.Parent);
            Assert.AreSame(orgSds, orgSwPmo.Parent);
            Assert.AreSame(orgSds, orgSwEng.Parent);
        }
    }
}
