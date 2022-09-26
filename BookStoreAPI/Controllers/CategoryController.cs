using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace BookStoreAPI.Controllers
{
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

        [HttpPost]
        public IHttpActionResult Post(Category cat)
        {
            repo.AddCategory(cat);
            return Ok();
        }
    }
}