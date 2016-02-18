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

        public ActionResult Directory()
        {

            ClpmDirectory clpmdir = new ClpmDirectory();
            List<CLPM> clpms = new List<CLPM>();
            List<CLPM> clpms2 = new List<CLPM>();
            List<Unit> units = new List<Unit>();
            CLPM clpm1 = new CLPM();
            clpm1.name = "bob Smith";
            clpm1.squadron = "93";
            clpm1.rank = "TSgt";
            CLPM clpm2 = new CLPM();
            clpm2.name = "bob Smith2";
            clpm2.squadron = "94";
            clpm2.rank = "TSgt";

            Unit nine3  = new Unit();
            Unit nine4 = new Unit();
            

            nine3.unitName = "93d";
            clpms.Add(clpm1);
            nine3.Clpms = clpms;


            nine4.unitName = "94th";
            clpms2.Add(clpm2);
            nine4.Clpms = clpms2;
            units.Add(nine3);
            units.Add(nine4);
            clpmdir.directory = units;



            return View(clpmdir);
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