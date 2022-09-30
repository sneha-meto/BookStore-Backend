using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class AddressSql : IAddress

    {
        SqlCommand comm;
        SqlConnection conn;

        public AddressSql()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public void AddAddress(Address address)
        {
            
            comm.CommandText = "insert into Address values('"+address.Building+"','"+address.Street+"','"+address.Locality+"','"+address.District+"','"+address.Pin+"',"+address.UserId+")";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteAddress(int addressId)
        {
            comm.CommandText = "delete from Address where AddressId="+addressId+";";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void EditAddress(Address address)
        {
            comm.CommandText = "update Address set Building='"+address.Building+ "',Street='"+address.Street+ "',Locality='"+address.Locality+ "',District='"+address.District+ "',Pin='"+address.Pin+ "' where AddressId="+address.AddressId+";";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Address> GetAddress(int id)
        {
            List<Address> AdList = new List<Address>();
            comm.CommandText = "select * from Address where UserId="+id+"";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int addressId = Convert.ToInt32(reader["AddressId"]);            
                string building = reader["Building"].ToString();
                string street = reader["Street"].ToString();
                string locality = reader["Locality"].ToString();
                string district = reader["District"].ToString();
                string pin = reader["Pin"].ToString();
                int userId = Convert.ToInt32(reader["UserId"]);

                Address ad = new Address(addressId, building, street, locality, district, pin, userId);
                AdList.Add(ad);
            }
            conn.Close();
            return AdList;
        }
    }
}