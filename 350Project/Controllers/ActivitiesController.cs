using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _350Project.Models;
using _350Project.DataAccess;

namespace _350Project.Controllers
{
    public class ActivitiesController : Controller
    {
        // GET: Activities
        public ActionResult Index()
        {
            string sql = " Select Class_ID, Events_type, Coach_ID, Class_Start, Class_End, Class_Name From dbo.Events";

            List<EventModel> events = SqlAccess.LoadData<EventModel>(sql);

            string sql1 = " Select Coach_ID, First_Name,Last_Name,Coach_Gender , Coach_Email From dbo.Coaches";

            List<CoachModel> coaches = SqlAccess.LoadData<CoachModel>(sql1);

            string sql2 = " Select Id,Descript  From dbo.FitnessType";

            List<TypeModel> types = SqlAccess.LoadData<TypeModel>(sql2);


            foreach (EventModel i in events){
                i.Coach_Name = FindCoachById(i.Coach_ID, coaches);
                i.Dayinmonth = i.Class_Start.Day;
                i.typeName = FindTypeById(i.Events_type, types);
            }

           

            return View(events);
        }


        private string FindCoachById(int id, List<CoachModel> coaches) {
            string result = "";
            foreach (CoachModel i in coaches) {
                if (id == i.Coach_ID) {
                    result += i.First_Name;
                    result += " ";
                    result += i.Last_Name;
                    return result;
                }
            }
            return result;
        }

        private string FindTypeById(int id, List<TypeModel> types)
        {
            string result = "";
            foreach (TypeModel i in types)
            {
                if (id == i.Id)
                {
                    result += i.Descript;
                    return result;
                }
            }
            return result;
        }
    }
}