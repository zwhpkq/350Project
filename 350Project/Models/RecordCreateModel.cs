using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace _350Project.Models
{
    public class RecordCreateModel
    {
        public string record_time { get; set; }

        [Display(Name = "Height (in CM)")]
        [Required(ErrorMessage = "You must enter your height")]
        [Range(1, 300, ErrorMessage = "Need to enter a valid height")]
        public float height { get; set; }

        [Display(Name = "Weight (in KG)")]
        [Required(ErrorMessage = "You must enter your weight")]
        [Range(1, 300, ErrorMessage = "Need to enter a valid weight")]
        public float weight { get; set; }

        public float bmi { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "You must enter your age")]
        [Range(1, 150, ErrorMessage = "Need to enter a valid age")]
        public int age { get; set; }


        [Display(Name = "Neck (in CM)")]
        [Required(ErrorMessage = "You must enter your neck circumference")]
        [Range(1, 150, ErrorMessage = "Need to enter a valid value")]
        public int Neck { get; set; }

        [Display(Name = "waist (in CM)")]
        [Required(ErrorMessage = "You must enter your waist circumference")]
        [Range(1, 200, ErrorMessage = "Need to enter a valid value")]
        public int Waist { get; set; }

        [Display(Name = "Hip (in CM)")]
        [Required(ErrorMessage = "You must enter your hip circumference")]
        [Range(1, 150, ErrorMessage = "Need to enter a valid value")]
        public int Hip { get; set; }


        [Display(Name = "Using BMI method to calculate")]
        public bool Defaultvalue { get; set; }


        public float bmr { get; set; }

        public float Fat_Percent { get; set; }

        public float Fat_Mass { get; set; }

    }
}