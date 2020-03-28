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