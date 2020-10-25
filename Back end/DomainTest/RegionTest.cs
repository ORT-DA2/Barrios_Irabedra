using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio.Domain;

namespace Tests.DomainTest
{
    [TestClass]
    public class RegionTest
    {
        private Region myRegion;

        [TestInitialize]
        public void SetUp()
        {
            myRegion = new Region();
        }

        [TestMethod]
        public void RegionConstructorTest()
        {
            Assert.AreEqual(myRegion.Name, "Default Name");
        }

        [TestMethod]
        public void NameTest()
        {
            myRegion.Name = "Corredor Pajaros Pintados";
            Assert.AreEqual(myRegion.Name, "Corredor Pajaros Pintados");
        }


        [TestMethod]
        public void EqualsIsNullTest()
        {
            Assert.IsFalse(myRegion.Equals(null));
        }

        [TestMethod]
        public void EqualsIsNotEqualsTest()
        {
            Region anotherRegion = new Region();
            anotherRegion.Name = "Centro Sur";
            Assert.IsFalse(myRegion.Equals(anotherRegion));
        }

        [TestMethod]
        public void EqualsTest()
        {
            Region anotherRegion = new Region();
            anotherRegion.Name = "Litoral Norte";
            myRegion.Name = "Litoral Norte";
            Assert.IsTrue(myRegion.Equals(anotherRegion));
        }

        [TestCleanup]
        public void TearDown()
        {
        }
    }
}
