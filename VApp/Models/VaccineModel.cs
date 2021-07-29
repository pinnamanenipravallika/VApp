using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace VApp.Models
{
    public class VaccineModel
    {

        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$", ErrorMessage = "Only Image files allowed.")]
        public int EmpId { get; set; }

        public int VaccineNameId { get; set; }
        public int DoseTypeId { get; set; }
        public string HospitalName { get; set; }
        public string CertificatePath { get; set; }
        public DateTime VaccinationDate { get; set; }
        
    }
}
