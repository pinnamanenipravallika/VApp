using System;

namespace VApp.Models
{
    public class SearchModel
    {
        public string SearchKey { get; set; }// empName, mobile, vaccineName, email
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int DoseType { get; set; }
        public string VaccineName { get; set; }

    }
}
