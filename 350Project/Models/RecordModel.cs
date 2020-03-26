using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _350Project.Models
{
    public class RecordModel
    {

        public string record_time { get; set; }

        public float height { get; set; }

        public float weight { get; set; }

        public float bmi { get; set; }

        public float bmr { get; set; }

        public float Fat_Percent { get; set; }

        public float Fat_Mass { get; set; }
    }
}