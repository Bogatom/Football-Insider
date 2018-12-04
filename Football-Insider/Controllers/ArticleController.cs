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
using System.Data.SqlClient;

namespace Football_Insider.Controllers
{
    public class ArticleController : Controller
    {
        //Bepaal hier of je de Database of de Mock Up Database wilt gebruiken.
        private IArticleLogic logic = LogicFactory.CreateArticleMemoryLogic();
        ArticleViewModel articleViewModel = new ArticleViewModel();

        public ActionResult AllArticles()
        {
            try
            {
                articleViewModel.Articles = logic.GetAllArticles();
                return View(articleViewModel);
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

        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddArticle([Bind()] Article article)
        {
            try
            {
                Article NewArticle = new Article();
                NewArticle = logic.AddArticle(article);

                if (NewArticle.ArticleId != 0)
                {
                    Session["Article"] = NewArticle;
                    return RedirectToAction("AddFile", "File", new {es = NewArticle});
                }
                return View(article);
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

        public ActionResult EditArticle(int articleId)
        {
            try
            {
                articleViewModel.Article = logic.GetCurrentArticle(articleId);
                return View(articleViewModel);
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
        
        [HttpPost]
        public ActionResult EditArticle(ArticleViewModel articleViewModel)
        {
            try
            {
                Article EditedArticle = new Article();
                EditedArticle = articleViewModel.Article;
                logic.EditArticle(EditedArticle);

                Session["EditedArticle"] = EditedArticle;
                return RedirectToAction("EditFile", "File", new { es = EditedArticle });
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

        public ActionResult ViewArticle(int articleId)
        {
            try
            {
                articleViewModel.Article = logic.GetCurrentArticle(articleId);
                return View(articleViewModel);
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

        public ActionResult DeleteArticle(int articleId)
        {
            try
            {
                logic.DeleteArticle(articleId);
                return RedirectToAction("AllArticles", "Article");
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