using HMO.Core.Entities;
using HMO.Core.Repositories;
using HMOServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        //Access to data for patient
        private readonly DataContext _context;
        public PatientRepository(DataContext context)
        {
            _context = context;
        }

        public List<Patient> GetPatient()
        {
            return _context.Patient.ToList();
        }

        public Patient Get(int id)
        {
            return _context.Patient.ToList().Find((x) => x.ID == id);
        }

        public void Post(Patient p)
        {
            _context.Patient.Add(p);
            _context.SaveChanges();
        }

        public void Put(int id, Patient p)
        {
            var f = Get(id);
            if (f != null)
            {
                f.FirstName = p.FirstName;
                f.LastName = p.LastName;
                f.PatientID = p.PatientID;
                f.Phone = p.Phone;
                f.CellPhone = p.CellPhone;
                f.DateOfBirth = p.DateOfBirth;
                f.City= p.City;
                f.Street= p.Street;
                f.Number= p.Number;
                _context.Patient.Update(f);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var f = Get(id);
            if (f != null)
            {
                _context.Patient.Remove(Get(id));
                _context.SaveChanges();
            }
        }
    }
}

