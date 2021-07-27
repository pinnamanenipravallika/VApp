using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VApp.Models
{
    public class VaccineModel
    {
        public int EmpId { get; set; }

        public int VaccineNameId { get; set; }
        public int DoseTypeId { get; set; }
        public string HospitalName { get; set; }
        public string CertificatePath { get; set; }
        public DateTime VaccinationDate { get; set; }
        
    }
}
