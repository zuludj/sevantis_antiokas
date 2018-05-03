using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using antiokas.Models;

namespace antiokas.Controllers
{
    public class VideoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VideoAssets
        public ActionResult Index()
        {
            return View(db.Videos.ToList());
        }

        // GET: Video/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Include(s => s.VideoFiles).SingleOrDefault(s => s.Id == id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
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
        public ActionResult Create([Bind(Include = "Title, Director, Year, Genre, ProductionHouse, Description, Director")]Video video, HttpPostedFileBase upload,HttpPostedFileBase cover)
        {

            //HttpContext.Current.Request.GetBufferlessInputStream(true);
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var vid = new VideoFile
                        {
                            FileName = Path.GetFileName(upload.FileName),
                            FileType = FileType.Vid,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new BinaryReader(upload.InputStream))
                        {

                            vid.Content = reader.ReadBytes(upload.ContentLength);
                        }

                        video.VideoFiles = new List<VideoFile> { vid };
                    }

                    if (cover != null && cover.ContentLength > 0)
                    {
                        var avatar = new Cover
                        {
                            FileName = Path.GetFileName(cover.FileName),
                            FileType = FileType.Avatar,
                            ContentType = cover.ContentType
                        };
                        using (var reader = new BinaryReader(cover.InputStream))
                        {

                            avatar.Content = reader.ReadBytes(cover.ContentLength);
                        }

                        video.Covers = new List<Cover> {avatar };
                    }
                    db.Videos.Add(video);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
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
        public ActionResult Edit([Bind(Include = "Id,Title,Year,ProductionHouse,Description,Genre")] Video videoAsset)
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
