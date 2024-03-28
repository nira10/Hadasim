using HMO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Core.Services
{
    public interface IPatientService 
    {
        //Business logic interface for patient
        List<Patient> GetPatient();
        Patient Get(int id);
        void Post(Patient p);
        void Put(int id, Patient p);
        void Delete(int id);
    }
}
