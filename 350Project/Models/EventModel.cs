using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _350Project.Models
{
    public class EventModel
    {
        public int Class_ID { get; set; }

        public int Events_type { get; set; }

        public int Coach_ID { get; set; }

        public DateTime Class_Start { get; set; }

        public DateTime Class_End { get; set; }

        public string Class_Name { get; set; }

        public string Coach_Name { get; set; }

        public int Dayinmonth { get; set; }

        public string typeName { get; set; }


    }
}