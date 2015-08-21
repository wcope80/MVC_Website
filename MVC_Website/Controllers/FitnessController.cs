using System.Linq;
using System.Web.Mvc;
using MVC_Website.Models;
using System.Collections.Generic;

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
        [HttpGet]
        public ActionResult MaxAttemptInput()
        {
            MaxAttempt maxAttempt = new MaxAttempt();
            ViewBag.exerciseList = new SelectList(ExerciseList(), "Value", "Text");
            return View(maxAttempt);
        }
        [HttpPost]
        public ActionResult MaxAttemptInput(MaxAttempt maxAttempt)
        {
             if (ModelState.IsValid)
            {
                double dweight = System.Convert.ToDouble(maxAttempt.Weight);
                double dreps = System.Convert.ToDouble(maxAttempt.Reps);
                maxAttempt.CalculatedMax = System.Convert.ToInt16(.0333 * dweight * dreps + dweight);
                db.MaxAttempts.Add(maxAttempt);
                db.SaveChanges();
                return RedirectToAction("MaxAttemptList", "Fitness");
            }

            return View(maxAttempt);
        }

        public IEnumerable<SelectListItem> ExerciseList()
	        {
            List<SelectListItem> exerciseList = new List<SelectListItem>()
	            {
                new SelectListItem() { Text = "Deadlift", Value = "Deadlift" },
                new SelectListItem() { Text = "Back Squat", Value = "Back Squat" },
	            new SelectListItem() { Text = "Bench Press", Value = "Bench Press" },
                new SelectListItem() { Text="Overhead Press", Value ="Overhead Press"}
	            };
	            return exerciseList;
	        }

    }
}