using antiokas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace antiokas.Controllers
{
    public class DownloadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Download
        public ActionResult VideoDownload(int id)
        {
            VideoFile _video = db.VideoFiles.Find(id);

            if (_video == null)
            {
                return HttpNotFound();
            }

            return File(_video.Content, "video/mp4", _video.FileName);
        }
    }
}