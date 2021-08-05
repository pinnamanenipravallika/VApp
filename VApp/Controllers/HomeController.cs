using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VApp.Entities;
using VApp.Models;

namespace VApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly VaccinationdbContext _db;

        public HomeController(VaccinationdbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var empId = HttpContext.Session.GetInt32("empId");

            var getEmployeeDetails = _db.Employees.FirstOrDefault(g => g.Id == empId);

            var empDashboard = new EmployeeDataModel();

            empDashboard.Id = getEmployeeDetails.Id;
            empDashboard.Code = getEmployeeDetails.Code;
            empDashboard.FirstName = getEmployeeDetails.FirstName;
            empDashboard.LastName = getEmployeeDetails.LastName;
            empDashboard.Email = getEmployeeDetails.Email;
            empDashboard.Mobile = getEmployeeDetails.Mobile;
            empDashboard.Address = getEmployeeDetails.Address;
            empDashboard.JoiningDate = getEmployeeDetails.JoiningDate;



            var vaccinationDetails = _db.VaccinationDetails.Where(v => v.EmpId == empId).
                Join(_db.VaccinationNames, vd => vd.VccineNameId, vn => vn.Id, (vd, vn) => new { vd, vn })
               .Join(_db.DoseTypes, vd => vd.vd.DoseTypeId, dt => dt.Id, (vd, dt) => new VaccineListDataModel
               {
                   VaccinationDetails = vd.vd,
                   VaccinationNames = vd.vn,
                   DoseTypes = dt
               }).ToList();


            List<EmployeeVaccinationDataModel> details = new List<EmployeeVaccinationDataModel>();

            for (int i = 0; i < vaccinationDetails.Count; i++)
            {

                EmployeeVaccinationDataModel empvdetails = new EmployeeVaccinationDataModel
                {

                    VccineName = vaccinationDetails[i].VaccinationNames.Name,
                    DoseType = vaccinationDetails[i].DoseTypes.DoseType1,
                    VaccinationDate = vaccinationDetails[i].VaccinationDetails.VaccinationDate,
                    HospitalName = vaccinationDetails[i].VaccinationDetails.HospitalName,
                    CertificatePath = vaccinationDetails[i].VaccinationDetails.CertificatePath
                };

                details.Add(empvdetails);

            }
            empDashboard.EmpVaccinationData = details;

            return View(empDashboard);
        }


        [HttpGet]
        public IActionResult AdminDashboard()
        {
            var empId = HttpContext.Session.GetInt32("empId");

            var getEmployeeDetails = _db.Employees.FirstOrDefault(g => g.Id == empId);

            var empDashboard = new EmployeeDataModel();

            empDashboard.Id = getEmployeeDetails.Id;
            empDashboard.Code = getEmployeeDetails.Code;
            empDashboard.FirstName = getEmployeeDetails.FirstName;
            empDashboard.LastName = getEmployeeDetails.LastName;
            empDashboard.Email = getEmployeeDetails.Email;
            empDashboard.Mobile = getEmployeeDetails.Mobile;
            empDashboard.Address = getEmployeeDetails.Address;
            empDashboard.JoiningDate = getEmployeeDetails.JoiningDate;



            var vaccinationDetails = _db.VaccinationDetails.Where(v => v.EmpId == empId).
                Join(_db.VaccinationNames, vd => vd.VccineNameId, vn => vn.Id, (vd, vn) => new { vd, vn })
               .Join(_db.DoseTypes, vd => vd.vd.DoseTypeId, dt => dt.Id, (vd, dt) => new VaccineListDataModel
               {
                   VaccinationDetails = vd.vd,
                   VaccinationNames = vd.vn,
                   DoseTypes = dt
               }).ToList();


            List<EmployeeVaccinationDataModel> details = new List<EmployeeVaccinationDataModel>();

            for (int i = 0; i < vaccinationDetails.Count; i++)
            {

                EmployeeVaccinationDataModel empvdetails = new EmployeeVaccinationDataModel
                {

                    VccineName = vaccinationDetails[i].VaccinationNames.Name,
                    DoseType = vaccinationDetails[i].DoseTypes.DoseType1,
                    VaccinationDate = vaccinationDetails[i].VaccinationDetails.VaccinationDate,
                    HospitalName = vaccinationDetails[i].VaccinationDetails.HospitalName,
                    CertificatePath = vaccinationDetails[i].VaccinationDetails.CertificatePath
                };

                details.Add(empvdetails);

            }
            empDashboard.EmpVaccinationData = details;
            empDashboard.GetAllCountModel = GetAllCount();

            return View(empDashboard);
        }

        private GetAllCountModel GetAllCount()
        {
            var employeeCount = _db.Employees.Count();
            var vaccinationDetails = _db.VaccinationDetails.AsQueryable();
            var notVaccinatedCount = employeeCount - vaccinationDetails.Count();
            var covaxinDose1Count = vaccinationDetails.Where(vd =>
                    vd.DoseTypeId == 1 && vd.VccineNameId == 1).Count();

            var covaxinDose2Count = vaccinationDetails.Where(vd =>
                    vd.DoseTypeId == 2 && vd.VccineNameId == 1).Count();

            var covisheildDose1Count = vaccinationDetails.Where(vd =>
                    vd.DoseTypeId == 1 && vd.VccineNameId == 2).Count();

            var covisheildDose2Count = vaccinationDetails.Where(vd =>
                    vd.DoseTypeId == 2 && vd.VccineNameId == 2).Count();

            var sputnikldDose1Count = vaccinationDetails.Where(vd =>
                    vd.DoseTypeId == 1 && vd.VccineNameId == 3).Count();
            var sputnikldDose2Count = vaccinationDetails.Where(vd =>
                    vd.DoseTypeId == 2 && vd.VccineNameId == 3).Count();
            var firstDoseVaccinationPercentage = (covaxinDose1Count + covisheildDose1Count + sputnikldDose1Count) / employeeCount;
            var secondDoseVaccinationPercentage = (covaxinDose2Count + covisheildDose2Count + sputnikldDose1Count) / employeeCount;
            var notYetVaccinatedPercentage = notVaccinatedCount / employeeCount;

            return new GetAllCountModel()
            {
                TotalEmployee = employeeCount,
                NotYetVaccinated = notVaccinatedCount,
                CovaxinDose1Count = covaxinDose1Count,
                CovaxinDose2Count = covaxinDose2Count,
                CovisheildDose1Count = covisheildDose1Count,
                CovisheildDose2Count = covisheildDose2Count,
                SputnikDose1Count = sputnikldDose1Count,
                SputnikDose2Count = sputnikldDose2Count,
            };

        }
    }
}
