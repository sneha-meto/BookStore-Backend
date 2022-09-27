using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
    public class AuthController : ApiController
    {
        private IUser repo;

        public AuthController()
        {
            repo = new UserSql();
        }

        [HttpPost]
        public IHttpActionResult Register(User user)
        {
            repo.Register(user);
            return Ok("user registered");
        }

    }
}
