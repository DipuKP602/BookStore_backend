using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class BookController : ApiController
    {
        IBookRepository bookRepository;
        public BookController()
        {
            bookRepository = new BookSqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var res = bookRepository.GetAllBooks();
            return Ok(res);
        }

        [HttpGet]
        public IHttpActionResult Get(int catId)
        {
            var res = bookRepository.GetBooksByCategory(catId);
            return Ok(res);
        }

        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            var res = bookRepository.AddBook(book);
            return Ok(res);
        }

        [HttpPost]
        public IHttpActionResult Post(int bookId,Book book)
        {
            var res = bookRepository.EditBook(bookId,book);
            if (res)
                return Ok("Book Deleted");
            else
                return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int bookId)
        {
            var res = bookRepository.DeleteBook(bookId);
            if (res)
                return Ok("Book Deleted");
            else
                return BadRequest();
        }
    }
}
