using Factory;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MDL;
using System.IO;
using Interfaces_UI_BLL;

namespace Football_Insider.Controllers
{
    public class FileController : Controller
    {
        //Bepaal hier of je de Database of de Mock Up Database wilt gebruiken.
        private IFileLogic Flogic = LogicFactory.CreateFileLogic();

        public ActionResult AddFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFile(HttpPostedFileBase[] Files, int ArticleId)
        {
            try
            {
                if (ModelState.IsValid)
                {   //iterating through multiple file collection   
                    foreach (HttpPostedFileBase file in Files)
                    {
                        //Checking file is available to save.  
                        if (file != null)
                        {
                            var InputFileName = Path.GetFileName(file.FileName);
                            var ServerSavePath = Path.Combine(Server.MapPath("/UploadedFiles/") + InputFileName);
                            //Save file to server folder  
                            file.SaveAs(ServerSavePath);
                            ServerSavePath = "/UploadedFiles/" + InputFileName;
                            Flogic.AddFile(file, ArticleId, ServerSavePath);
                            ViewBag.UploadStatus = Files.Count().ToString() + " files uploaded successfully.";
                        }

                    }
                }
                return RedirectToAction("AddCategory", "Category", new { id = ArticleId });
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            catch (InvalidCastException invalidCastException)
            {
                throw invalidCastException;
            }
        }

        public ActionResult EditFile()
        {
            return View();
        }

        public ActionResult DeleteFile(int ArticleID, string File)
        {
            try
            {
                FileModel fileModel = Flogic.GetCurrentFile(ArticleID, File);
                Flogic.DeleteFile(ArticleID, fileModel.File_ID);
                return RedirectToAction("EditFile", "File");
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            catch (InvalidCastException invalidCastException)
            {
                throw invalidCastException;
            }
        }
    }
}
