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
        private IArticleLogic logic = LogicFactory.CreateArticleMemoryLogic();
        ArticleViewModel articleViewModel = new ArticleViewModel();

        public ActionResult Index()
        {
            try
            {
                articleViewModel.Articles = logic.GetAllArticles();
                return View(articleViewModel);
            }
            catch (SqlException sqlException)
            {
                return View("Error", sqlException);
            }
            catch (InvalidCastException invalidCastException)
            {
                return View("Error", invalidCastException);
            }
        }

        public ActionResult Error(Exception ex)
        {
            TempData["Error"] = ex;
            return View(TempData["Error"]);
        }
    }
}