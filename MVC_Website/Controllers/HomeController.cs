using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Website.Models;

namespace MVC_Website.Controllers
{
    public class HomeController : Controller
    {
        public DAL.MVC_WebsiteContext db = new DAL.MVC_WebsiteContext();

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
            ViewBag.Message = "My Contact Info:";

            return View();
        }

        public ActionResult SendMessage()
        {
            Message message = new Message();
            return View(message);
        }

        [HttpPost]
        public ActionResult SendMessage(Message msg)
        {
            try
            {
                db.Messages.Add(msg);
                return RedirectToAction("Contact", "Home");
            }
            catch
            {
                return View(msg);
            }
        }
    }
}