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
        ArticleViewModel articleViewModel = new ArticleViewModel();
        CategoryViewModel categoryViewModel = new CategoryViewModel();

        public ActionResult AllArticles()
        {
            articleViewModel.Articles = logic.GetAllArticles();
            return View(articleViewModel);
        }

        public ActionResult AddArticle()
        {
            categoryViewModel.Categories = logic.GetAllCategories();
            return View();
        }
    }
}