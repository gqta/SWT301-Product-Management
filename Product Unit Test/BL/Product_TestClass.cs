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
        [TestCase("C0002", "Monitor", "Magic Monitor", "unit-2", 100, 1000, true, "03-03-2021")]
        [TestCase("C0003", "Keyboard", "Magic Keyboard", "unit-3", 100, 1000, true, "03-03-2021")]
        [TestCase("C0004", "Webcam", "Magic Webcam", "unit-4", 100, 1000, true, "03-03-2021")]
        [TestCase("C0005", "HeadPhone", "Magic HeadPhone", "unit-5", 100, 1000, true, "03-03-2021")]
        [TestCase("C0006", "Monitor", "Magic Monitor", "unit-2", 100, 1000, true, "03-03-2021")]
        [TestCase("C0007", "Keyboard", "Magic Keyboard", "unit-3", 100, 1000, true, "03-03-2021")]
        [TestCase("C0008", "Webcam", "Magic Webcam", "unit-4", 100, 1000, true, "03-03-2021")]
        [TestCase("C0009", "HeadPhone", "Magic HeadPhone", "unit-5", 100, 1000, true, "03-03-2021")]
        [TestCase("C0010", "Mouse", "Magic Monitor", "unit-1", 100, 1000, true, "2021-03-2021")]

        public void TC_01_Costructor_InitConstructor(string id, string name, string category, string unit, int price, int quantity, bool discontinued, string date)
        {

            try
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
            catch (ArgumentNullException ae)
            {
                Assert.AreEqual("Parameter cannot be null or empty.", ae.Message);
            }
            catch (Exception e)
            {
                Assert.Pass(
                     string.Format("Unexpected exception of type {0} caught: {1}",
                                    e.GetType(), e.Message)
                );
            }


        }
        [TestCase("C0001", "Mouse", "Magic Mouse", "unit-1", 100, 1000, true, "03-03-2021")]
        [TestCase("C0002", "Monitor", "Magic Monitor", "unit-2", 100, 1000, true, "03-03-2021")]
        [TestCase("C0003", "Keyboard", "Magic Keyboard", "unit-3", 100, 1000, true, "03-03-2021")]
        [TestCase("C0004", "Webcam", "Magic Webcam", "unit-4", 100, 1000, true, "03-03-2021")]
        [TestCase("C0005", "HeadPhone", "Magic HeadPhone", "unit-5", 100, 1000, true, "03-03-2021")]
        [TestCase("C0006", "Monitor", "Magic Monitor", "unit-2", 100, 1000, true, "03-03-2021")]
        [TestCase("C0007", "Keyboard", "Magic Keyboard", "unit-3", 100, 1000, true, "03-03-2021")]
        [TestCase("C0008", "Webcam", "Magic Webcam", "unit-4", 100, 1000, true, "03-03-2021")]
        [TestCase("C0009", "HeadPhone", "Magic HeadPhone", "unit-5", 100, 1000, true, "03-03-2021")]
        [TestCase("C0010", "Mouse", "Magic Monitor", "unit-1", 100, 1000, true, "03-03-2021")]

        public void TC_01_Costructor_Setter(string id, string name, string category, string unit, int price, int quantity, bool discontinued, string date)
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


        


    }
}
