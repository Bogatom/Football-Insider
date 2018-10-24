using Factory;
using Football_Insider.ViewModels;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interfaces_UI_BLL;
using System.Web.Mvc;

namespace Football_Insider.Controllers
{
    public class CategoryController : Controller
    {
        private IArticleLogic logic = LogicFactory.CreateArticleLogic();
        CategoryViewModel cateogryViewModel = new CategoryViewModel();

        public ActionResult AddCategory(int id)
        {
            cateogryViewModel.Categories = logic.GetAllCategories();
            Session["ArticleId"] = id;
            return View(cateogryViewModel);
        }

        [HttpPost]
        public ActionResult InsertCategory(int id, string CategoryName)
        {
            BindModel bindmodel = new BindModel();
            bindmodel._Category = logic.AddCategoryToArticle(id, CategoryName);
            return RedirectToAction("Dashboard", "CMS");
        }
    }
}