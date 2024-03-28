using HMO.API.Models;
using HMO.Core.Entities;
using HMO.Core.Services;
using HMO.Service;
using HMOServer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        //private readonly DataContext _context;
        private readonly IPatientService _context;

        public PatientController(IPatientService context)
        {
            _context = context;
        }

        private bool IsValidId(string id)
        {
            // id validation
            return !string.IsNullOrEmpty(id) && id.Length == 9 && id.All(char.IsDigit);
        }

        // GET: api/<PatientController>
        [HttpGet]
        public List<Patient> Get()
        {
            return _context.GetPatient();
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public Patient Get(int id)
        {
            return _context.Get(id);
        }

        // POST api/<PatientController>
        [HttpPost]
        public ActionResult Post(PatientPostModel p)
        {
            var pa= new Patient();
            pa.Positive = p.Positive;
            pa.PatientID= p.PatientID;
            pa.CellPhone= p.CellPhone;
            pa.DateOfBirth= p.DateOfBirth;
            pa.Phone = p.Phone;
            pa.LastName= p.LastName;
            pa.FirstName= p.FirstName;
            pa.Number= p.Number;
            pa.City= p.City;
            pa.Street= p.Street;

            // validation
            if (string.IsNullOrEmpty(pa.FirstName))
            {
                return BadRequest("First name is required.");
            }

            if (string.IsNullOrEmpty(pa.LastName))
            {
                return BadRequest("Last name is required.");
            }

            if (string.IsNullOrEmpty(pa.Phone))
            {
                return BadRequest("Phone is required.");
            }

            if (string.IsNullOrEmpty(pa.City))
            {
                return BadRequest("City is required.");
            }

            if (string.IsNullOrEmpty(pa.Street))
            {
                return BadRequest("Street is required.");
            }

            if (!IsValidId(pa.PatientID))
            {
                return BadRequest("Invalid patient ID.");
            }

            _context.Post(pa);
            return Ok("Patient created successfully.");
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Patient p)
        {
            // validation
            if (string.IsNullOrEmpty(p.FirstName))
            {
                return BadRequest("First name is required.");
            }

            if (string.IsNullOrEmpty(p.LastName))
            {
                return BadRequest("Last name is required.");
            }

            if (string.IsNullOrEmpty(p.Phone))
            {
                return BadRequest("Phone is required.");
            }

            if (string.IsNullOrEmpty(p.City))
            {
                return BadRequest("City is required.");
            }

            if (string.IsNullOrEmpty(p.Street))
            {
                return BadRequest("Street is required.");
            }

            if (!IsValidId(p.PatientID))
            {
                return BadRequest("Invalid patient ID.");
            }

            
            _context.Put(id, p);
            return Ok("Patient updated successfully.");

        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Delete(id);
        }
    }
}
