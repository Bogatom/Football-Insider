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
    public class ImageController : Controller
    {
        private IArticleLogic logic = LogicFactory.CreateArticleLogic();


        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        public ActionResult AddImage([Bind()] BindModel bindModel)
        {
            Image newimage = bindModel._Image;
            string filename = Path.GetFileNameWithoutExtension(bindModel._Image.ImageFile.FileName);
            string extention = Path.GetExtension(bindModel._Image.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extention;
            bindModel._Image.ImagePath = "~/UploadedFiles/" + filename;
            filename = Path.Combine(Server.MapPath("~/UploadedFiles/"), filename);
            bindModel._Image.ImageFile.SaveAs(filename);
            newimage = logic.AddImage(bindModel);       

            return View();
        }
    }
}