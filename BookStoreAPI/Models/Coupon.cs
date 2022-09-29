using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Coupon
    {
        public Coupon(int couponId, string couponCode, float discount, string description, bool active)
        {
            CouponId = couponId;
            CouponCode = couponCode;
            Discount = discount;
            Description = description;
            Active = active;
        }

        public int CouponId { get;}
        public string CouponCode { get; set; }
        public float Discount { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}