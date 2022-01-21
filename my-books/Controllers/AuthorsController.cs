using Microsoft.AspNetCore.Mvc;
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
    public class AuthorsController : Controller
    {
        private readonly AuthorsService _service;
        public AuthorsController(AuthorsService service)
        {
            _service = service;
        }

        //First endpoint
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody]AuthorVM author)
        {
            _service.AddAuthor(author);
            return Ok();
        }

        //Second endpoint / GetAllAuthors
        [HttpGet("get-all-authors")]
        public IActionResult GetAllAuthors()
        {
            var allAuthors = _service.GetAllAuthors();
            return Ok(allAuthors);
        }

        //Third endpoint / GetAuthorById/1
        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author =  _service.GetAuthorById(id);
            return Ok(author);
        }

        //Fourth endpoint / UpdateAuthorById/1
        [HttpPut("update-author-by-id/{id}")]
        public IActionResult UpdateAuthorById(int id, [FromBody]AuthorVM author)
        {
            var updatedAuthor = _service.UpdateAuthorById(id, author);
            return Ok(updatedAuthor);
        }

        //Fifth endpoint / DeleteAuthorById/1
        [HttpDelete("delete-author-by-id/{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _service.DeleteAuthorById(id);
            return Ok();
        }
    }
}
