using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public interface IOrder
    {
        List<Order> GetOrders();
        List<OrderItem> GetOrderItems(int orderId);
        void PlaceOrder(List<CartItem> items, string address, int userId);





    }
}