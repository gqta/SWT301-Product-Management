using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SalesManagement.DAL;

namespace SalesManagement.BL
{
    class Category
    {
        private string categoryId;
        private string categoryName;
        private string description;

        public Category(string categoryId, string categoryName, string description)
        {
            this.CategoryId = categoryId;
            this.CategoryName = categoryName;
            this.Description = description;
        }

        

        public string CategoryId { get => categoryId; set => categoryId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string Description { get => description; set => description = value; }

        public static List<Category> GetAllCategory()
        {
            List<Category> categories = new List<Category>();
            DataTable dataTable = CategoryDAL.GetAllCategory();
            foreach(DataRow dr in dataTable.Rows)
            {
                string catId = dr["CategoryId"].ToString();
                string catName = dr["CategoryName"].ToString();
                string description = dr["Description"].ToString();
                Category category = new Category(catId, catName, description);
                categories.Add(category);
            }
            return categories;
        }

        public static int AddCategory(ArrayList lst)
        {


            return CategoryDAL.AddCategory(lst);
        }

        public static int UpdateCategory(Category cat)
        {
            return CategoryDAL.UpdateCategory(cat);
        }

        public static int UpdateCategory(ArrayList lst)
        {
            return CategoryDAL.UpdateCategory(lst);
        }




        internal static int DeleteCategory(string text)
        {
            return CategoryDAL.DeleteCategory(text);
        }

        public static List<Category> Search(string keyword)
        {
            List<Category> categories = new List<Category>();
            DataTable dataTable = CategoryDAL.GetAllCategory();
            foreach (DataRow dr in dataTable.Rows)
            {
                string catId = dr["CategoryId"].ToString();
                string catName = dr["CategoryName"].ToString();
                string description = dr["Description"].ToString();
                Category category = new Category(catId, catName, description);
                categories.Add(category);
            }
            return categories;
            
        }

        //public static List<Category> FindCategory(string keyword)
        //{
            
        //}
    }
}
