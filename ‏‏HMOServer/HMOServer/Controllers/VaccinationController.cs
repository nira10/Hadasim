using HMO.Core.Entities;
using HMO.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class VaccinationController : ControllerBase
    {
        //private readonly DataContext _context;
        private readonly IVaccinationService _context;

        public VaccinationController(IVaccinationService context)
        {
            _context = context;
        }

        // GET: api/<VaccinationController>
        [HttpGet]
        public List<Vaccination> Get()
        {
            return _context.GetVaccination();
        }

        // GET api/<VaccinationController>/5
        [HttpGet("{id}")]
        public Vaccination Get(int id)
        {
            return _context.Get(id);
        }

        // POST api/<VaccinationController>
        [HttpPost]
        public void Post(Vaccination v)
        {
            _context.Post(v);
        }

        // PUT api/<VaccinationController>/5
        [HttpPut("{id}")]
        public void Put(int id, Vaccination v)
        {
            _context.Put(id, v);
        }

        // DELETE api/<VaccinationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Delete(id);
        }
    }
}
