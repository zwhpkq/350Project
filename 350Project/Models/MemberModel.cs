﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _350Project.Models
{
    public class MemberModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please give us your first name")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please give us your last name")]
        public String LastName { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please select your gender")]
        public String Gender { get; set; }

        [Display(Name = "Choose Your Plan")]
        [Required(ErrorMessage = "Please select one of our plan")]
        public int MemberPlan { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please give us your email address")]
        public String MemberEmail { get; set; }

        [Display(Name = "Password")]
        [StringLength(20,MinimumLength =6, ErrorMessage = "Your password need to have 6 to 20 characters")]
        [Required(ErrorMessage = "You must have a password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not match your password")]
        public String ConfirmPassword { get; set; }
    }
}