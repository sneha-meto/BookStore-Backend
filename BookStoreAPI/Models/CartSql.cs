using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class CartSql
    {
        SqlCommand comm;
        SqlConnection conn;

        public CartSql()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public void AddItem(CartItem item)
        {
          comm.CommandText = "insert into CartItems values(" + item.Qty + "," + item.BookId + "," + item.UserId + ")";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<CartItem> GetItems(int id)
        { List<CartItem> itemList = new List<CartItem>();
            //comm.CommandText = "select * from CartItems  where CartId="+id+"";
            comm.CommandText = "select c.CartItemId,c.qty,c.BookId, c.UserId,b.Price, b.Title,b.Image from CartItems c inner join Books b on c.BookId= b.BookId  where UserId=" + id + "";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int cartItemId = Convert.ToInt32(reader["CartItemId"]);
                int qty = Convert.ToInt32(reader["Qty"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                int userId = Convert.ToInt32(reader["UserId"]);
                float price = float.Parse(reader["Price"].ToString());
                string title = reader["Title"].ToString();
                string image = reader["Image"].ToString();
                CartItem cartItem = new CartItem(cartItemId, qty, bookId, userId,price,title,image);
                itemList.Add(cartItem);
            }
            conn.Close();
            return itemList;
           
        }

        public void UpdateQty(CartItem item)
        {
            comm.CommandText = "update CartItems set Qty = "+item.Qty + " where CartItemId="+item.CartItemId+"";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveItem(int id)
        {
            comm.CommandText = "delete from CartItems where CartItemId ="+id+"";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        //public void CreateCart(int userId)
        //{
        //    comm.CommandText = "insert into Cart values('" + userId + "')";
        //    comm.Connection = conn;
        //    conn.Open();
        //    comm.ExecuteNonQuery();
        //    conn.Close();
        //}
    }
}