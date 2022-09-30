using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Address
    {
        public Address(int addressId, string building, string street, string locality, string district, string pin, int userId)
        {
            AddressId = addressId;
            Building = building;
            Street = street;
            Locality = locality;
            District = district;
            Pin = pin;
            UserId = userId;
        }

        public int AddressId { get; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string Locality { get; set; }
        public string District{ get; set; }
        public string Pin{ get; set; }
        public int UserId { get; set; }
    }
}