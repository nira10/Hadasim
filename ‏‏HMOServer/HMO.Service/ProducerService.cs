using HMO.Core.Entities;
using HMO.Core.Repositories;
using HMO.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Service
{
    public class ProducerService : IProducerService
    {
        //Business logic for producer
        private readonly IProducerRepository _ProducerRepository;

        public ProducerService(IProducerRepository ProducerRepository)
        {
            this._ProducerRepository = ProducerRepository;
        }

        public List<Producer> GetProducer()
        {
            return _ProducerRepository.GetProducer().ToList();
        }

        public Producer Get(int id)
        {
            return _ProducerRepository.Get(id);
        }

        public void Post(Producer p)
        {
            _ProducerRepository.Post(p);
        }

        public void Put(int id, Producer p)
        {
            _ProducerRepository.Put(id, p);
        }

        public void Delete(int id)
        {
            _ProducerRepository.Delete(id);
        }
    }
}