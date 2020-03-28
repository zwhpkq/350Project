using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _350Project.Models;
using _350Project.DataAccess;
using _350Project.Common;


namespace _350Project.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Login(LoginModel model)
        {
            string sql = "Select First_Name, Last_Name, Member_Password, Member_Plan, Member_Gender, Member_Email," +
                " Member_nick, Member_End From dbo.Members Where Member_Email = '"+model.Email+ "' and Member_Password = '"+ Password.Encode (model.Password )+"'";

            string sql_id = "Select Member_ID From dbo.Members Where Member_Email = '" + model.Email + "' and Member_Password = '" + Password.Encode(model.Password) + "'";


            List<MemberSubmitModel> member = SqlAccess.LoadData<MemberSubmitModel>(sql);

            List<int> userID = SqlAccess.LoadData<int>(sql_id);

            if (member.Count == 0)
            {
                ViewBag.Errormessage = "Please check your email and password";
                return View();
            }

            else 
            {
                Session["ID"] = userID[0];
                Session["Username"] = member[0].Member_nick;
                Session["Firstname"] = member[0].First_Name;
                Session["Lastname"] = member[0].Last_Name;
                Session["Email"] = member[0].Member_Email;
                Session["MembershipTill"] = member[0].Member_End;
                Session["Password"] = Password.Decode(member[0].Member_Password);
                Session["Gender"] = member[0].Member_Gender;
                return RedirectToAction("Index", "Dashboard");
            }
        }

        public ActionResult Logout() {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}