using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VApp.Entities;

namespace VApp.Models
{
    public class VaccineListDataModel
    {
        public DoseType DoseTypes { get; set; }
        public VaccinationName VaccinationNames { get; set; }
        public VaccinationDetail VaccinationDetails { get; set; }
    }
}
