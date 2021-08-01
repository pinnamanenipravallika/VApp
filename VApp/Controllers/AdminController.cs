using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VApp;
using VApp.Models;
using Microsoft.EntityFrameworkCore;
using VApp.Entities;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace VApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly VaccinationdbContext _db;

        public AdminController(VaccinationdbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            var displaydata = _db.Employees.ToList();

            return View(displaydata);
        }

        [HttpGet]

        public async Task<ActionResult> Index(string Empsearch)
        {
            ViewData["GetEmployeeDetails"] = Empsearch;
            var emp = from i in _db.Employees select i;
            if(!String.IsNullOrEmpty(Empsearch))
            {
                emp = emp.Where(i => i.FirstName.Contains(Empsearch) || i.Email.Contains(Empsearch) || i.Code.Contains(Empsearch));
            }

            return View(await emp.AsNoTracking().ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteRecord = await _db.Employees.FindAsync(id);
            if (deleteRecord == null)
            {
                return NotFound();

            }
            _db.Employees.Remove(deleteRecord);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index","Admin");
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeDataModel employee)
        {


            return RedirectToAction("Index", "Admin");

        }

    }
}
