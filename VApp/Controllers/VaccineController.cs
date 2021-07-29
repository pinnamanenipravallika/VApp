using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using VApp.Entities;
using VApp.Models;

namespace VApp.Controllers
{
    public class VaccineController : Controller
    {
        private readonly VaccinationdbContext _db;

        public VaccineController(VaccinationdbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var listModel = new ListModel();

            var doseTypes = _db.DoseTypes.ToList();
            ViewBag.DoseTypes = doseTypes;

            var vaccineNames = _db.VaccinationNames.ToList();
            ViewBag.VaccinationNames = vaccineNames;

            listModel.DoseTypes = doseTypes;
            listModel.VaccinationNames = vaccineNames;

            return View(listModel);

            }
            [HttpPost()]
            public IActionResult Insert(ListModel vaccineData)
            {
            var insertData = new VaccinationDetail();
                        
          
            if (vaccineData.File != null && vaccineData.VaccineModel.EmpId != null && vaccineData.VaccineModel.VaccineNameId != null && vaccineData.VaccineModel.DoseTypeId != null && vaccineData.VaccineModel.VaccinationDate != null && vaccineData.VaccineModel.HospitalName != null)
            {
                insertData.EmpId = vaccineData.VaccineModel.EmpId;
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

                    if(fileExtension == ".pdf")
                    {
                    // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        insertData.CertificatePath = newFileName;
                   
                        // Combines two strings into a path.
                        var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads")).Root + $@"{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            vaccineData.File.CopyTo(fs);
                            fs.Flush();
                        }

                        _db.VaccinationDetails.Add(insertData);
                        _db.SaveChanges();
                        return RedirectToAction("Dashboard", "Login");

                    }
                }

            }
            else
            {
                ViewData["Message"] = "Please Fill all details";

            }


            return RedirectToAction("Index", "vaccine");
            }
        }
    }

