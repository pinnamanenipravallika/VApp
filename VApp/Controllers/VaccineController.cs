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
                //var insertData = new VaccinationDetail();
                //insertData.EmpId = vaccineData.EmpId;

                //var db = new VaccinationdbContext();
                //db.VaccinationDetails.Add(insertData);
                //db.SaveChanges();
                return RedirectToAction("Index", "Vaccine");
            }
        }
    }

