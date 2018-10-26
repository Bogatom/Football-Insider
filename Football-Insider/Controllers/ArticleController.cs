using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Football_Insider.ViewModels;
using System.IO;
using MDL;
using Factory;
using Interfaces_UI_BLL;

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
                return RedirectToAction("AddFile", "File", new {es = NewArticle});
            }
            return View(article);
        }

        public ActionResult EditArticle(int articleId)
        {
            articleViewModel.Article = logic.GetCurrentArticle(articleId);
            return View(articleViewModel);
        }


        [HttpPost]
        public ActionResult EditArticle(ArticleViewModel articleViewModel)
        {
            BindModel EditedArticle = new BindModel();
            EditedArticle._Article = articleViewModel.Article;
            logic.EditArticle(EditedArticle);


            Session["EditedArticle"] = EditedArticle;
            return RedirectToAction("EditFile", "File", new {es = EditedArticle});
        }

        public ActionResult ViewArticle(int articleId)
        {
            articleViewModel.Article = logic.GetCurrentArticle(articleId);
            return View(articleViewModel);
        }

    }
}