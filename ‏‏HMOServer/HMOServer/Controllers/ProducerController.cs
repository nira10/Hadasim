using HMO.Core.Entities;
using HMO.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _context;

        public ProducerController(IProducerService context)
        {
            _context = context;
        }

        // GET: api/<ProducerController>
        [HttpGet]
        public List<Producer> Get()
        {
            return _context.GetProducer();
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public Producer Get(int id)
        {
            return _context.Get(id);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public ActionResult Post(Producer p)
        {
            if (string.IsNullOrEmpty(p.Name))
            {
                return BadRequest("Name is required.");
            }

            _context.Post(p);
            return Ok("Producer created successfully.");

        }

        // PUT api/<ProducerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Producer p)
        {
            if (string.IsNullOrEmpty(p.Name))
            {
                return BadRequest("Name is required.");
            }

            _context.Put(id, p);
            return Ok("Producer updated successfully.");

        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Delete(id);
        }
    }
}
