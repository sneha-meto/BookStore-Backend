using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public interface IWishlist
    {
        List<Wishlist> getWishlist(int userId);
        void AddToWishList(Wishlist wishlist);
        void DeleteFromWishList(int wishlistId);


    }
}