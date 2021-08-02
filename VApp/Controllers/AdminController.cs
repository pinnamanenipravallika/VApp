using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VApp;
using VApp.Models;
using Microsoft.EntityFrameworkCore;
using VApp.Entities;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;


namespace VApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly VaccinationdbContext _db;

        public AdminController(VaccinationdbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var model = new AdminModel();
            var getEmployeeDetails = _db.Employees.ToList();

            List<EmployeeDataModel> details = new List<EmployeeDataModel>();

                    for (int i = 0; i < getEmployeeDetails.Count; i++)
                    {
                        var empDash = new EmployeeDataModel
                        {
                            ID = getEmployeeDetails[i].Id,
                            Code = getEmployeeDetails[i].Code,
                            FirstName = getEmployeeDetails[i].FirstName,
                            LastName = getEmployeeDetails[i].LastName,
                            Email = getEmployeeDetails[i].Email,
                            Mobile = getEmployeeDetails[i].Mobile,
                            Address = getEmployeeDetails[i].Address,
                            JoiningDate = getEmployeeDetails[i].JoiningDate
                        };
                         

                         var vaccinationDetails = _db.VaccinationDetails.Where(v => v.EmpId == empDash.ID)
                        .Join(_db.VaccinationNames, vd => vd.VccineNameId, vn => vn.Id, (vd, vn) => new { vd, vn })
                        .Join(_db.DoseTypes, vd => vd.vd.DoseTypeId, dt => dt.Id, (vd, dt) => new VaccineListDataModel
                        {
                            VaccinationDetails = vd.vd,
                            VaccinationNames = vd.vn,
                            DoseTypes = dt
                        }).ToList();


                                List<EmployeeVaccinationDataModel> d = new List<EmployeeVaccinationDataModel>();

                                for (int j = 0; j < vaccinationDetails.Count; j++)
                                {

                                    EmployeeVaccinationDataModel empvdetails = new EmployeeVaccinationDataModel
                                    {

                                        VccineName = vaccinationDetails[j].VaccinationNames.Name,
                                        DoseType = vaccinationDetails[j].DoseTypes.DoseType1,
                                        VaccinationDate = vaccinationDetails[j].VaccinationDetails.VaccinationDate,
                                        HospitalName = vaccinationDetails[j].VaccinationDetails.HospitalName,
                                        CertificatePath = vaccinationDetails[j].VaccinationDetails.CertificatePath
                                    };

                                    d.Add(empvdetails);
                                }

                         details.Add(empDash);
                     model.EmpVaccinationData = d;
                     model.EmpData = details;
                    }
            return View(model);
        }



        // [HttpGet]

        //public async Task<ActionResult> Index(string Empsearch)
        //    {
        //        var model = new AdminModel();

        //        var searchRecord = _db.Employees.(Empsearch);

        //        ViewData["GetEmployeeDetails"] = Empsearch;
        //    var emp = from i in _db.Employees select i;
        //    if (!String.IsNullOrEmpty(Empsearch))
        //    {
        //        emp = emp.Where(i => i.FirstName.Contains(Empsearch) || i.Email.Contains(Empsearch) || i.Code.Contains(Empsearch));
        //    }

        //    return View(await emp.AsNoTracking().ToListAsync());
        //}


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteRecord = await _db.Employees.FindAsync(id);
            if (deleteRecord == null)
            {
                return NotFound();

            }
            _db.Employees.Remove(deleteRecord);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Admin");
        }
        [HttpPost]
        public IActionResult PutEmployee(AdminModel employee)
        {
            var dbUpdate = _db.Employees
                .FirstOrDefault(e => e.Id.Equals(employee.EmpData[0].ID));
            dbUpdate.Code = employee.EmpData[0].Code;
            dbUpdate.FirstName = employee.EmpData[0].FirstName;
            dbUpdate.LastName = employee.EmpData[0].LastName;
            dbUpdate.Email = employee.EmpData[0].Email;
            dbUpdate.Mobile = employee.EmpData[0].Mobile;
            dbUpdate.Address = employee.EmpData[0].Address;
            dbUpdate.Id = employee.EmpData[0].ID;
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

   

    }
}

