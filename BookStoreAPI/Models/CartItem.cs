using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class CartItem
    {
        public CartItem(int cartItemId,int qty, int bookId, int cartId)
        {
            CartItemId = cartItemId;
            Qty = qty;
            BookId = bookId;
            CartId = cartId;
        }
        public int CartItemId;
        public int Qty { get; set; }
        public int BookId { get; set; }
        public int CartId { get; set; }
    }
}