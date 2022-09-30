using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Wishlist
    {
        public Wishlist(int wishlistId, int bookId, int userId)
        {
            WishlistId = wishlistId;
            BookId = bookId;
            UserId = userId;
        }

        public int WishlistId { get; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}