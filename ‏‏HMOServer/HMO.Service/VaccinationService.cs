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
    public class VaccinationService : IVaccinationService
    {
        //Business logic for vaccination
        private readonly IVaccinationRepository _VaccinationRepository;

        public VaccinationService(IVaccinationRepository VaccinationRepository)
        {
            this._VaccinationRepository = VaccinationRepository;
        }

        public List<Vaccination> GetVaccination()
        {
            return _VaccinationRepository.GetVaccination().ToList();
        }

        public Vaccination Get(int id)
        {
            return _VaccinationRepository.Get(id);
        }

        public void Post(Vaccination v)
        {
            _VaccinationRepository.Post(v);
        }

        public void Put(int id, Vaccination v)
        {
            _VaccinationRepository.Put(id, v);
        }

        public void Delete(int id)
        {
            _VaccinationRepository.Delete(id);
        }
    }
}