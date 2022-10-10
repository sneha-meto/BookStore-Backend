using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class OrderSql
    {


        SqlCommand comm;
        SqlConnection conn;

        public OrderSql()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public List<Order> GetOrders()
        {
            List<Order> itemList = new List<Order>();
            comm.CommandText = "select * from [Order]";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int orderId = Convert.ToInt32(reader["OrderId"]);
                DateTime date = Convert.ToDateTime(reader["Date"]);
                float amount = float.Parse(reader["Amount"].ToString());
                int userId = Convert.ToInt32(reader["UserId"]);
                int addressId = Convert.ToInt32(reader["AddressId"]);
                int? couponId=null;
                if (!reader.IsDBNull(5) ){ 
                couponId = Convert.ToInt32(reader["CouponId"]);
                
                }
                float netAmount = float.Parse(reader["NetAmount"].ToString());
                Order order= new Order(orderId, date, amount, userId, addressId,couponId,netAmount);
                itemList.Add(order);
            }
            conn.Close();
            return itemList;

        }

        public List<OrderItem> GetItems(int id)
        {
            List<OrderItem> itemList = new List<OrderItem>();
            comm.CommandText = "select o.ItemId,o.Qty,o.BookId,o.OrderId,b.Title,b.Image,b.Price from OrderItems o inner join Books b on o.BookId=b.BookId  where OrderId="+id+"";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int itemId = Convert.ToInt32(reader["ItemId"]);

                int qty = Convert.ToInt32(reader["Qty"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                int orderId = Convert.ToInt32(reader["OrderId"]);

                string title = reader["Title"].ToString();
                string image= reader["Image"].ToString();
                float price = float.Parse( reader["Price"].ToString());

                OrderItem order = new OrderItem(itemId,qty,bookId,orderId,title,image,price);
                itemList.Add(order);
            }
            conn.Close();
            return itemList;

        }

        private string GenerateItems(List<CartItem> items, int orderId)
        {
            string str = "insert into OrderItems values ";
            foreach (CartItem item in items)
            {
                str += "(" + item.Qty + ", " + item.BookId + ", " + orderId + "),";
            }
            str = str.Remove(str.Length - 1);
            str += ";";
            return str;

        }

        private dynamic GetCouponId(int? id)
        {
            if (id == null)
                return "null";
            else return id;
        }
      

        public void PlaceOrder(List<CartItem> items,int addressId, int userId,int? couponId,float discount)
        {
            float total=0f;
            foreach (CartItem item in items)
                total += item.Price * item.Qty;
            float net = total - (total * discount);

            comm.CommandText = "insert into [Order] values ('"+DateTime.Today.ToString("yyyy-MM-dd") +"',"+total+","+userId+",'" + addressId + "',"+GetCouponId(couponId)+","+net+");" + "SELECT SCOPE_IDENTITY();"; 

            comm.Connection = conn;
            conn.Open();
            object res = comm.ExecuteScalar();
            int orderId=Convert.ToInt32(res);

            comm.CommandText = GenerateItems(items, orderId);

            comm.ExecuteNonQuery();
            conn.Close();
        }


    }
}