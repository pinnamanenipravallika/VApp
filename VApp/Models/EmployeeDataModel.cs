using System;
using System.Collections.Generic;

namespace VApp.Models
{
    public class EmployeeDataModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public DateTime JoiningDate { get; set; }
        public GetAllCountModel GetAllCountModel { get; set; }

        public List<EmployeeVaccinationDataModel> EmpVaccinationData { get; set; }

    }
}
