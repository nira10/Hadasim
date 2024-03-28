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
    public class VaccinationRepository : IVaccinationRepository
    {
        //Access to data for vaccination
        private readonly DataContext _context;
        public VaccinationRepository(DataContext context)
        {
            _context = context;
        }

        public List<Vaccination> GetVaccination()
        {
            return _context.Vaccination.Include(u => u.PatientId).Include(u => u.Producer).ToList();
        }

        public Vaccination Get(int id)
        {
            return _context.Vaccination.Include(u => u.PatientId).Include(u => u.Producer).ToList().Find((x) => x.ID == id);
        }

        public void Post(Vaccination v)
        {
            int count = _context.Vaccination.Count(u => u.ID == v.ID);
            if (count < 4)
            {
                _context.Vaccination.Add(v);
                _context.SaveChanges();
            }
        }

        public void Put(int id, Vaccination v)
        {
            var f = Get(id);
            if (f != null)
            {
                f.Producer = v.Producer;
                f.Date = v.Date;
                f.PatientId = v.PatientId;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var f = Get(id);
            if (f != null)
            {
                _context.Vaccination.Remove(Get(id));
                _context.SaveChanges();
            }
        }
    }
}
