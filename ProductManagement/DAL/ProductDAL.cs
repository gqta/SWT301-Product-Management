using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SalesManagement.BL;

namespace SalesManagement.DAL
{
    public class ProductDAL
    {
        public static DataTable getAllProducts()
        {
            string sql = "select Products.*, Categories.CategoryName as category from Products join Categories on Products.CategoryId = Categories.CategoryId";

            return Database.GetDataBySQL(sql);
        }

        internal static int Save(Product product)
        {
            string sql = "UPDATE [dbo].[Products]\n" +
"        SET [ProductName] = @productName\n" +
"      ,[CategoryId] = @CategoryId\n" +
"      ,[Unit] = @Unit\n" +
"      ,[Price] = @Price\n" +
"      ,[Quantity] = @Quantity\n" +
"      ,[Discontinued] = @Discontinued\n" +
" WHERE [ProductId] = @ProductId";

            SqlParameter[] parameter = new SqlParameter[]{
                new SqlParameter("@ProductId", product.Id),
                new SqlParameter("@ProductName", product.Name),
                new SqlParameter("@CategoryId", product.Category),
                new SqlParameter("@Unit", product.Unit),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Quantity", product.Quantity),
                new SqlParameter("@Discontinued", product.Discontinued),

             };

            return Database.ExecuteSQL(sql, parameter);
        }

        internal static int Add(Product product)
        {
            string sql = "INSERT INTO [Products]  VALUES (@ProductId , @ProductName, @CategoryId , @Unit, @Price, @Quantity, @Discontinued, GETDATE())";

            SqlParameter[] parameter = new SqlParameter[]{
                new SqlParameter("@ProductId", product.Id),
                new SqlParameter("@ProductName", product.Name),
                new SqlParameter("@CategoryId", product.Category),
                new SqlParameter("@Unit", product.Unit),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Quantity", product.Quantity),
                new SqlParameter("@Discontinued", product.Discontinued),

             };


            return Database.ExecuteSQL(sql, parameter);
        }

        internal static int Delete(string id)
        {
            string sql = "DELETE FROM [dbo].[Products]  WHERE [ProductId] = @ProductId";

            SqlParameter[] parameter = new SqlParameter[]{
                new SqlParameter("@ProductId", id),

             };


            return Database.ExecuteSQL(sql, parameter);
        }
    }
}
