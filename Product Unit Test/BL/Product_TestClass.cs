using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SalesManagement.BL;


namespace Product_Unit_Test.BL
{
    [TestFixture]
    class Product_TestClass
    {
        [TestCase("C0001", "Mouse", "Magic Mouse", "unit-1", 100, 1000, true, "03-03-2021")]
        [TestCase(null, null, null, null, 100, 1000, true, "03-03-2021")]
        [TestCase("", "", "", "", 100, 1000, true, "03-03-2021")]
        public void TC_01_Costructor_InitConstructor(string id, string name, string category, string unit, int price, int quantity, bool discontinued, string date)
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



        [TestCase("C0001", "Mouse", "Magic Mouse", "unit-1", 100, 1000, true, "03-03-2021")]
        [TestCase(null, null, null, null, 100, 1000, true, "03-03-2021")]
        [TestCase("", "", "", "", 100, 1000, true, "03-03-2021")]

        public void TC_02_Costructor_Setter(string id, string name, string category, string unit, int price, int quantity, bool discontinued, string date)
        {
            Product product = new Product();
            product.Id = id;
            product.Name = name;
            product.Category = category;
            product.Unit  = unit;
            product.Price = price;
            product.Quantity = quantity;
            product.Discontinued = discontinued;
            product.Date = DateTime.Parse(date);

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
        public void TC_03_getAllProducts()
        {
            Assert.IsTrue(Product.GetAllProducts().Count >= 0);
        }
        [TestCase]
        public void TC_04_TestConnectionString()
        {
            Assert.NotNull(ConfigurationManager.ConnectionStrings["ProductDB"]);
        }




    }
}
