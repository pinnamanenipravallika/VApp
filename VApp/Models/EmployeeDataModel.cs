using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VApp.Models
{
    public class EmployeeDataModel
    {
        public int Id { get; set; }
        public string Code { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        [DisplayName("Joining Date")]
        public DateTime JoiningDate { get; set; }
        public GetAllCountModel GetAllCountModel { get; set; }

        public List<EmployeeVaccinationDataModel> EmpVaccinationData { get; set; }

    }
}
