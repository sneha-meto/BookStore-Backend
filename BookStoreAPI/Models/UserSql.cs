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
            comm.CommandText = "insert into [User] values (1,'"+user.UserName+"','"+user.Password+"','"+user.Email+"',1,'"+user.Mobile+"')";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public int[] Login(string username, string password)
        {
            int userId=0;
            int role = 2;
            comm.CommandText = "select * from [User] where UserName= '" + username + "' and [Password] = '" + password + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read()) 
            {
                userId = Convert.ToInt32(reader["UserId"]);
                role = Convert.ToInt32(reader["Role"]);

            }
            if (reader.HasRows ) return new int[]{ userId,role};
            else return null;
        }

        public void Activation(int id, int activate)
        {
            comm.CommandText = "update [User] set Active = "+activate+" where userId="+id+" ";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<User> SearchUser(string type, string key)
        {
            List<User> userList = new List<User>();
            comm.CommandText = "select * from [User] u where "+type+" like '%"+key+"%' and u.Role=1";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int userId = Convert.ToInt32(reader["UserId"]);
                bool active = Convert.ToBoolean(reader["Active"]);
                string userName = reader["USerName"].ToString();
                string password = reader["Password"].ToString();
                string email = reader["Email"].ToString();
                int role = Convert.ToInt32(reader["Role"]);
                string mobile = reader["Mobile"].ToString();
      

                User user = new User(userId,active,userName,password,email,role,mobile);
                userList.Add(user);
            }
            conn.Close();
            return userList;

        }
    }
}