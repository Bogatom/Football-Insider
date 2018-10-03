using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MDL;
using System.IO;

namespace Football_Insider.Controllers
{
    public class FileController : Controller
    {
        private IArticleLogic logic = LogicFactory.CreateArticleLogic();


        public ActionResult AddFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFile(HttpPostedFileBase[] Files, int ArticleId)
        {
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in Files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        ServerSavePath = "~/UploadedFiles/" + InputFileName;
                        logic.AddFile(file, ArticleId, ServerSavePath);
                        ViewBag.UploadStatus = Files.Count().ToString() + " files uploaded successfully.";
                    }

                }
            }
            return View();
        }
    }
}
