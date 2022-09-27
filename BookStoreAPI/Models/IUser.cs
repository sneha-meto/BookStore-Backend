using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public interface IUser
    {
        void Register(User user);
        void Login(string username, string password);

       
  

    }
}