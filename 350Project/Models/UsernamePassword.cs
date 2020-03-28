using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _350Project.Models
{
    public class UsernamePassword
    {
        [Display(Name = "Please enter a new username")]
        [Required(ErrorMessage = "Please give us a user name")]
        public string Member_nick { get; set; }


        [Display(Name = "Please enter your old password")]
        [DataType(DataType.Password)]
        public string confrim_password{get; set;}

        [Display(Name = "Please enter a new password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Your password need to have 6 to 20 characters")]
        [Required(ErrorMessage = "You must have a password")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}", ErrorMessage = "Your password must contain at least one letter and one number")]
        [DataType(DataType.Password)]
        public string Member_Password { get; set; }

    }
}