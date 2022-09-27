using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Cart
    {
        public Cart(int cartId, int userId)
        {
            CartId = cartId;
            UserId = userId;
        }

        public int CartId { get; set; }
        public int UserId { get; set; }
    }
}