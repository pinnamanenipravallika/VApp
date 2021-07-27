﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VApp.Entities
{
    public partial class State
    {
        public State()
        {
            Districts = new HashSet<District>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("code")]
        [StringLength(20)]
        public string Code { get; set; }
        [Column("countryId")]
        public int? CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("States")]
        public virtual Country Country { get; set; }
        [InverseProperty(nameof(District.State))]
        public virtual ICollection<District> Districts { get; set; }
    }
}