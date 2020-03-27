using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _350Project.Models
{
    public class CoachToTypeModel
    {
        public int Id { get; set; }

        public int CoachId { get; set; }

        public int TypeID { get; set; }

        public string CoachName { get; set; }

        public string CoachEmail { get; set; }

    }
}