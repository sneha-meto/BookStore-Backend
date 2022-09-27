using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
    public class CartController : ApiController
    {

        private CartSql repo;

        public CartController()
        {
            repo = new CartSql();
        }

        [HttpGet]
        public IHttpActionResult GetCart(int id)
        {
            var data=repo.GetItems(id);
            return Ok(data);
        }

        [HttpPost, Route("api/cart/create/{id}")]
        public IHttpActionResult CreateCart(int id)
        {
            repo.CreateCart(id);
            return Ok("cart created");
        }

        [HttpPost]
        public IHttpActionResult AddItem(CartItem item)
        {
            repo.AddItem(item);
            return Ok("item added");
        }

        [HttpDelete]
        public IHttpActionResult RemoveItem(int id)
        {
            repo.RemoveItem(id);
            return Ok("item removed");
        }

        [HttpPut]
        public IHttpActionResult UpdateQty(CartItem item)
        {
            repo.UpdateQty(item);
            return Ok("qty updated");
        }

    }
}
