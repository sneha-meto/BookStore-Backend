using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class User
    {
        public User(int userId, bool active, string userName, string password,string email)
        {
            UserId = userId;
            Active = active;
            UserName = userName;
            Password = password;
            Email = email;

        }

        public int UserId { get; set; }
        public bool Active { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}