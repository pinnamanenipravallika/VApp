using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VApp.Entities;
using VApp.Models;

namespace VApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly VaccinationdbContext _db;

        public AdminController(VaccinationdbContext db)
        {
            _db = db;
        }
        public IActionResult Index(SearchModel searchModel)
        {
            var filter = searchModel.SearchKey;

            var searchDataList = _db.Employees
                .Join(_db.VaccinationDetails, e => e.Id, vd => vd.EmpId, (employee, vaccinationDetails) => new { employee, vaccinationDetails })
                .Join(_db.VaccinationNames, x => x.vaccinationDetails.VccineNameId, vn => vn.Id, (employeeVaccination, vaccineNames) => new { employeeVaccination, vaccineNames })
                .Select(x => new SearchDataModel
                {
                    Id = x.employeeVaccination.employee.Id,
                    Code = x.employeeVaccination.employee.Code,
                    FirstName = x.employeeVaccination.employee.FirstName,
                    LastName = x.employeeVaccination.employee.LastName,
                    Email = x.employeeVaccination.employee.Email,
                    Mobile = x.employeeVaccination.employee.Mobile,
                    Address = x.employeeVaccination.employee.Address,
                    JoiningDate = x.employeeVaccination.employee.JoiningDate.ToString("dd-MMM-yyyy"),
                    VccineName = x.vaccineNames.Name,
                    VaccinationDate = ((DateTime)x.employeeVaccination.vaccinationDetails.VaccinationDate)
                    .ToString("dd-MMM-yyyy"),
                    HospitalName = x.employeeVaccination.vaccinationDetails.HospitalName,
                    DoseType = x.employeeVaccination.vaccinationDetails.DoseTypeId,
                }).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                searchDataList = searchDataList.Where(x =>
                    x.FirstName == filter.Trim() ||
                    x.Email == filter.Trim() ||
                    x.Mobile == filter.Trim() ||
                    x.Code == filter.Trim());
            }

            if (searchModel.FromDate != null && searchModel.FromDate != DateTime.MinValue &&
                searchModel.ToDate != null && searchModel.ToDate != DateTime.MinValue)
            {
                searchDataList = searchDataList.Where(e =>
                    DateTime.Parse(e.JoiningDate) >= searchModel.FromDate &&
                    DateTime.Parse(e.JoiningDate) <= searchModel.ToDate);
            }
            if (searchModel.VaccineName != "Select" && searchModel.VaccineName != null)
            {
                searchDataList = searchDataList.Where(x => x.VccineName == searchModel.VaccineName);
            }

            if (searchModel.DoseType != 0 && searchModel.VaccineName != null)
            {
                searchDataList = searchDataList.Where(x => x.DoseType == searchModel.DoseType);
            }

            var results = searchDataList.ToList();

            //var empData = searchDataList.Select(s => s.data.empData.employee).ToList();
            //var vacineData = searchDataList.Select(s => s.data.empData.vaccinationData).ToList();

            var model = new AdminModel();
            model.SearchModel = searchModel;

            List<SearchDataModel> empDataList = new List<SearchDataModel>();
            foreach (var item in results)
            {
                var data = new SearchDataModel()
                {
                    Id = item.Id,
                    Code = item.Code,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Address = item.Address,
                    Mobile = item.Mobile,
                    Email = item.Email,
                    JoiningDate = item.JoiningDate,
                    VccineName = item.VccineName,
                    VaccinationDate = item.VaccinationDate,
                    DoseType = item.DoseType,
                    HospitalName = item.HospitalName
                };
                //if (empDataList.FirstOrDefault(x => x.Code == data.Code) == null)
                empDataList.Add(data);
            }


            model.EmpDataListModel = empDataList;


            var doseTypes = _db.DoseTypes.ToList();
            model.DoseTypes = doseTypes;
            var vaccineNames = _db.VaccinationNames.ToList();
            model.VaccinationNames = vaccineNames;

            return View(model);

        }

    }
}
