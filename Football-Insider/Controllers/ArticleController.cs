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
        public ActionResult AllArticles()
        {
            return View();
        }

        public ActionResult AddArticle()
        {
            return View();
        }
    }
}