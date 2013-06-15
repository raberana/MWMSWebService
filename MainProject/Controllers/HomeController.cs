using MainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public RedirectToRouteResult Add(User user)
        {
            
            return RedirectToAction("Index", "Home");
        }
        public JsonResult Find(User user)
        {
            JsonResult jsonData = new JsonResult();

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public RedirectToRouteResult Delete(User user)
        {

            return RedirectToAction("Index", "Home");
        }

        public RedirectToRouteResult Edit(User user)
        {

            return RedirectToAction("Index", "Home");
        }
    }
}
