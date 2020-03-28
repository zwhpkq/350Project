using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _350Project.Models
{
    public class RatingModel
    {
        public int Rate_Id { get; set; }

        public int Mark { get; set; }
        [Required(ErrorMessage = "please type in your review")]
        public string Review { get; set; }

        public int Member_Id { get; set; }

        public string Member_Username { get; set; }
    }
}