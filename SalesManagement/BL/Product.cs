using SalesManagement.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesManagement.BL
{
    class Product
    {
        private string productId, productName, categoryId, unit;
        private int price;
        private int quantity;
        private bool discontinued;
        private DateTime createDate;

        public string ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string CategoryId { get => categoryId; set => categoryId = value; }
        public string Unit { get => unit; set => unit = value; }
        public int Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public bool Discontinued { get => discontinued; set => discontinued = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }

        public Product(string productId, string productName, string categoryId, string unit, int price, int quantity, bool discontinued, DateTime createDate)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.CategoryId = categoryId;
            this.Unit = unit;
            this.Price = price;
            this.Quantity = quantity;
            this.Discontinued = discontinued;
            this.CreateDate = createDate;
        }



        public static List<Product> GetAllProduct()
        {
            List<Product> products = new List<Product>();
            DataTable dataTable = ProductDAL.GetAllProduct();
            foreach (DataRow dr in dataTable.Rows)
            {
                string productId = dr["ProductId"].ToString();
                string productName = dr["ProductName"].ToString();
                string categoryId = dr["CategoryId"].ToString();
                string unit = dr["Unit"].ToString();
                int price = int.Parse(dr["Price"].ToString());
                int quantity = int.Parse(dr["Quantity"].ToString());
                bool discontinued = bool.Parse(dr["Discontinued"].ToString());
                DateTime createDate = DateTime.Parse(dr["CreateDate"].ToString());
                Product product = new Product(productId,productName,categoryId,unit,price,quantity,discontinued,createDate);
                products.Add(product);
            }
            return products;
        }

        public static int AddProduct(ArrayList arrayList)
        {
            return ProductDAL.AddProduct(arrayList);
        }
        public static int UpdateProduct(ArrayList arrayList)
        {
            return ProductDAL.UpdateProduct(arrayList);
        }
        public static int DeleteProduct(string productId)
        {
            return ProductDAL.DeleteProduct(productId);
        }


    }
}
