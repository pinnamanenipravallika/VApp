using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Code is required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
