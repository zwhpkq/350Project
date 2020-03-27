using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _350Project.DataAccess;

namespace _350Project.Models
{
    public class FindCoachController : Controller
    {
        // GET: FindCoach
        public ActionResult Index()
        {
            string sql = " Select * From dbo.CoachToType";

            List<CoachToTypeModel> records = SqlAccess.LoadData<CoachToTypeModel>(sql);

            string sql1 = " Select Coach_ID, First_Name,Last_Name,Coach_Gender , Coach_Email From dbo.Coaches";

            List<CoachModel> coaches = SqlAccess.LoadData<CoachModel>(sql1);

            foreach (CoachToTypeModel i in records) {
                i.CoachName = FindCoachById(i.CoachId, coaches);
                i.CoachEmail = FindCoachEmailById(i.CoachId, coaches);
            }

            return View(records);
            
        }

        private string FindCoachById(int id, List<CoachModel> coaches)
        {
            string result = "";
            foreach (CoachModel i in coaches)
            {
                if (id == i.Coach_ID)
                {
                    result += i.First_Name;
                    result += " ";
                    result += i.Last_Name;
                    return result;
                }
            }
            return result;
        }


        private string FindCoachEmailById(int id, List<CoachModel> coaches)
        {
            string result = "";
            foreach (CoachModel i in coaches)
            {
                if (id == i.Coach_ID)
                {
                    result += i.Coach_Email;
                    return result;
                }
            }
            return result;
        }
    }
}