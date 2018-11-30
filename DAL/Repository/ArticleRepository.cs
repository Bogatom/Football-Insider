using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using DAL.Context;
using Interfaces_BLL_DAL;
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

        public Article AddArticle(Article article)
        {
            return _context.AddArticle(article);
        }
       
        public Category AddCategoryToArticle(int id, string CategoryName)
        {
            return _context.AddCategoryToArticle(id, CategoryName);
        }

        public Article GetCurrentArticle(int articleId)
        {
            return _context.GetCurrentArticle(articleId);
        }

        public Article EditArticle(Article EditedArticle)
        {
            return _context.EditArticle(EditedArticle);
        }

        public Article DeleteArticle(int articleId)
        {
            return _context.DeleteArticle(articleId);
        }
    }
}
