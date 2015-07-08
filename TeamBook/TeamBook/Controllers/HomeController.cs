using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamBook.DAL;
namespace TeamBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dtList = (new clsDALEmployee().GetEmployeeDetailsByEmployeeId(User.Identity.Name.ToLower()));
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
    }
}