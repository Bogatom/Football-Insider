using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DAL.Contexts;
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
    }
}
