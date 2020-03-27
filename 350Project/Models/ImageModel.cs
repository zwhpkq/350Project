using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace _350Project.Models
{
    public class ImageModel
    {
        public int ImageId { get; set; }

        public string Title { get; set; }

        [DisplayName("Upload File")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}