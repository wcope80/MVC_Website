using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Website.Models;
using MVC_Website.DAL;

namespace MVC_Website.Controllers
{
    public class ImageSliderController : Controller
    {
        // GET: ImageSlider
        public ActionResult Index()
        {
            using (MVC_WebsiteContext db = new MVC_WebsiteContext())
            {
                return View(db.Galleries.ToList());
            }
            
        }
        //Add Images in slider
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase imagePath)
        {
            if (imagePath != null)
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(imagePath.InputStream);
                string pic = System.IO.Path.GetFileName(imagePath.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/SliderPhotos/"), pic);
                imagePath.SaveAs(path);
                using (MVC_WebsiteContext db = new MVC_WebsiteContext())
                {
                    Gallery gallery = new Gallery { ImagePath = "~/Content/SliderPhotos/" + pic };
                    db.Galleries.Add(gallery);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteImages()
        {
            using (MVC_WebsiteContext db = new MVC_WebsiteContext())
            {
                return View(db.Galleries.ToList());
            }
        }

        [HttpPost]
        public ActionResult DeleteImages(IEnumerable<int> ImageIDs)
        {
            using (MVC_WebsiteContext db = new MVC_WebsiteContext())
            {
                foreach (var id in ImageIDs)
                {
                    var image = db.Galleries.Single(s => s.ID == id);
                    string imgPath = Server.MapPath(image.ImagePath);
                    if (System.IO.File.Exists(imgPath))
                    {
                        System.IO.File.Delete(imgPath);
                    }
                    db.Galleries.Remove(image);
                }
                db.SaveChanges();
            }
            return RedirectToAction("DeleteImages");

        }

    }
}