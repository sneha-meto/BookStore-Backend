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
            comm.CommandText = "insert into [User] values (1,'"+user.UserName+"','"+user.Password+"','"+user.Email+"',1)";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public bool Login(string username, string password)
        {
            comm.CommandText = "select * from [User] where UserName= '" + username + "' and [Password] = '" + password + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            
            if (reader.HasRows ) return true;
            else return false;
        }

        public void Activation(int id, int activate)
        {
            comm.CommandText = "update [User] set Active = "+activate+" where userId="+id+" ";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }


    }
}