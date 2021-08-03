namespace VApp.Models
{
    public class SearchDataModel
    {
        //Employee Deatils
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string JoiningDate { get; set; }

        //Vaccination Details
        public string VccineName { get; set; }
        public int? DoseType { get; set; }
        public string VaccinationDate { get; set; }
        public string HospitalName { get; set; }
        //public string CertificatePath { get; set; }
    }
}
