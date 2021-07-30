using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VApp.Models
{
    public class EmployeeVaccinationDataModel
    {

        public string VccineName { get; set; }
        public int? DoseType { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public string HospitalName { get; set; }

        public string CertificatePath { get; set; }
    }
}
