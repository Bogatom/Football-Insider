using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using DAL.Contexts;
using Interfaces_UI_BLL;
using MDL;

namespace DAL
{
    public class ArticleRepository : IArticleRepository
    {
        IArticleContext _context;

        public ArticleRepository(IArticleContext context)
        {
            _context = context;
        }

        public List<Article> GetAllArticles()
        {
            return _context.GetAllArticles();
        }

        public List<Category> GetAllCategories()
        {
            return _context.GetAllCategories();
        }

        public Article AddArticle(BindModel article)
        {
            return _context.AddArticle(article);
        }

        public FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path)
        {
            return _context.AddFile(file, ArticleId, Path);
        }

        public Category AddCategoryToArticle(int id, string CategoryName)
        {
            return _context.AddCategoryToArticle(id, CategoryName);
        }

        public Article GetCurrentArticle(int articleId)
        {
            return _context.GetCurrentArticle(articleId);
        }

        public Article EditArticle(BindModel EditedArticle)
        {
            return _context.EditArticle(EditedArticle);
        }

        public FileModel DeleteFile(int articleId, string image)
        {
            return _context.DeleteFile(articleId, image);
        }

        public Article DeleteArticle(int articleId)
        {
            return _context.DeleteArticle(articleId);
        }
    }
}
