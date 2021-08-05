using System;
using System.ComponentModel;

namespace VApp.Models
{
    public class EmployeeVaccinationDataModel
    {
        public int EmpId { get; set; }

        [DisplayName("Vaccine Name")]
        public string VccineName { get; set; }

        [DisplayName("Dose Type")]
        public int? DoseType { get; set; }
        [DisplayName(" Vaccination Date")]
        public DateTime? VaccinationDate { get; set; }

        [DisplayName("Hospital Name")]
        public string HospitalName { get; set; }


        [DisplayName("Certificate Path")]
        public string CertificatePath { get; set; }
    }
}
