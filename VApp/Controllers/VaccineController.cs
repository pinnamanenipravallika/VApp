using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using VApp.Entities;
using VApp.Models;

namespace VApp.Controllers
{
    public class VaccineController : Controller
    {
        private readonly VaccinationdbContext _db;
        private int? empId;
        private int? roleId;
        public VaccineController(VaccinationdbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            empId = HttpContext.Session.GetInt32("empId");
            ViewBag.EmpId = empId;

            roleId = HttpContext.Session.GetInt32("roleId");
            ViewBag.IsAdmin = roleId == 2;

            var listModel = new ListModel();

            var doseTypes = _db.DoseTypes.ToList();
            ViewBag.DoseTypes = doseTypes;

            var vaccineNames = _db.VaccinationNames.ToList();
            ViewBag.VaccinationNames = vaccineNames;

            listModel.DoseTypes = doseTypes;
            listModel.VaccinationNames = vaccineNames;
            listModel.EmpId = (int)empId;


            return View(listModel);

        }
        [HttpPost()]
        public IActionResult Insert(ListModel vaccineData)
        {
            empId = HttpContext.Session.GetInt32("empId");
            ViewBag.EmpId = empId;

            roleId = HttpContext.Session.GetInt32("roleId");
            ViewBag.IsAdmin = roleId == 2;

            var insertData = new VaccinationDetail();
            var vaccinationDoseCount = _db.VaccinationDetails.Where(vd => vd.EmpId == vaccineData.EmpId).Count();

            if (vaccinationDoseCount < 2)
            {
                if (vaccineData.File != null && vaccineData.VaccineModel.VaccinationDate != null && vaccineData.VaccineModel.HospitalName != null)
                {
                    insertData.EmpId = vaccineData.EmpId;
                    insertData.VccineNameId = vaccineData.VaccineModel.VaccineNameId;
                    insertData.DoseTypeId = vaccineData.VaccineModel.DoseTypeId;
                    insertData.VaccinationDate = vaccineData.VaccineModel.VaccinationDate;
                    insertData.HospitalName = vaccineData.VaccineModel.HospitalName;

                    if (vaccineData.File.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(vaccineData.File.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        if (fileExtension == ".pdf")
                        {
                            // concatenating  FileName + FileExtension
                            var newFileName = string.Concat(myUniqueFileName, fileExtension);

                            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
                            if (!Directory.Exists(fullPath))
                            {
                                Directory.CreateDirectory(fullPath);
                            }
                            // Combine path + fileName
                            var fileNamePath = new PhysicalFileProvider(fullPath).Root + $@"{newFileName}";

                            using (FileStream fs = System.IO.File.Create(fileNamePath))
                            {
                                vaccineData.File.CopyTo(fs);
                                fs.Flush();
                            }

                            insertData.CertificatePath = newFileName;

                            _db.VaccinationDetails.Add(insertData);
                            _db.SaveChanges();

                            if (ViewBag.IsAdmin)
                            {
                                return RedirectToAction("AdminDashboard", "Home");
                            }
                            else
                            {
                                return RedirectToAction("Dashboard", "Home");
                            }
                        }
                    }
                }
                else
                {
                    ViewData["Message"] = "Please Fill all details";
                }
            }

            return RedirectToAction("Index", "Vaccine");
        }
    }
}

