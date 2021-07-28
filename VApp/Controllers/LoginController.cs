using System.Linq;
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
            return View();
        }

        [HttpPost()]
        public IActionResult Login(LoginModel loginData)
        {
            var userdata = _db.Employees.Where(e => e.Code == loginData.Code &&
                                                    e.Password == loginData.Password).ToList();

            if (userdata.Count > 0)
            {
                return RedirectToAction("Dashboard", "Login");
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
