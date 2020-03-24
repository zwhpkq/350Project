using _350Project.Models;
using System.Web.Mvc;
using static _350Project.Processor.MemberProcessor;

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
    }
}