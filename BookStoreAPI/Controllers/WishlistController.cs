using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookStoreAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class WishlistController : ApiController
    {
        private IWishlist repo;

        public WishlistController()
        {
            repo = new WishlistSql();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repo.getWishlist(id);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Wishlist wishlist)
        {
            repo.AddToWishList(wishlist);
            return Ok("wish item added");
        }
       

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repo.DeleteFromWishList(id);
            return Ok("wish item deleted");
        }
    }
}
