using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Football_Insider.ViewModels;

namespace Football_Insider.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleLogic logic = LogicFactory.CreateArticleLogic();

        public ActionResult AllArticles()
        {
            ArticleViewModel articleViewModel = new ArticleViewModel();
            articleViewModel.Articles = logic.GetAllArticles();
            return View(articleViewModel);

        }

        public ActionResult AddArticle()
        {
            return View();
        }
    }
}