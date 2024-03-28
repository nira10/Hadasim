using HMO.Core.Entities;

namespace HMO.API.Models
{
    public class PatientPostModel
    {
        //model for patient post request
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatientID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public DateTime Positive { get; set; }
        public DateTime Recovery { get; set; }
    }
}
