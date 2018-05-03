using antiokas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace antiokas.Controllers
{
    public class VideoFileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: VideoFile
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.VideoFiles.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }

}