using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeedingATree.Builders;
using SpecifyingCSharpAPI.OrgComponent;

namespace SpecifyingCSharpAPI
{
    [TestClass]
    public class InfoManagerTests
    {
        private IOrgContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            var an = new OrgStructBuilder();
            _context = Facade.CreateOrgContext(
                an.OrgStruct("Board",
                    brd => brd.HasChild("HOFin",
                        fin => fin.HasChild("FinContr"),
                        fin => fin.HasChild("FinStrat")),
                    brd => brd.HasChild("HOTech",
                        tech => tech.HasChild("ITInfra"),
                        tech => tech.HasChild("SWDevSvc",
                            sds => sds.HasChild("SWPmo"),
                            sds => sds.HasChild("SWEng"))))
            );
        }

        [TestMethod]
        public void GetDirectChildren_GivenAnOrgUnit_GetsJustTheDirectChildren()
        {
            var infoManager = Facade.GetInfoManager(_context);
            var orgHOTech = _context.OrgStructure["HOTech"];

            // Act
            var children = infoManager.GetDirectChildren(orgHOTech);

            Assert.AreEqual(2, children.Count);
            Assert.AreEqual("ITInfra", children[0].ShortName);
            Assert.AreEqual("SWDevSvc", children[1].ShortName);
        }

        [TestMethod]
        public void GetDirectChildren_GivenAnOrgUnitShortName_GetsJustTheDirectChildren()
        {
            var infoManager = Facade.GetInfoManager(_context);

            // Act
            var children = infoManager.GetDirectChildren("HOTech");

            Assert.AreEqual(2, children.Count);
            Assert.AreEqual("ITInfra", children[0].ShortName);
            Assert.AreEqual("SWDevSvc", children[1].ShortName);
        }

        [TestMethod]
        public void GetAllChildren_GivenAnOrgUnit_AlsoReturnsTheGrandChildren()
        {
            var infoManager = Facade.GetInfoManager(_context);
            var orgHOTech = _context.OrgStructure["HOTech"];

            // Act
            var children = infoManager.GetAllChildren(orgHOTech);

            Assert.AreEqual(4, children.Count);
            Assert.AreEqual("ITInfra", children[0].ShortName);
            Assert.AreEqual("SWDevSvc", children[1].ShortName);
            Assert.AreEqual("SWPmo", children[2].ShortName);
            Assert.AreEqual("SWEng", children[3].ShortName);
        }

        [TestMethod]
        public void GetAllChildren_GivenAnOrgUnitShortName_AlsoReturnsTheGrandChildren()
        {
            var infoManager = Facade.GetInfoManager(_context);

            // Act
            var children = infoManager.GetAllChildren("HOTech");

            Assert.AreEqual(4, children.Count);
            Assert.AreEqual("ITInfra", children[0].ShortName);
            Assert.AreEqual("SWDevSvc", children[1].ShortName);
            Assert.AreEqual("SWPmo", children[2].ShortName);
            Assert.AreEqual("SWEng", children[3].ShortName);
        }
    }
}
