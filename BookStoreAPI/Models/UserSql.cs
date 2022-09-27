using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class UserSql:IUser
    {
        SqlCommand comm;
        SqlConnection conn;

        public UserSql()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

      
        public void Register(User user)
        {
          
            comm.CommandText = "insert into [User] values (1,'"+user.UserName+"','"+user.Password+"','"+user.Email+"')";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

     
    }
}