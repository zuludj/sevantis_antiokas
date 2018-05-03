using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using antiokas.Models;
using Dapper;
namespace antiokas.Controllers
{
    public class UploadDownloadController : Controller
    {
        // GET: UploadDownload
        public ActionResult FileUpload()
        {
            return View();
        }

        // GET: UploadDownload/Details/5
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase videofiles)
        {
            String FileExt = Path.GetExtension(videofiles.FileName).ToUpper();

            if (FileExt == ".MP4")
            {
                Stream str = videofiles.InputStream;
                BinaryReader Br = new BinaryReader(str);
                Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                Video _video = new Video();
                _video.Title = videofiles.FileName;
                _video.VideoFile = FileDet;
                SaveFileDetails(_video);
                return RedirectToAction("FileUpload");
            }
            else
            {

                ViewBag.FileStatus = "Invalid file format.";
                return View();

            }
          
        }


        [HttpGet]
        public FileResult DownLoadFile(int id)
        {


            List<Video> ObjFiles = GetFileList();

            var FileById = (from FC in ObjFiles
                            where FC.Id.Equals(id)
                            select new { FC.Title, FC.VideoFile }).ToList().FirstOrDefault();

            return File(FileById.VideoFile, "application/mp4", FileById.Title);

        }

        #region View Uploaded files  
        [HttpGet]
        public PartialViewResult FileDetails()
        {
            List<Video> DetList = GetFileList();

            return PartialView("_FileDetails", DetList);


        }
        private List<Video> GetFileList()
        {
            List<Video> DetList = new List<Video>();

            DbConnection();
            con.Open();
            DetList = SqlMapper.Query<Video>(con, "GetVideoDetails",commandType: CommandType.StoredProcedure).ToList();
            con.Close();
            return DetList;
        }

        #endregion


        // GET: UploadDownload/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UploadDownload/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UploadDownload/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UploadDownload/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UploadDownload/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UploadDownload/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region Database related operations  
        private void SaveFileDetails(Video objDet)
        {

            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@Title", objDet.Title);
            Parm.Add("@VideoFile", objDet.VideoFile);
            DbConnection();
            con.Open();
            con.Execute("AddVideosToDB", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();


        }
        #endregion

        #region Database connection  

        private SqlConnection con;
        private string constr;
        private void DbConnection()
        {
            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

        }
        #endregion
    }
}
