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
        [SetUp]
        [TestCase]
        public void TC_01_TC_01_Costructor_InitConstructor(string id, string name, string category, string unit, int price, int quantity, bool discontinued, DateTime date)
        {
            Product product = new Product(id, name, category, unit, price, quantity, discontinued, date);
    }
    }
}
