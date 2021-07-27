﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VApp.Entities
{
    public partial class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        [StringLength(120)]
        public string Code { get; set; }
        [Required]
        [Column("firstName")]
        public string FirstName { get; set; }
        [Column("lastName")]
        public string LastName { get; set; }
        [Required]
        [Column("email")]
        public string Email { get; set; }
        [Required]
        [Column("mobile")]
        [StringLength(10)]
        public string Mobile { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("joiningDate", TypeName = "date")]
        public DateTime JoiningDate { get; set; }
        [Column("relesaeDate", TypeName = "date")]
        public DateTime? RelesaeDate { get; set; }
        [Column("createdBy")]
        public int CreatedBy { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column("updatedBy")]
        public int? UpdatedBy { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("statusFlag")]
        public bool? StatusFlag { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("roleId")]
        public int? RoleId { get; set; }
        [Column("reportingManagerId")]
        public int? ReportingManagerId { get; set; }
        [Column("bgId")]
        public int? BgId { get; set; }
        [Column("designationId")]
        public int? DesignationId { get; set; }
        [Column("countryId")]
        public int? CountryId { get; set; }
        [Column("stateId")]
        public int? StateId { get; set; }
        [Column("districtId")]
        public int? DistrictId { get; set; }
        [Column("talukId")]
        public int? TalukId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(RoleType.Employees))]
        public virtual RoleType Role { get; set; }
    }
}