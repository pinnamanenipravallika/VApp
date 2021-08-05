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
                    return RedirectToAction("Dashboard", "Home");
                }
                if (userdata.RoleId == 2)
                {
                    return RedirectToAction("AdminDashboard", "Home");
                }
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
