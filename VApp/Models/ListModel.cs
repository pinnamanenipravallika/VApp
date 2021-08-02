using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VApp.Entities;

namespace VApp.Models
{
    public class ListModel
    {
        public int EmpId { get; set; }
        public List<DoseType> DoseTypes { get; set; }
        public List<VaccinationName> VaccinationNames { get; set; }
        public VaccineModel VaccineModel { get; set; }
        [Required(ErrorMessage ="Please Upload a file")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.pdf)$", ErrorMessage = "Only pdf files allowed.")]

        public IFormFile File { get; set; }
    }
}
