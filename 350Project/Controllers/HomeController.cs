using _350Project.Models;
using System.Web.Mvc;
using static _350Project.Processor.MemberProcessor;
using _350Project.DataAccess;
using System.Collections.Generic;

namespace _350Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Member sign up";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(MemberModel model)
        {
            if (ModelState.IsValid)
            {
                int recordCreate = CreateMember(model.UserName,
                    model.Password,
                    model.FirstName,
                    model.LastName,
                    model.MemberPlan,
                    model.Gender,
                    model.MemberEmail);
            }

            return View();
        }

        [HttpPost]
        public ActionResult IsEmailExists(string MemberEmail)
        {
            string sql = "Select Member_Email From dbo.Members";

            List < string > emails = SqlAccess.LoadData<string>(sql);

            foreach (string i in emails) {
                if (i == MemberEmail) {
                    return Json(false);
                }
            }

            return Json(true);
        }
    }
}