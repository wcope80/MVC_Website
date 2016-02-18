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
using System.IO;

namespace MVC_Website.Controllers
{
    public class PhotoGalleriesController : Controller
    {
        private MVC_WebsiteContext db = new MVC_WebsiteContext();

        public ActionResult test()
        {
            return View();
        }

        public ActionResult PhotoGallery()
        {
            var photosModel = new PhotoGallery();
            var photoFiles = Directory.GetFiles(Server.MapPath("~/Content/photos"));
            foreach (var item in photoFiles)
            {
                photosModel.PhotoList.Add(Path.GetFileName(item));
            }

            return View(photosModel);
        }


        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImageMethod()
        {
            if (Request.Files.Count != 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
                    int fileSize = file.ContentLength;
                    string fileName = file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/photos/" + fileName));
                    PhotoGallery photoGallery = new PhotoGallery();
                    photoGallery.PhotoID = Guid.NewGuid();
                    photoGallery.Name = fileName;
                    photoGallery.PhotoPath = "~/Content/photos/" + fileName;
                    db.PhotoGalleries.Add(photoGallery);
                    db.SaveChanges();
                }
                return Content("Success");
            }
            return Content("failed");
        }
    

        // GET: PhotoGalleries
        public ActionResult Index()
        {
            return View(db.PhotoGalleries.ToList());
        }

        // GET: PhotoGalleries/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGallery photoGallery = db.PhotoGalleries.Find(id);
            if (photoGallery == null)
            {
                return HttpNotFound();
            }
            return View(photoGallery);
        }

        // GET: PhotoGalleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhotoGalleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhotoID,Name,PhotoPath")] PhotoGallery photoGallery)
        {
            if (ModelState.IsValid)
            {
                photoGallery.PhotoID = Guid.NewGuid();
                db.PhotoGalleries.Add(photoGallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photoGallery);
        }

        // GET: PhotoGalleries/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGallery photoGallery = db.PhotoGalleries.Find(id);
            if (photoGallery == null)
            {
                return HttpNotFound();
            }
            return View(photoGallery);
        }

        // POST: PhotoGalleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotoID,Name,PhotoPath")] PhotoGallery photoGallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photoGallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photoGallery);
        }

        // GET: PhotoGalleries/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGallery photoGallery = db.PhotoGalleries.Find(id);
            if (photoGallery == null)
            {
                return HttpNotFound();
            }
            return View(photoGallery);
        }

        // POST: PhotoGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PhotoGallery photoGallery = db.PhotoGalleries.Find(id);
            db.PhotoGalleries.Remove(photoGallery);
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
