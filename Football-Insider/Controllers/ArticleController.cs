using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Football_Insider.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Articles()
        {
            return View("~/Views/Articles/AllArticles.cshtml");
        }

        public ActionResult AddArticle()
        {
            return View("~/Views/Articles/AddArticle.cshtml");
        }
    }
}