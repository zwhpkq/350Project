using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _350Project.Models
{
    public class CoachModel
    {
        public int Coach_ID { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Coach_Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Coach_Email { get; set; }
    }
}