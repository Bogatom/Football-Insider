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
        //Bepaal hier of je de Database of de Mock Up Database wilt gebruiken.
        private ICategoryLogic Clogic = LogicFactory.CreateCategoryMemoryLogic();
        private IArticleLogic Alogic = LogicFactory.CreateArticleMemoryLogic();
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
                newCategory = Alogic.AddCategoryToArticle(id, CategoryName);
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
                newCategory = Alogic.AddCategoryToArticle(id, CategoryName);
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