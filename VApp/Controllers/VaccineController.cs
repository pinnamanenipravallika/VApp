using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VApp.Entities;
using VApp.Models;

namespace VApp.Controllers
{
        public class VaccineController : Controller
        {
            public IActionResult Index()
            {
                var db = new VaccinationdbContext();
                var listModel = new ListModel();

                var doseTypes = db.DoseTypes.ToList();
                ViewBag.DoseTypes = doseTypes;

                var vaccineNames = db.VaccinationNames.ToList();
                ViewBag.VaccinationNames = vaccineNames;

                listModel.DoseTypes = doseTypes;
                listModel.VaccinationNames = vaccineNames;

            return View(listModel);

            }
            [HttpPost()]
            public IActionResult Insert(ListModel vaccineData)
            {
            var insertData = new VaccinationDetail();
            insertData.EmpId = vaccineData.VaccineModel.EmpId;
            insertData.VccineNameId = vaccineData.VaccineModel.VaccineNameId;
            insertData.DoseTypeId = vaccineData.VaccineModel.DoseTypeId;
            insertData.VaccinationDate = vaccineData.VaccineModel.VaccinationDate;
            insertData.HospitalName = vaccineData.VaccineModel.HospitalName;
            insertData.CertificatePath = vaccineData.VaccineModel.CertificatePath;


            var db = new VaccinationdbContext();
            db.VaccinationDetails.Add(insertData);
            db.SaveChanges();
            return RedirectToAction("Index", "vaccine");
            }
        }
    }

