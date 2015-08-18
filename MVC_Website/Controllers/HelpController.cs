using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Website.DAL;

namespace MVC_Website.Controllers
{
    public class HelpController : Controller
    {
        //private MVC_WebsiteContext db = new MVC_WebsiteContext();
        // GET: Help
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult ContactUsIndex()
        {
            return View();
        }
    }
}