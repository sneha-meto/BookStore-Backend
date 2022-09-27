using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class CategorySql : ICategory
    {

        SqlCommand comm;
        SqlConnection conn;

        public CategorySql()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public void AddCategory(Category category)
        {
            int statBit = category.Status ? 1 : 0;
            comm.CommandText = "insert into Category values('"+category.CategoryName+"','"+category.Description+"','"+category.Image+"',"+statBit+","+category.Position+",'"+category.CreatedAt+"')";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteCategory(int id)
        {
            comm.CommandText = "delete from Category where CategoryId="+id+"";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void EditCategory(Category category)
        {
            int statBit = category.Status ? 1 : 0;

            comm.CommandText = "update Category set CategoryName='"+category.CategoryName+"',[Description]='"+category.Description+"',[Image]='"+category.Image+"',[Status]="+statBit+",Position="+category.Position+",CreatedAt='"+category.CreatedAt+"' where CategoryId="+category.CategoryId+";";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            comm.CommandText = "select * from Category where Status= 1 order by Position";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader=  comm.ExecuteReader();
            while (reader.Read()) {
               int categoryId = Convert.ToInt32(reader["CategoryId"]);
               string categoryName = reader["CategoryName"].ToString();
               string  description = reader["Description"].ToString();
                string image = reader["Image"].ToString();
                bool status = Convert.ToBoolean(reader["Status"]);
                int position = Convert.ToInt32(reader["Position"]);
                DateTime createdAt = Convert.ToDateTime(reader["CreatedAt"]);
                Category category = new Category(categoryId,categoryName,description, image, status, position,createdAt);
                categories.Add(category);
            }
            conn.Close();
            return categories;
        }
    }
}