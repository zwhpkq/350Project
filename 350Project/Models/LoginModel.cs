using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _350Project.Models
{
    public class LoginModel
    {

        [Display(Name = "Email")]
        [Required(ErrorMessage = "You must enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}