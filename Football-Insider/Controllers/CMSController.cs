using Factory;
using Football_Insider.ViewModels;
using Interfaces_UI_BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Football_Insider.Controllers
{
    public class CMSController : Controller
    {
        //Bepaal hier of je de Database of de Mock Up Database wilt gebruiken.
        private IArticleLogic logic = LogicFactory.CreateArticleLogic();
        private IHistoryLogic HLogic = LogicFactory.CreateHistoryLogic();

        
        ArticleViewModel articleViewModel = new ArticleViewModel();
        HistoryViewModel historyViewModel = new HistoryViewModel();

        // GET: CMS
        public ActionResult Dashboard()
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

        public ActionResult History()
        {
            try
            {
                historyViewModel.Histories = HLogic.GetHistories();
                return View(historyViewModel);
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