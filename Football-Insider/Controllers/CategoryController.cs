using Factory;
using Football_Insider.ViewModels;
using MDL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Interfaces_UI_BLL;
using System.Web.Mvc;

namespace Football_Insider.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryLogic Clogic = LogicFactory.CreateCategoryLogic();
        private IArticleLogic logic = LogicFactory.CreateArticleLogic();
        CategoryViewModel cateogryViewModel = new CategoryViewModel();

        public ActionResult AddCategory(int id)
        {
            try
            {
                cateogryViewModel.Categories = Clogic.GetAllCategories();
                Session["ArticleId"] = id;
                return View(cateogryViewModel);
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
        public ActionResult InsertCategory(int id, string CategoryName)
        {
            try
            {
                Category newCategory = new Category();
                newCategory = logic.AddCategoryToArticle(id, CategoryName);
                return RedirectToAction("Dashboard", "CMS");
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

        public ActionResult EditCategory(int id)
        {
            try
            {
                cateogryViewModel.Categories = Clogic.GetAllCategories();
                Session["ArticleId"] = id;
                return View(cateogryViewModel);
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

        public ActionResult EditedCategory(int id, string CategoryName)
        {
            try
            {
                Category newCategory = new Category();
                newCategory = logic.AddCategoryToArticle(id, CategoryName);
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