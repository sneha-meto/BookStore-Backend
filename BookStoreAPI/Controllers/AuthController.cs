using BookStoreAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookStoreAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AuthController : ApiController
    {
        private IUser repo;

        public AuthController()
        {
            repo = new UserSql();
        }

        [HttpPost, Route("api/auth/register")]
        public IHttpActionResult Register(User user)
        {
            repo.Register(user);
            return Ok("user registered");
        }

        [HttpPost, Route("api/auth/login")]
        public IHttpActionResult Login(JObject data)
        {
            string username =data["username"].ToString();
            string password = data["password"].ToString();
            int res =  repo.Login(username,password);
            if (res!=0) return Ok(res);
            else return Unauthorized();
        }

        [HttpPut, Route("api/auth/{id}/{activate}")]
        public IHttpActionResult Login(int id, bool activate)
        {
            int activateInt = activate ? 1 : 0;
            repo.Activation(id, activateInt);
            if (activate) return Ok("user activated");
            else return Ok("user deactivated");
        }

    }
}
