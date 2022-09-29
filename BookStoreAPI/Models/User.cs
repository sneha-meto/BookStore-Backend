﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class User
    {
        public User(int userId, bool active, string userName, string password,string email,int role)
        {
            UserId = userId;
            Active = active;
            UserName = userName;
            Password = password;
            Email = email;
            Role = Role;

        }

        public int UserId { get; set; }
        public bool Active { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
    }
}