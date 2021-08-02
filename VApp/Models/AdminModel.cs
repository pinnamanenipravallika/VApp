using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VApp.Entities;

namespace VApp.Models
{
    public class AdminModel
    {
        public List<EmployeeDataModel> EmpData { get; set; }
        public List<EmployeeVaccinationDataModel> EmpVaccinationData { get; set; }
       
    }
}
