using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SalesManagement.BL;

namespace Product_Unit_Test.BL
{
    [TestFixture]
    class Product_TestClass
    {

        [TestCase("C0001", "Mouse", "Magic Mouse", "unit-1", 100, 1000, true, "03-03-2021")]
        public void TC_01_TC_01_Costructor_InitConstructor(string id, string name, string category, string unit, int price, int quantity, bool discontinued, string date)
        {
            Product product = new Product(id, name, category, unit, price, quantity, discontinued, DateTime.Parse(date));
            
            Assert.AreEqual(id, product.Id);
            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(category, product.Category);
            Assert.AreEqual(unit, product.Unit);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
            Assert.AreEqual(discontinued, product.Discontinued);
            Assert.AreEqual(DateTime.Parse(date), product.Date);

        }

        [TestCase]

        public void TestMethod()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
