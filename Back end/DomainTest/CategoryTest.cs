using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio.Domain;

namespace Tests.DomainTest
{
    [TestClass]
    public class CategoryTest
    {

        private Category myCategory;

        [TestInitialize]
        public void SetUp()
        {
            myCategory = new Category();
        }

        [TestMethod]
        public void RegionConstructorTest()
        {
            Assert.AreEqual(myCategory.Name, "Default Name");
        }

        [TestMethod]
        public void NameTest()
        {
            myCategory.Name = "Ecoturismo";
            Assert.AreEqual(myCategory.Name, "Ecoturismo");
        }


        [TestMethod]
        public void EqualsIsNullTest()
        {
            Assert.IsFalse(myCategory.Equals(null));
        }

        [TestMethod]
        public void EqualsIsNotEqualsTest()
        {
            Category anotherCategory = new Category();
            anotherCategory.Name = "Ecoturismo";
            Assert.IsFalse(myCategory.Equals(anotherCategory));
        }

        [TestMethod]
        public void EqualsTest()
        {
            Category anotherCategory = new Category();
            anotherCategory.Name = "Ecoturismo";
            myCategory.Name = "Ecoturismo";
            Assert.IsTrue(myCategory.Equals(anotherCategory));
        }

        [TestCleanup]
        public void TearDown()
        {
        }
    }
}
