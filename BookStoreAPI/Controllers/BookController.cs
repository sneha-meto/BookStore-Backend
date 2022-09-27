using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace BookStoreAPI.Controllers
{
    public class BookController : ApiController
    {
        // GET: Book
        private IBook repo;

        public BookController()
        {
            repo = new BookSql();
        }

        // GET: Category
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repo.GetBooks();
            return Ok(data);
        }

        [HttpGet, Route("api/book/search/{type}/{key}")]
        public IHttpActionResult Search(string type, string key)
        {
            var data = repo.SearchBooks(type,key);
            return Ok(data);
        }


        //[HttpGet, Route("api/book/id/{id}")]
        [HttpGet]
        public IHttpActionResult GetBookById(int id)
        {
            var data = repo.GetBookById(id);
            return Ok(data);

        }


        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            repo.AddBook(book);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(Book book)
        {
            repo.EditBook(book);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repo.DeleteBook(id);
            return Ok();
        }
    }
}