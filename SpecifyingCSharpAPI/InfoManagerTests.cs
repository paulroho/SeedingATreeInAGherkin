using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeedingATree.Builders;
using SpecifyingCSharpAPI.Component;

namespace SpecifyingCSharpAPI
{
    [TestClass]
    public class InfoManagerTests
    {
        private OrgContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            var an = new OrgStructBuilder();
            _context = new OrgContext
            {
                OrgStructure = an.OrgStruct("Board",
                    brd => brd.HasChild("HOFin"),
                    brd => brd.HasChild("HOTech",
                        tech => tech.HasChild("ITInfra"),
                        tech => tech.HasChild("SWDevSvc",
                            sds => sds.HasChild("SWPmo"),
                            sds => sds.HasChild("SWEng"))))
            };
        }

        [TestMethod]
        public void GetDirectChildren_GetsJustTheDirectChildren()
        {
            var infoManager = new InfoManager(_context);

            // Act
            var children = infoManager.GetDirectChildren("HOTech");

            Assert.AreEqual(2, children.Count);
            Assert.AreEqual("ITInfra", children[0].ShortName);
            Assert.AreEqual("SWDevSvc", children[1].ShortName);
        }
    }
}
