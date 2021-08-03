using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VApp.Entities;
using VApp.Models;

namespace VApp.Controllers
{
    public class AffectedController : Controller
    {
        private readonly VaccinationdbContext _db;
        private int? empId;
        private int? roleId;
        public AffectedController(VaccinationdbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            empId = HttpContext.Session.GetInt32("empId");
            ViewBag.EmpId = empId;

            roleId = HttpContext.Session.GetInt32("roleId");
            ViewBag.IsAdmin = roleId == 2;

            var affectedData = _db.AffectedEmployees.FirstOrDefault(a => a.EmpId == empId);
            var relationships = _db.RelationshipTypes.ToList();
            AffectedModel model = new AffectedModel();
            if (affectedData != null)
            {
                model.IsRecoveryed = affectedData.IsRecoveryed;
                model.RecoveryDuration = affectedData.RecoveryDuration;
                model.IsFamilyAffected = affectedData.IsFamilyAffected;
            }


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
            if (listRelations.Count > 0)
            {
                model.RelationshipTypes = listRelations;
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult Insert(AffectedModel affectedModel)
        {

            empId = HttpContext.Session.GetInt32("empId");
            ViewBag.EmpId = empId;

            roleId = HttpContext.Session.GetInt32("roleId");
            ViewBag.IsAdmin = roleId == 2;

            var data = new AffectedEmployee()
            {
                EmpId = affectedModel.EmpId,
                IsRecoveryed = affectedModel.IsRecoveryed,
                RecoveryDuration = affectedModel.RecoveryDuration,
                IsFamilyAffected = affectedModel.IsFamilyAffected
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
                dataExist.IsFamilyAffected = affectedModel.IsFamilyAffected;
                _db.SaveChanges();
            }

            if (affectedModel.AffectedFamilyModels.Count > 0)
            {
                var affectedFamilies = new List<AffectedFamilyDetail>();

                foreach (var family in affectedModel.AffectedFamilyModels)
                {
                    if (family.MemberName != "no-data")
                    {
                        var affectedFamily = new AffectedFamilyDetail()
                        {
                            EmpId = affectedModel.EmpId,
                            MemberName = family.MemberName,
                            IsRecoveryed = family.IsRecoveryed,
                            RecoveryDuration = family.RecoveryDuration,
                            RelationshipId = family.RelationshipId
                        };
                        affectedFamilies.Add(affectedFamily);
                    }
                }

                if (affectedFamilies.Count > 0)
                {
                    _db.AffectedFamilyDetails.AddRange(affectedFamilies);
                    _db.SaveChanges();
                }
            }
            if (ViewBag.IsAdmin)
            {
                return RedirectToAction("AdminDashboard", "Login");
            }
            else
            {
                return RedirectToAction("Dashboard", "Login");
            }
        }
    }
}
