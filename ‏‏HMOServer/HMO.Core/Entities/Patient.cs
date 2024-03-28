using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Core.Entities
{
    public class Patient
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "ID should be 9 numbers only")]
        public string PatientID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public DateTime DateOfBirth { get; set; }

        [RegularExpression(@"^\d{9,10}$", ErrorMessage = "Phone should be 9 or 10 numbers only")]
        public string Phone { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "ID should be 10 numbers only")]
        public string CellPhone { get; set; }
        public List<Vaccination> Vaccinations { get; set; }
        public DateTime Positive { get; set; }
        public DateTime Recovery { get; set; }
    }
}
