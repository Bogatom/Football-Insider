using System;
using System.Collections.Generic;
using DAL.Contexts;
using MDL;

namespace DAL
{
    public class ArticleRepositoy
    {
        private IArticleContext context;

        public ArticleRepositoy(StorageType storagetype)
        {
            switch (storagetype)
            {
                case StorageType.Database:
                    context = new ArticleDatabaseContext();
                    break;
                case StorageType.Memory:
                    context = new ArticleMemoryContext();
                    break;
            }
        }

        public List<Article> GetAllArticles()
        {
            return context.GetAllArticles();
        }

    }
}
