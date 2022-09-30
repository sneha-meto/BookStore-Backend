using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
    public class AddressController : ApiController
    {
        private IAddress repo;

        public AddressController()
        {
           repo = new AddressSql();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repo.GetAddress(id);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Address address)
        {
            repo.AddAddress(address);
            return Ok("address added");
        }
        [HttpPut]
        public IHttpActionResult Put(Address address)
        {
            repo.EditAddress(address);
            return Ok("address edited");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repo.DeleteAddress(id);
            return Ok("address deleted");
        }
    }
}
