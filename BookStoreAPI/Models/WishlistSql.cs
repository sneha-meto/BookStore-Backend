using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class WishlistSql : IWishlist
    {
        SqlCommand comm;
        SqlConnection conn;

        public WishlistSql()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public void AddToWishList(Wishlist wishlist)
        {
            comm.CommandText = "insert into Wishlist values ("+wishlist.BookId+","+wishlist.UserId+");";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteFromWishList(int wishlistId)
        {
            comm.CommandText = "delete from WishList where WishlistId="+wishlistId+";";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Wishlist> getWishlist(int id)
        {
            List<Wishlist> wishes = new List<Wishlist>();
            comm.CommandText = "select w.WishlistId, w.BookId, w.UserId, b.[Image], b.Title, b.Author,b.Position, b.Price from Wishlist w inner join Books b on w.BookId=b.BookId where UserId ="+id+";";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int wishlistId = Convert.ToInt32(reader["WishlistId"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                int userId = Convert.ToInt32(reader["UserId"]);

                string image = reader["Image"].ToString();
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                int position = Convert.ToInt32(reader["Position"]); ;
                float price = float.Parse( reader["Price"].ToString());

                Wishlist wish = new Wishlist(wishlistId, bookId, userId,image,title,author,position,price);
                wishes.Add(wish);
            }
            conn.Close();
            return wishes;
        }
    }
}