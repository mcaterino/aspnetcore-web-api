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
    public class PublishersController : Controller
    {
        private readonly PublishersService _service;
        public PublishersController(PublishersService service)
        {
            _service = service;
        }

        //First endpoint
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody]PublisherVM publisher)
        {
            _service.AddPublisher(publisher);
            return Ok();
        }

        //Second endpoint / GetAllPublisher
        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublisher()
        {
            var allPublisher = _service.GetAllPublisher();
            return Ok(allPublisher);
        }

        //Third endpoint / GetPublisherById/1
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisher = _service.GetPublisherById(id);
            return Ok(publisher);
        }

        //Fourth endpoint / UpdatePublisherById/1
        [HttpPut("update-publisher-by-id/{id}")]
        public IActionResult UpdatePublisherById(int id, [FromBody]PublisherVM publisher)
        {
            var updatedPublisher = _service.UpdatePublisherById(id, publisher);
            return Ok(updatedPublisher);
        }

        //Fifth endpoint / DeletePublisherById/1
        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _service.DeletePublisherById(id);
            return Ok();
        }
    }
}
