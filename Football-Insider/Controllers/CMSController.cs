using Factory;
using Football_Insider.ViewModels;
using Interfaces_UI_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Football_Insider.Controllers
{
    public class CMSController : Controller
    {
        private IArticleLogic logic = LogicFactory.CreateArticleLogic();
        ArticleViewModel articleViewModel = new ArticleViewModel();

        // GET: CMS
        public ActionResult Dashboard()
        {
            articleViewModel.Articles = logic.GetAllArticles();
            return View(articleViewModel);
        }
    }
}