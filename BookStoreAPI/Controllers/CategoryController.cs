using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookStoreAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        private ICategory repo;

        public CategoryController()
        {
            repo = new CategorySql();
        }

        // GET: Category
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repo.GetCategories();
            return Ok(data);
        }

        [HttpGet, Route("api/category/all")]
        public IHttpActionResult GetAll()
        {
            var data = repo.GetAllCategories();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Category cat)
        {
            repo.AddCategory(cat);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(Category cat)
        {
            repo.EditCategory(cat);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repo.DeleteCategory(id);
            return Ok();
        }
    }
}