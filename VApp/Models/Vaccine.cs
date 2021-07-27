using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VApp.Models
{
    public class Vaccine
    {
        public int EmployeeID { get; set; }
        public int EmployeeName { get; set; }
        public int VaccineNmae { get; set; }
        public int DoseOne { get; set; }
        public int DoseTwo { get; set; }
        public int VaccinationDateOne { get; set; }
        public int VaccinationDateTwo { get; set; }
    }
}
