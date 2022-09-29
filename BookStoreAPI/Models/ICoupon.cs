using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public interface ICoupon
    {
        List<Coupon> GetActiveCoupons();
        List<Coupon> GetCoupons();
        void AddCoupon(Coupon coupon);
        bool ActivateCoupon(int id,bool activate);


    }
}