using _350Project.Models;
using System.Web.Mvc;
using static _350Project.Processor.HomeProcessor;
using _350Project.DataAccess;
using System.Collections.Generic;
using _350Project.Common;

namespace _350Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Activity()
        {
            return View();
        }

        public ActionResult Coach()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult Review()
        {
            return View();
        }

        public ActionResult Gallary()
        {
            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(MemberModel model)
        {
            if (ModelState.IsValid)
            {
                int recordCreate = CreateMember(model.UserName,
                    Password.Encode(model.Password),
                    model.FirstName,
                    model.LastName,
                    model.MemberPlan,
                    model.Gender,
                    model.MemberEmail);


                string sql = "Select Member_End From dbo.Members Where Member_Email = '" + model.MemberEmail + "' and Member_Password = '" + Password.Encode(model.Password) + "'";

                string sql_id = "Select Member_ID From dbo.Members Where Member_Email = '" + model.MemberEmail + "' and Member_Password = '" + Password.Encode(model.Password) + "'";

                List<string> membertill = SqlAccess.LoadData<string>(sql);

                List<int> userID = SqlAccess.LoadData<int>(sql_id);

                if (userID.Count == 0)
                {
                    return View();
                }
                else
                {
                    Session["ID"] = userID[0];
                    Session["Username"] = model.UserName;
                    Session["Firstname"] = model.FirstName;
                    Session["Lastname"] = model.LastName;
                    Session["Email"] = model.MemberEmail;
                    Session["MembershipTill"] = membertill[0];
                    Session["Password"] = model.Password;
                    Session["Gender"] = model.Gender;

                    string mailbody = "Dear " + model.UserName + ",\n\t Lightweight workout thank you for your registation. We are looking " +
                     "forward to workout with you.\n\n" +
                     "Sincerely,\n\t Team Lightweight Workout";



                    Email.SendEmail(mailbody, model.MemberEmail);

                    return RedirectToAction("Index", "Dashboard");
                }
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