﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VApp.Entity
{
    public partial class sp_searchbyResult
    {
        public string employeeID { get; set; }
        public string employeeName { get; set; }
        public string mobileNumber { get; set; }
        public string address { get; set; }
        public string designation { get; set; }
        public string email { get; set; }
        public string IsVaccinated { get; set; }
        public string IsAffected { get; set; }
        public DateTime? RecoveryDate { get; set; }
        public int? RecoveryDuration { get; set; }
        public string VaccineName { get; set; }
        public DateTime? VaccinationDateOne { get; set; }
    }
}
