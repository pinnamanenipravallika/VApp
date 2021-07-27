using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VApp.Entities;
using VApp.Models;

namespace VApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost()]
        public IActionResult Login(LoginModel loginData)
        {
            VaccinationdbContext db = new VaccinationdbContext();
            var userdata = db.Employees.Where(e => e.Code == loginData.Code && e.Password == loginData.Password);
           
           return RedirectToAction("Dashboard","Login");
            

        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
        //Tanmayi
    }
}
