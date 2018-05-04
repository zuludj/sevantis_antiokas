using antiokas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using antiokas.Services;

namespace antiokas.Controllers
{
    public class DownloadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private VideoEncryptionService videoEncryptionService = new VideoEncryptionService();
        private string Key = "2398284258975754873468172143535451451658945616465665318";
        // GET: Download
        public ActionResult VideoDownload(int id)
        {
            VideoFile _video = db.VideoFiles.Find(id);
            string value = ASCIIEncoding.ASCII.GetString(_video.Content);
            string inputVideo = value;
            byte[] _keyinbytes = Encoding.ASCII.GetBytes(Key);          
            string _key = ASCIIEncoding.ASCII.GetString(_keyinbytes);
            string video = videoEncryptionService.EncryptOrDecrypt(inputVideo, _key);

            byte[] VideoContent = Encoding.ASCII.GetBytes(video);

            if (_video == null)
            {
                return HttpNotFound();
            }

            return File(VideoContent, "video/mp4", _video.FileName);
        }
    }
}