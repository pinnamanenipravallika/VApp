using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VApp.Entities;
using VApp.Models;

namespace VApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly VaccinationdbContext _db;

        public LoginController(VaccinationdbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult Login(LoginModel loginData)
        {
            var userdata = _db.Employees.FirstOrDefault(e => e.Code == loginData.Code &&
                                                    e.Password == loginData.Password);

            if (userdata != null)
            {
                var empdata = new EmployeeDataModel();

                empdata.Code = userdata.Code;
                empdata.Email = userdata.Email;
                empdata.Address = userdata.Address;
                empdata.FirstName = userdata.FirstName;
                empdata.LastName = userdata.LastName;
                empdata.Mobile = userdata.Mobile;
                empdata.ID = userdata.Id;
                empdata.JoiningDate = userdata.JoiningDate;

                

                return RedirectToAction("Dashboard", "Login", empdata);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult Dashboard(EmployeeDataModel employeeData)
        {

            var vaccinationDetails = _db.VaccinationDetails.Where(v => v.EmpId == employeeData.ID).
                Join(_db.VaccinationNames, vd => vd.VccineNameId, vn => vn.Id, (vd, vn) => new { vd, vn })
               .Join(_db.DoseTypes, vd => vd.vd.DoseTypeId, dt => dt.Id, (vd, dt) => new VaccineListDataModel
               {
                   VaccinationDetails = vd.vd,
                   VaccinationNames = vd.vn,
                   DoseTypes = dt
               });


            List<EmployeeVaccinationDataModel> details = new List<EmployeeVaccinationDataModel>();

            for (int i = 0; i < vaccinationDetails.ToList().Count; i++)
            {

                EmployeeVaccinationDataModel empvdetails = new EmployeeVaccinationDataModel
                {

                    VccineName = vaccinationDetails.ToList()[i].VaccinationNames.Name,
                    DoseType = vaccinationDetails.ToList()[i].DoseTypes.DoseType1,
                    VaccinationDate = vaccinationDetails.ToList()[i].VaccinationDetails.VaccinationDate,
                    HospitalName = vaccinationDetails.ToList()[i].VaccinationDetails.HospitalName,
                    CertificatePath = vaccinationDetails.ToList()[i].VaccinationDetails.CertificatePath
                };

                details.Add(empvdetails);

            }
            employeeData.EmpVaccinationData = details;
            return View(employeeData);
        }
    }
}
