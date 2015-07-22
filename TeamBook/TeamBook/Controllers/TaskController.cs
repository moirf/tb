using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TeamBook.BO;
using TeamBook.BAL;
namespace TeamBook.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddMyTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMyTask(string TasksList)
        {
            string resultdata = "success";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer(new SimpleTypeResolver());
           List<Task> TaskList = new List<Task>();
           TaskList = jsSerializer.Deserialize<List<Task>>(TasksList);// Deserialize the list
           var xmlData = (clsBALCommon.ConvertToXMLGeneric<Task>(TaskList));
           ResultModel result = clsBALTask.SaveTasks(xmlData, User.Identity.Name, User.Identity.Name);
             return Json(resultdata);
        }
    }
}