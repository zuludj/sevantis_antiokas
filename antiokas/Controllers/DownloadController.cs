using antiokas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using antiokas.Services;
using Xxtea;

namespace antiokas.Controllers
{
    public class DownloadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private string Key = "2398284258975754873468";
        // GET: Download
        public ActionResult VideoDownload(int id)
        {
            VideoFile _video = db.VideoFiles.FirstOrDefault(t=>t.VideoId == id);
            byte[] VideoContent = XXTEA.Encrypt(_video.Content, Key);

            if (_video == null)
            {
                return HttpNotFound();
            }

            return File(VideoContent, "video/mp4", _video.FileName);
        }
    }
}