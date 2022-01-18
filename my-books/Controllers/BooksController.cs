using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _service;

        public BooksController(BooksService service)
        {
            _service = service;
        }

        //First endpoint
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _service.Add(book);
            return Ok();
        }

        //Second endpoint / GetallBooks
        [HttpGet("get-all-books")]
        public IActionResult  GetAllBooks()
        {
            var allBooks = _service.GetAllBooks();
            return Ok(allBooks);
        }

        //Third endpoint / GetBookById/1
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _service.GetBookById(id);
            return Ok(book);
        }
        
        //Fourth endpoint / UpdateBookById/1
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            var updatedBook = _service.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        //Fifth endpoint / DeleteBookById/1
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _service.DeleteBookById(id);
            return Ok();
        }
    }
}
