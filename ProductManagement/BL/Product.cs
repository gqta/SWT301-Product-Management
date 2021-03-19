using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SalesManagement.DAL;

namespace SalesManagement.BL
{
    public class Product
    {
        private string id;
        private string name;
        private string category;
        private string unit;
        private int price;
        private int quantity;
        private bool discontinued;
        private DateTime date;

        public Product()
        {
        }

        public Product(string id, string name, string category, string unit, int price, int quantity, bool discontinued, DateTime date)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Unit = unit;
            this.Price = price;
            this.Quantity = quantity;
            this.Discontinued = discontinued;
            this.Date = date;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Unit { get => unit; set => unit = value; }
        public int Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public bool Discontinued { get => discontinued; set => discontinued = value; }
        public DateTime Date { get => date; set => date = value; }

        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            DataTable tbl = ProductDAL.getAllProducts();

            foreach (DataRow row in tbl.Rows)
            {
                 string id = row["ProductId"].ToString();
                string name = row["ProductName"].ToString();
                string category = row["category"].ToString();
                string unit = row["Unit"].ToString();
                int price = int.Parse(row["Price"].ToString());
                int quantity = int.Parse(row["Quantity"].ToString());
                bool discontinued = bool.Parse(row["Discontinued"].ToString());
                DateTime date = DateTime.Parse(row["CreateDate"].ToString());

                products.Add(new Product(id, name, category, unit, price, quantity, discontinued, date));
            }

            return products;
        }

        public static bool IsExist(string id)
        {
            return GetAllProducts().Count(el => el.Id.Equals(id)) > 0;
        }

        public static int Save(Product product)
        {
            
            return ProductDAL.Save(product);
        }

        public static int Add(Product product)
        {
            return ProductDAL.Add(product);
        }

        public static int Delete(string id)
        {
            return ProductDAL.Delete(id);
        }
    }
}
