using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Wishlist
    {
        public Wishlist(int wishlistId, int bookId, int userId, string image,string title, string author, int position,float price)
        {
            WishlistId = wishlistId;
            BookId = bookId;
            UserId = userId;

            Image = image;
            Title = title;
            Author = author;
            Position = position;
            Price = price;
        }

        public int WishlistId { get; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public string Image { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
        public int Position { get; set; }

        public float Price { get; set; }
    }
}