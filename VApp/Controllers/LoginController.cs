using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            return View();
        }
    }
}
