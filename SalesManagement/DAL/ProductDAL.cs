using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SalesManagement.DAL
{
    class ProductDAL
    {
        public static DataTable GetAllProduct()
        {
            string sql = "  SELECT [ProductId]" +
      ",[ProductName]" +
      ", y.[CategoryName] as CategoryId" +
      ",[Unit]" +
      ",[Price]" +
      ",[Quantity]" +
      ",[Discontinued]" +
      ",[CreateDate]" +
      " FROM[ProductDB].[dbo].[Products] x join[ProductDB].[dbo].[Categories] y " +
      "on " +
      "x.CategoryId = y.CategoryId";
            return Database.GetDataBySQL(sql);
        }
        public static int AddProduct(ArrayList arrayList)
        {
            int count = 0;
            string sql = "INSERT INTO Products VALUES(@PId, @PName, @CId,@Unit,@Price,@Quantity,@Dis,@CDate)";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@PId",SqlDbType.Char),
                new SqlParameter("@PName",SqlDbType.NVarChar),
                new SqlParameter("@CId",SqlDbType.Char),
                new SqlParameter("@Unit",SqlDbType.NVarChar),
                new SqlParameter("@Price",SqlDbType.Int),
                new SqlParameter("@Quantity",SqlDbType.Int),
                new SqlParameter("@Dis",SqlDbType.Bit),
                new SqlParameter("@CDate",SqlDbType.DateTime)
            };

            // Gan gia tri cho cac tham so gia dinh
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            count = Database.ExecuteSQL(sql, param);
            return count;
        }
        public static int UpdateProduct(ArrayList arrayList)
        {
            int count = 0;
            string sql = "UPDATE [dbo].[Products]"+
   "SET "+
      "[ProductName] = @PName" +
      ",[CategoryId] = @CId" +
      ",[Unit] = @Unit" +
      ",[Price] = @Price" +
      ",[Quantity] = @Quantity" +
      ",[Discontinued] = @Dis" +
      ",[CreateDate] = @CDate" +
  " WHERE [ProductId] = @PId";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@PId",SqlDbType.Char),
                new SqlParameter("@PName",SqlDbType.NVarChar),
                new SqlParameter("@CId",SqlDbType.Char),
                new SqlParameter("@Unit",SqlDbType.NVarChar),
                new SqlParameter("@Price",SqlDbType.Int),
                new SqlParameter("@Quantity",SqlDbType.Int),
                new SqlParameter("@Dis",SqlDbType.Bit),
                new SqlParameter("@CDate",SqlDbType.DateTime)
            };
            // Gan gia tri cho cac tham so gia dinh
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            count = Database.ExecuteSQL(sql, param);
            return count;
        }
        
        public static int DeleteProduct(string productId)
        {

            string sql = "DELETE FROM Products WHERE ProductId=@productId";
            SqlParameter param = new SqlParameter("@productId", SqlDbType.Char);
            // Gan gia tri cho cac tham so kieu SqlParameter
            param.Value = productId;

            return Database.ExecuteSQL(sql, param);
        }
    }

}
