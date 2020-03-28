using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _350Project.Models;
using _350Project.Processor;

namespace _350Project.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Rating()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Rating(RatingModel model)
        {
            model.Member_Id = (int)Session["ID"];
            model.Member_Username = (string)Session["Username"];


            HomeProcessor.UploadRating(model);

            TempData["Message"] = "Rating success";

            return RedirectToAction("Index","Dashboard");
        }
    }
}