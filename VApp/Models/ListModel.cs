using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VApp.Entities;

namespace VApp.Models
{
    public class ListModel
    {
        public List<DoseType> DoseTypes { get; set; }
        public List<VaccinationName> VaccinationNames { get; set; }
        public VaccineModel VaccineModel { get; set; }

        public IFormFile File { get; set; }
    }
}
