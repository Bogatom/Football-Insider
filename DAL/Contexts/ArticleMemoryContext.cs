using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DAL.Contexts
{
    internal class ArticleMemoryContext : IArticleContext
    {
        private static List<Article> articles = new List<Article>();
        private static bool isInitialized = false;

        public ArticleMemoryContext()
        {
            if (!isInitialized)
            {
                //hier komt database gebeuren.
                isInitialized = true;
            }
        }

        public void Create(Article article)
        {
            article.ArticleId = GetNextId();
            articles.Add(article);
        }

        public Article Get(int id) => articles.Single(p => p.ArticleId == id);
        public IEnumerable<Article> GetAll() => articles;

        private int GetNextId() => articles.Max(p => p.ArticleId) + 1;
    }
}
