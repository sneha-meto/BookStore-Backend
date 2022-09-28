using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Order
    {
        public Order(int orderId, DateTime date, float amount, int userId, string address)
        {
            OrderId = orderId;
            Date = date;
            Amount = amount;
            UserId = userId;
            Address = address;
        }

        public int OrderId { get; set; }
        public DateTime  Date { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
}
}