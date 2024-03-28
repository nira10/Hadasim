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
    public class PatientService: IPatientService
    {
        //Business logic for patient
        private readonly IPatientRepository _PatientRepository;

        public PatientService(IPatientRepository PatientRepository)
        {
            this._PatientRepository = PatientRepository;
        }

        public List<Patient> GetPatient()
        {
            return _PatientRepository.GetPatient().ToList();
        }

        public Patient Get(int id)
        {
            return _PatientRepository.Get(id);
        }

        public void Post(Patient p)
        {
            _PatientRepository.Post(p);
        }

        public void Put(int id, Patient p)
        {
            _PatientRepository.Put(id, p);
        }

        public void Delete(int id)
        {
            _PatientRepository.Delete(id);
        }
    }
}