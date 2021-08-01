﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace VApp.Models
{
    public class VaccineModel
    {

       
        
        public int EmpId { get; set; }
        
        public int VaccineNameId { get; set; }
        public int DoseTypeId { get; set; }
        [Required(ErrorMessage = "Please enter the hospital name.")]
        public string HospitalName { get; set; }
        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.pdf)$", ErrorMessage = "Only pdf files allowed.")]
       
        public string CertificatePath { get; set; }
        [Required(ErrorMessage = "Please select the date.")]
        public DateTime VaccinationDate { get; set; }
        
    }
}
