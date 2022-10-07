using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public interface IUser
    {
        void Register(User user);
        int Login(string username, string password);
        void Activation(int id, int activate);





    }
}