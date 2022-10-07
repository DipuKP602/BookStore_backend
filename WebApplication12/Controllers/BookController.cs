using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _bookRepository.GetAllBooks();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _bookRepository.GetBookById(id);
            if(data == null)
                return NotFound("No book found with id: "+id);
            return Ok(data);
        }


        [HttpPost]
        public IActionResult Post(Book book)
        {
            var data = _bookRepository.AddBook(book);
            if (data == null)
                return BadRequest();

            return Created(HttpContext.Request.Scheme +
                "://"+ HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + book.BookId
                ,data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _bookRepository.DeleteBook(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,Book book)
        {
            var data = _bookRepository.EditBook(id, book);
            return Ok(data);
        }
    }
}
