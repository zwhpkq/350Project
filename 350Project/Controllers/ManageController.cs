using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _350Project.Models;
using _350Project.DataAccess;
using _350Project.Processor;

namespace _350Project.Controllers
{
    public class ManageController : Controller
    {
        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CoachManage()
        {
            string sql1 = " Select Coach_ID, First_Name,Last_Name,Coach_Gender , Coach_Email From dbo.Coaches";

            List<CoachModel> coaches = SqlAccess.LoadData<CoachModel>(sql1);

            return View(coaches);
        }

        public ActionResult AddCoach()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCoach(CoachModel model)
        {
            string sql1 = " Select Coach_ID From dbo.Coaches";

            List<int> coachid = SqlAccess.LoadData<int>(sql1);

            model.Coach_ID = FindValidId(coachid);

            HomeProcessor.CreateCoach(model);

            return RedirectToAction("CoachManage", "Manage");
        }

        public ActionResult EditCoach(int id) {

            return View();
        }


        [HttpPost]
        public ActionResult EditCoach(int id,CoachModel model)
        {
            model.Coach_ID = id;

            string sql1 = "UPDATE dbo.Coach SET First_Name  = @First_Name, Last_Name = @Last_Name, Coach_Gender = @Coach_Gender, Coach_Email = @Coach_Email where Coach_ID = '"+ id + "'";

            SqlAccess.SaveData(sql1,model);

            return RedirectToAction("CoachManage", "Manage");
        }


        public ActionResult EventManage()
        {
            string sql = " Select Class_ID, Events_type, Coach_ID, Class_Start, Class_End, Class_Name From dbo.Events";

            List<EventModel> events = SqlAccess.LoadData<EventModel>(sql);

            return View(events);
        }

        public ActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEvent(EventModel model)
        {
            string sql1 = " Select Class_ID From dbo.Events";

            List<int> validid = SqlAccess.LoadData<int>(sql1);

            model.Class_ID = FindValidId(validid);

            SqlAccess.SaveData(sql1,model);

            return RedirectToAction("EventManage", "Manage");
        }


        public ActionResult EditEvent(int id)
        {

            return View();
        }

        [HttpPost]
        public ActionResult EditEvent(int id,EventModel model)
        {
            model.Class_ID = id;

            string sql = " UPDATE dbo.Events Events_type = @Events_type, Coach_ID = @Coach_ID, Class_Start = @Class_Start, Class_End = @Class_End, Class_Name= @Class_Name where Class_ID = '" + id+"'";
            
            SqlAccess.SaveData(sql, model);

            return View();
        }


        public ActionResult EditCoachArea(int id) {
            string sql = " Select * From dbo.CoachToType where CoachId = '"+id+"'";

            List<CoachToTypeModel> records = SqlAccess.LoadData<CoachToTypeModel>(sql);

            return View(records);
        }

        public ActionResult AddCTT() {

            return View();
        }

        [HttpPost]
        public ActionResult AddCTT(CoachToTypeModel model)
        {
            string sql = " Select Id From dbo.CoachToType";

            List<int> integers = SqlAccess.LoadData<int>(sql);

            model.Id = FindValidId(integers);

            string sql1 = "insert into dbo.CoachToType (Id, CoachId,TypeID) values ( @Id, @CoachId, @TypeID)";

            SqlAccess.SaveData(sql1,model);

            return View();
        }

        public ActionResult EditCArea(int id) {

            return View();
        }

        [HttpPost]
        public ActionResult EditCArea(int id, CoachToTypeModel model)
        {
            string sql = " UPDATE dbo.CoachToType CoachId = @CoachId, TypeID = @TypeID where Id = '" + id + "'";

            SqlAccess.SaveData(sql, model);

            return View();
        }

        public ActionResult DelectCArea(int id) {
            return View();
        }

        [HttpPost]
        public ActionResult DelectCArea(int id, CoachToTypeModel model)
        {
            string sql = " Delete From dbo.CoachToType where Id = '" + id + "'";

            SqlAccess.SaveData(sql,model);

            return RedirectToAction("Index", "Manage");
        }



        private int FindValidId(List<int> lists) {
            for (int i = 1; i < lists.Count + 1; i++) {
                if (!lists.Contains(i)) {
                    return i;
                
                }
            }

            return lists.Count + 1;
        }

    }
}