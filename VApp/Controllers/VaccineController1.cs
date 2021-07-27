using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VApp.Models;

namespace VApp.Controllers
{
    public class VaccineController1
    {
        
        public class VaccineController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
            [HttpPost()]
            public IActionResult Vaccine(Vaccine VaccineData)
            {

                return View();
            }
        }
    }
}
