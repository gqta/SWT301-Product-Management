using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using SalesManagement.BL;

namespace SalesManagement.DAL
{
    class CategoryDAL
    {
        public static DataTable GetAllCategory() {
            string sql = "SELECT * FROM Categories";
            return Database.GetDataBySQL(sql);
        }

        public static int AddCategory(ArrayList lst)
        {
            int count = 0;

            string sql = "INSERT INTO Categories values (@CatId, @CatName, @Des)";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CatId", SqlDbType.Char),
                new SqlParameter("@CatName", SqlDbType.NVarChar),
                new SqlParameter("@Des", SqlDbType.NText)

            };

            for(int i = 0; i < lst.Count; i++)
            {
                param[i].Value = lst[i];
            }

            count = Database.ExecuteSQL(sql, param);
            return count;
        }

        public static int UpdateCategory(Category cat)
        {
            int count = 0;
            string sql = " Update Categories SET [CategoryName] = @CatName , [Description] = @Des WHERE [CategoryId] = @CatId";
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@CatId", SqlDbType.Char),
                new SqlParameter("@CatName", SqlDbType.NVarChar),
                new SqlParameter("@Des", SqlDbType.NText)
            };

            parm[0].Value = cat;

            count = Database.ExecuteSQL(sql, parm);

            return count;

        }

        internal static int UpdateCategory(ArrayList lst)
        {
            int count = 0;

            string sql = "Update Categories SET [CategoryName] = @CatName , [Description] = @Des WHERE [CategoryId] = @CatId";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CatId", SqlDbType.Char),
                new SqlParameter("@CatName", SqlDbType.NVarChar),
                new SqlParameter("@Des", SqlDbType.NText)

            };

            for (int i = 0; i < lst.Count; i++)
            {
                param[i].Value = lst[i];
            }

            count = Database.ExecuteSQL(sql, param);
            return count;
        }

        public static int DeleteCategory(string lst)
        {

            int result = 0;

            string sql = "DELETE FROM [dbo].[Categories] WHERE [CategoryId] = @CatId";

            SqlParameter[] pram = { new SqlParameter("@CatId", lst)};

            result = Database.ExecuteSQL(sql, pram);


            return result;
        }


    }
}
