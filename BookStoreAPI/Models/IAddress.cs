using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public interface IAddress
    {
        List<Address>GetAddress(int userId);
        void AddAddress(Address address);
        void EditAddress(Address address);
        void DeleteAddress(int addressId);

    }
}