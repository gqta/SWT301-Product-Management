using NUnit.Framework;
using SalesManagement.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Unit_Test.BL
{
    [TestFixture]
    class Category_TestClass
    {
        [TestCase("C0001", "Mouse", "Amazing")]
        [TestCase("C0004", "PC", "Good")]      
        [TestCase("C0006","HD",1)]

        public void TC01_Constructor_InitConstructor(string categoryId, string categoryName, string description)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Category cat = new Category(categoryId, categoryName, description);

                Assert.AreEqual(cat.CategoryId, categoryId);
                Assert.AreEqual(cat.CategoryName, categoryName);
                Assert.AreEqual(cat.Description, description);
            });
                
        }

        [TestCase("C0001")]
        [TestCase("C0008")]
        [TestCase("D0008")]

        public void TC02_CategoryId_SetterAndGetter(string categoryid)
        {
            Category cat = new Category();
            cat.CategoryId = categoryid;

            Assert.AreEqual(cat.CategoryId, categoryid);

        }

        [TestCase("HD")]
        [TestCase("SD")]
        public void TC03_CategoryName_SetterAndGetter(string categoryName)
        {
            Category cat = new Category();
            cat.CategoryName = categoryName;

            Assert.AreEqual(cat.CategoryName, categoryName);
        }

        [TestCase("normal")]
        [TestCase("commonly")]
        public void TC04_CategoryDescription_SetterAndGetter(string description)
        {
            Category cat = new Category();
            cat.Description = description;

            Assert.AreEqual(cat.Description, description);
        }

    }
}
