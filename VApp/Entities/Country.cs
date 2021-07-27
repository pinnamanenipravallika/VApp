﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VApp.Entities
{
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();
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

        [InverseProperty(nameof(State.Country))]
        public virtual ICollection<State> States { get; set; }
    }
}