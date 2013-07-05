using MainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MwmsBusiness;
using ProjectRepository;

namespace MainProject.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			return View();
		}

		public RedirectToRouteResult Add(UserModel user)
		{
			UserManager manager = new UserManager();
			manager.AddUser(user.UserName, user.Password, user.ClientId);
			return RedirectToAction("Index", "Home");
		}

		public JsonResult Find(string userName, string password)
		{
			UserManager manager = new UserManager();
			User user = manager.ValidateUser(userName, password);
			List<User> userLists = new List<User>();
			if (user != null)
			{
				userLists.Add(user);
			}

			return Json(userLists, JsonRequestBehavior.AllowGet);
		}

		public RedirectToRouteResult Delete(UserModel user)
		{

			return RedirectToAction("Index", "Home");
		}

		public RedirectToRouteResult Edit(UserModel user)
		{

			return RedirectToAction("Index", "Home");
		}
	}
}
