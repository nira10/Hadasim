using HMO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Core.Services
{
    public interface IVaccinationService
    {
        //Business logic interface for vaccination
        List<Vaccination> GetVaccination();
        Vaccination Get(int id);
        void Post(Vaccination v);
        void Put(int id, Vaccination v);
        void Delete(int id);
    }
}
