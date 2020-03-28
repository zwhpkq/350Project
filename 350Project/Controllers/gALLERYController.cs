using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _350Project.Models;
using _350Project.Processor;

namespace _350Project.Controllers
{
    public class GalleryController : Controller
    {
        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(ImageModel model)
        {
            string filename = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);

            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;

            model.ImagePath = "~/Image/"+ filename;

            filename = Path.Combine(Server.MapPath("~/Image/"),filename);

            model.ImageFile.SaveAs(filename);

            HomeProcessor.UploadImage(model);

            TempData["Message"] = "Update success";

            return RedirectToAction("Index", "Dashboard");
        }
    }
}