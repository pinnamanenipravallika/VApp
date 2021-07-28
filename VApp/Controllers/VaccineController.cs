using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
            //var insertData = new VaccinationDetail();
            //insertData.EmpId = vaccineData.EmpId;

            //var db = new VaccinationdbContext();
            //db.VaccinationDetails.Add(insertData);
            //db.SaveChanges();
            return RedirectToAction("Index", "Vaccine");
        }
    }
}

