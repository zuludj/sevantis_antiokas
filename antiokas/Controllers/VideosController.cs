using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using antiokas.Models;

namespace antiokas.Controllers
{
    public class VideosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VideoAssets
        public ActionResult Index()
        {
            return View(db.Videos.ToList());
        }

        // GET: VideoAssets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video videoAsset = db.Videos.Find(id);
            if (videoAsset == null)
            {
                return HttpNotFound();
            }
            return View(videoAsset);
        }

        // GET: VideoAssets/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // POST: VideoAssets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,Title,ReleaseYear,ProductionHouse,Description,Cover,Genre")] Video video,HttpPostedFileBase upload)
        {
            
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(video);
        }

        // GET: VideoAssets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video videoAsset = db.Videos.Find(id);
            if (videoAsset == null)
            {
                return HttpNotFound();
            }
            return View(videoAsset);
        }

        // POST: VideoAssets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ReleaseDate,ReleaseYear,ProductionHouse,Description,Cover,Genre")] Video videoAsset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoAsset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoAsset);
        }

        // GET: VideoAssets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video videoAsset = db.Videos.Find(id);
            if (videoAsset == null)
            {
                return HttpNotFound();
            }
            return View(videoAsset);
        }

        // POST: VideoAssets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video videoAsset = db.Videos.Find(id);
            db.Videos.Remove(videoAsset);
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
