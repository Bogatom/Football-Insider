using Factory;
using Football_Insider.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interfaces_UI_BLL;


namespace Football_Insider.Controllers
{
    public class HomeController : Controller
    {
        private IArticleLogic logic = LogicFactory.CreateArticleLogic();
        ArticleViewModel articleViewModel = new ArticleViewModel();

        public ActionResult Index()
        {
            try
            {
                articleViewModel.Articles = logic.GetAllArticles();
                return View(articleViewModel);
            }
            catch (Exception sqlException)
            {
                return View(sqlException.Message);
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}