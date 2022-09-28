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
            comm.CommandText = "select * from Order";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int orderId = Convert.ToInt32(reader["OrderId"]);
                DateTime date = Convert.ToDateTime(reader["Date"]);
                float amount = float.Parse( reader["Amount"].ToString());
                int userId = Convert.ToInt32(reader["UserId"]);
                string address = reader["Address"].ToString();

                Order order= new Order(orderId, date, amount, userId, address);
                itemList.Add(order);
            }
            conn.Close();
            return itemList;

        }

        public List<OrderItem> GetItems(int id)
        {
            List<OrderItem> itemList = new List<OrderItem>();
            comm.CommandText = "select * from OrderItem where OrderId="+id+"";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int itemId = Convert.ToInt32(reader["ItemId"]);

                int qty = Convert.ToInt32(reader["Qty"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                int orderId = Convert.ToInt32(reader["OrderId"]);
                OrderItem order = new OrderItem(itemId,qty,bookId,orderId);
                itemList.Add(order);
            }
            conn.Close();
            return itemList;

        }

        public void PlaceOrder(int cartId, string address)
        {
            comm.CommandText = "select * from CartItems where CartId="+cartId+"";

            //create order
            //insert into [Order] values ('2022-9-20',500,1,'street 13')
            //insert into OrderItems values(1,1,1)

            //todo: finish order apis and test

            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }


    }
}