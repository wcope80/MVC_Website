using System.Linq;
using System.Web.Mvc;


namespace MVC_Website.Controllers
{
    public class FitnessController : Controller
    {
        public DAL.MVC_WebsiteContext db = new DAL.MVC_WebsiteContext();

        public ActionResult MaxAttemptList()
        {
            return View(db.MaxAttempts.ToList());
        }
        
        // GET: Fitness
        public ActionResult MaxAttemptInput()
        {
            return View();
        }
    }
}