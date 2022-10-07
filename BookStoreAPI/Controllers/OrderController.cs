using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace BookStoreAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {

        private OrderSql repo;
        public OrderController()
        {
            repo = new OrderSql();
        }

        [HttpGet]
        public IHttpActionResult GetOrders()
        {
            var data = repo.GetOrders();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult GetOrderItems(int id)
        {
            var data = repo.GetItems(id);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult PlaceOrder(JObject data)
        {
            List<CartItem> items = data["items"].ToObject<List<CartItem>>();
            int addressId = Convert.ToInt32(data["addressId"]);
            int userId = Convert.ToInt32(data["userId"]);
           
            //int? couponId = null;
            //if (((int?)data["couponId"]) != null)
            int? couponId = ((int?)data["couponId"]); 
           
            float discount = float.Parse(data["discount"].ToString());
            repo.PlaceOrder(items,addressId,userId,couponId,discount);
            return Ok("Order placed");
        }




    }
}
