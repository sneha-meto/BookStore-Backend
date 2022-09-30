using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Order
    {
        public Order(int orderId, DateTime date, float amount, int userId, int addressId,int? couponId, float netAmount)
        {
            OrderId = orderId;
            Date = date;
            Amount = amount;
            UserId = userId;
            AddressId = addressId;
            CouponId = couponId;
            NetAmount = netAmount;
        }

        public int OrderId { get; set; }
        public DateTime  Date { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int? CouponId { get; set; }
        public float NetAmount { get; set; }
}
}