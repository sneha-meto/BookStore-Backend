using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class OrderItem
    {
        public OrderItem(int itemId, int qty, int bookId, int orderId,string title,string image,float price)
        {
            ItemId = itemId;
            Qty = qty;
            BookId = bookId;
            OrderId = orderId;

            Title = title;
            Image = image;
            Price = price;
        }

        public int ItemId { get; set; }
        public int Qty { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }


        public string Title { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
    }
}