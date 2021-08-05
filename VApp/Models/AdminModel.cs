using System.Collections.Generic;
using VApp.Entities;

namespace VApp.Models
{
    public class AdminModel
    {
        public SearchModel SearchModel { get; set; }
        public List<EmployeeDataModel> EmpDataListModel { get; set; } = new List<EmployeeDataModel>();
        public List<EmployeeVaccinationDataModel> EmpVaccinationDataListModel { get; set; }

        public List<DoseType> DoseTypes { get; set; } = new List<DoseType>();
        public List<VaccinationName> VaccinationNames { get; set; } = new List<VaccinationName>();
    }
}
