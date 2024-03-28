using HMO.Core.Entities;
using HMO.Core.Repositories;
using HMOServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Data.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        //Access to data for producer

        private readonly DataContext _context;
        public ProducerRepository(DataContext context)
        {
            _context = context;
        }

        public List<Producer> GetProducer()
        {
            return _context.Producer.ToList();
        }

        public Producer Get(int id)
        {
            return _context.Producer.ToList().Find((x) => x.ID == id);
        }

        public void Post(Producer p)
        {
            _context.Producer.Add(p);
            _context.SaveChanges();
        }

        public void Put(int id, Producer p)
        {
            var f = Get(id);
            if (f != null)
            {
                f.Name = p.Name;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var f = Get(id);
            if (f != null)
            {
                _context.Producer.Remove(Get(id));
                _context.SaveChanges();
            }
        }
    }
}

