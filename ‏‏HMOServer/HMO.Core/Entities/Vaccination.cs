using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Core.Entities
{
    public class Vaccination
    {
        public int ID { get; set; }
        public Producer Producer { get; set; }
        public DateTime Date { get; set; }
        public Patient PatientId { get; set; }

    }
}
