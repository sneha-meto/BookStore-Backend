using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class CartItem
    {
        public CartItem(int cartItemId, int qty, int bookId, int userId, float price,string title,string image)
        {
            CartItemId = cartItemId;
            Qty = qty;
            BookId = bookId;
            UserId = userId;

            Price = price;
            Title = title;
            Image = image;
        }
        public int CartItemId;
        public int Qty { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public float Price;
        public string Title;
        public string Image;
    }
}