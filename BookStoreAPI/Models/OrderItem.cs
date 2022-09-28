using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class OrderItem
    {
        public OrderItem(int itemId, int qty, int bookId, int orderId)
        {
            ItemId = itemId;
            Qty = qty;
            BookId = bookId;
            OrderId = orderId;
        }

        public int ItemId { get; set; }
        public int Qty { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }
    }
}