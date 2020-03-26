using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _350Project.DataAccess;
using _350Project.Models;
using _350Project.Processor;



namespace _350Project.Controllers
{
    public class RecordController : Controller
    {
        // GET: Activities
        public ActionResult Index()
        {
            string sql = " Select record_time, height, weight, bmi, bmr, Fat_Percent,Fat_Mass From dbo.Bodyinfo Where Membership_ID = '"+ Session["ID"]+ "'";

            List<RecordModel> records = SqlAccess.LoadData<RecordModel>(sql);


            return View(records);
        }


        public ActionResult CreateRecord() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRecord(RecordCreateModel record)
        {
            if (ModelState.IsValid)
            {
                MemberProcessor.CreateARecord(
                    record.height,
                    record.weight,
                    record.age,
                    record.Neck,
                    record.Waist,
                    record.Hip,
                    (string)Session["Gender"],
                    record.Defaultvalue,
                    (int)Session["ID"]
                    );

                return RedirectToAction("Index", "Record");
            }
            else {
                ViewBag.ErrorMessage = "Create fail";
                return View();
            }
        }
    }
}