using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Website.DAL;
using MVC_Website.Models;

namespace MVC_Website
{
    public class MaxAttemptsController : Controller
    {
        private MVC_WebsiteContext db = new MVC_WebsiteContext();

        // GET: MaxAttempts
        public ActionResult Index()
        {
            return View(db.MaxAttempts.ToList());
        }

        // GET: MaxAttempts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaxAttempt maxAttempt = db.MaxAttempts.Find(id);
            if (maxAttempt == null)
            {
                return HttpNotFound();
            }
            return View(maxAttempt);
        }

        // GET: MaxAttempts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaxAttempts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaxAttemptId,Exercise,Weight,Reps,CalculatedMax,MaxDate")] MaxAttempt maxAttempt)
        {
            if (ModelState.IsValid)
            {
                db.MaxAttempts.Add(maxAttempt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maxAttempt);
        }

        // GET: MaxAttempts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaxAttempt maxAttempt = db.MaxAttempts.Find(id);
            if (maxAttempt == null)
            {
                return HttpNotFound();
            }
            return View(maxAttempt);
        }

        // POST: MaxAttempts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaxAttemptId,Exercise,Weight,Reps,CalculatedMax,MaxDate")] MaxAttempt maxAttempt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maxAttempt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maxAttempt);
        }

        // GET: MaxAttempts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaxAttempt maxAttempt = db.MaxAttempts.Find(id);
            if (maxAttempt == null)
            {
                return HttpNotFound();
            }
            return View(maxAttempt);
        }

        // POST: MaxAttempts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaxAttempt maxAttempt = db.MaxAttempts.Find(id);
            db.MaxAttempts.Remove(maxAttempt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
