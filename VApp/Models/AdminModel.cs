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
       
        public string EmployeeId { get; set; }
       
        //public string EmployeeName { get; set; }

        //public string Designation { get; set; }

        //public string Email { get; set; }
        
        //public string MobileNumber { get; set; }

        //public string Address { get; set; }
        
        //public string IsVaccinated { get; set; }
        
        //public string IsAffected { get; set; }
        
        //public string RecoveryDate { get; set; }
        
        //public int RecoveryDuration { get; set; }
        
        //public string VaccineName { get; set; }       

        //public string VaccinationDateOne { get; set; }

        public List<EmployeeDataModel> EmpData { get; set; }
        public List<EmployeeVaccinationDataModel> EmpVaccinationData { get; set; }
    }
}
