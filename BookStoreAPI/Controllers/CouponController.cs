using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
    public class CouponController : ApiController
    {
        private ICoupon repo;

        public CouponController()
        {
            repo = new CouponSql();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data=repo.GetActiveCoupons();
            return Ok(data);
        }
        [HttpGet,Route("api/coupon/all")]
        public IHttpActionResult GetAll()
        {
            var data = repo.GetCoupons();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult AddCoupon(Coupon coupon)
        {
            repo.AddCoupon(coupon);
            return Ok("coupon added");
        }

        [HttpPut,Route("api/coupon/{id}/{activate}")]
        public IHttpActionResult ActivateCoupon(int id, bool activate)
        {
            bool res= repo.ActivateCoupon(id,activate);
            if (res) return Ok("coupon activated");
            else return Ok("coupon deactivated");
        }

    }
}
