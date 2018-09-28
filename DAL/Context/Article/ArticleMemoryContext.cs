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
        public List<Article> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }
    }
}
