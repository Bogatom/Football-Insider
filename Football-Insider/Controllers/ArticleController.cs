using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Football_Insider.ViewModels;
using System.IO;
using MDL;

namespace Football_Insider.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleLogic logic = LogicFactory.CreateArticleLogic();
        ArticleViewModel articleViewModel = new ArticleViewModel();
        CategoryViewModel categoryViewModel = new CategoryViewModel();

        public ActionResult AllArticles()
        {
            articleViewModel.Articles = logic.GetAllArticles();
            return View(articleViewModel);
        }

        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddArticle([Bind()] BindModel article)
        {
            BindModel NewArticle = new BindModel();

            NewArticle._Article = logic.AddArticle(article);

            if (NewArticle._Article.ArticleId != 0)
            {
                Session["Article"] = NewArticle;
                return RedirectToAction("AddImage", "Image", new { es = NewArticle });
            }
            return View();
        }
    }
}