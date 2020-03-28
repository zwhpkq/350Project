using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace _350Project.Models
{
    public class MemberModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please give us a user name")]
        public String UserName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please give us your first name")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please give us your last name")]
        public String LastName { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please select your gender")]
        public String Gender { get; set; }

        [Range(1, 6, ErrorMessage = "Need to choose a valid plan")]
        [Display(Name = "Choose Your Plan")]
        [Required(ErrorMessage = "Please select one of our plan")]
        public int MemberPlan { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Remote("IsEmailExists", "Home",HttpMethod ="POST" ,ErrorMessage = "Email already in use")]
        [Required(ErrorMessage = "Please give us your email address")]
        public String MemberEmail { get; set; }

        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Your password need to have 6 to 20 characters")]
        [Required(ErrorMessage = "You must have a password")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}", ErrorMessage = "Your password must contain at least one letter and one number")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not match your password")]
        public String ConfirmPassword { get; set; }
    }
}