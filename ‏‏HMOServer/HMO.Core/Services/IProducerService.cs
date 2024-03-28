using HMO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Core.Services
{
    public interface IProducerService
    {
        //Business logic interface for producer
        List<Producer> GetProducer();
        Producer Get(int id);
        void Post(Producer p);
        void Put(int id, Producer p);
        void Delete(int id);
    }
}
