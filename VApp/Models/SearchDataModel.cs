using System.ComponentModel;

namespace VApp.Models
{
    public class SearchDataModel
    {
        //Employee Deatils
        public int Id { get; set; }
        public string Code { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        [DisplayName("Joining Date")]
        public string JoiningDate { get; set; }

        //Vaccination Details

        [DisplayName("Vccine Name")]
        public string VccineName { get; set; }

        [DisplayName("Dose Type")]
        public int? DoseType { get; set; }

        [DisplayName("Vaccination Date")]
        public string VaccinationDate { get; set; }

        [DisplayName("Hospital Name")]
        public string HospitalName { get; set; }
        //public string CertificatePath { get; set; }
    }
}
