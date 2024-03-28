using HMO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Core.Repositories
{
    public interface IProducerRepository
    {
        //Access to data interface for producer
        List<Producer> GetProducer();
        Producer Get(int id);
        void Post(Producer p);
        void Put(int id, Producer p);
        void Delete(int id);
    }
}
