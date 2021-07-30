using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VApp.Entities;
using VApp.Models;

namespace VApp.Controllers
{
    public class AffectedController : Controller
    {
        private readonly VaccinationdbContext _db;

        public AffectedController(VaccinationdbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.EmpId = 1589;
            return View();
        }
        [HttpPost]
        public IActionResult InsertAffectedEmployee(AffectedModel affectedModel)
        {
            var data = new AffectedEmployee()
            {
                EmpId = affectedModel.EmpId,
                IsRecoveryed = affectedModel.IsRecoveryed,
                RecoveryDuration = affectedModel.RecoveryDuration
            };
            var dataExist = _db.AffectedEmployees.FirstOrDefault(a => a.EmpId == affectedModel.EmpId);
            if (dataExist == null)
            {
                _db.AffectedEmployees.Add(data);
                _db.SaveChanges();
            }
            else
            {
                dataExist.IsRecoveryed = affectedModel.IsRecoveryed;
                dataExist.RecoveryDuration = affectedModel.RecoveryDuration;
                _db.SaveChanges();
            }
            return RedirectToAction("Dashboard", "Login");
        }

        public IActionResult AffectedFamily()
        {
            return View();
        }
    }
}
