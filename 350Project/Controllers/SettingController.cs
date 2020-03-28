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
    public class SettingController : Controller
    {
        // GET: Setting
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UsernamePassword model)
        {
            if (model.Member_nick == null && model.confrim_password != null && model.Member_Password !=null) {
                
                string sql = "select Member_Password from dbo.Members where Member_Email = '" + Session["Email"] + "'";

                List<string> password = SqlAccess.LoadData<string>(sql);

                string depassword = Password.Decode(password[0]);

                if (depassword != model.confrim_password) {

                    ViewBag.ErrorMessage = "The old password not match your password";

                    return View();
                }

                string newpassword = Password.Encode(model.Member_Password);

                string sql1 = "UPDATE dbo.Members SET Member_Password = @newpassword  where Member_Email = '" + Session["Email"] + "'";


                model.Member_Password = newpassword;

                int effectdata = SqlAccess.SaveData(sql1, model);

                TempData["Message"] = "Update success";

                return RedirectToAction("Index","Dashboard");
            }

            if (model.Member_Password == null && model.Member_nick != null) {

                string sql1 = "UPDATE dbo.Members SET Member_nick = @Member_nick  where Member_Email = '" + Session["Email"] + "'";

                string Member_nick = model.Member_nick;

                int effectdata = SqlAccess.SaveData(sql1, model);

                Session["Username"] = model.Member_nick;

                TempData["Message"] = "Update success";

                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
    }
}