﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
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
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost()]

        public IActionResult Login(LoginModel loginData)
        {
            var userdata = _db.Employees.FirstOrDefault(e => e.Code == loginData.Code &&
                                                             e.Password == loginData.Password);

            if (userdata != null)
            {
                HttpContext.Session.SetInt32("roleId", (int)userdata.RoleId);

                HttpContext.Session.SetInt32("empId", userdata.Id);

                if (userdata.RoleId == 1)
                {
                    return RedirectToAction("Dashboard", "Login");
                }
                if (userdata.RoleId == 2)
                {
                    return RedirectToAction("AdminDashboard", "Login");
                }
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            var empId = HttpContext.Session.GetInt32("empId");

            var getEmployeeDetails = _db.Employees.FirstOrDefault(g => g.Id == empId);

            var empDashboard = new EmployeeDataModel();

            empDashboard.ID = getEmployeeDetails.Id;
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

            empDashboard.ID = getEmployeeDetails.Id;
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
    }
}
