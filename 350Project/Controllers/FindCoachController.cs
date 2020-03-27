using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _350Project.Models
{
    public class FindCoachController : Controller
    {
        // GET: FindCoach
        public ActionResult Index()
        {
            string sql = " Select * From dbo.FitnessType";

            List<RecordModel> records = SqlAccess.LoadData<RecordModel>(sql);


            return View(records);
            
        }
    }
}