using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            AffectedModel model = new AffectedModel();

            var relationships = _db.RelationshipTypes.ToList();

            var listRelations = new List<RelationshipTypeModel>();
            foreach (var item in relationships)
            {
                var relation = new RelationshipTypeModel()
                {
                    Id = item.Id,
                    TypeName = item.TypeName.ToUpper()
                };
                listRelations.Add(relation);
            }
            model.RelationshipTypes = listRelations;

            var empdata = JsonConvert.DeserializeObject<EmployeeDataModel>(HttpContext.Session.GetString("id"));
            ViewBag.EmpId = empdata.ID;

            return View(model);
        }
        [HttpPost]
        public IActionResult Insert(AffectedModel affectedModel)
        {
            //var data = new AffectedEmployee()
            //{
            //    EmpId = affectedModel.EmpId,
            //    IsRecoveryed = affectedModel.IsRecoveryed,
            //    RecoveryDuration = affectedModel.RecoveryDuration,
            //    IsFamilyAffected = affectedModel.IsFamilyAffected
            //};
            //var dataExist = _db.AffectedEmployees.FirstOrDefault(a => a.EmpId == affectedModel.EmpId);
            //if (dataExist == null)
            //{
            //    _db.AffectedEmployees.Add(data);
            //    _db.SaveChanges();
            //}
            //else
            //{
            //    dataExist.IsRecoveryed = affectedModel.IsRecoveryed;
            //    dataExist.RecoveryDuration = affectedModel.RecoveryDuration;
            //    dataExist.IsFamilyAffected = affectedModel.IsFamilyAffected;
            //    _db.SaveChanges();
            //}



            return RedirectToAction("Dashboard", "Login");
        }
    }
}
