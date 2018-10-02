using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;

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

        public Article AddArticle(BindModel article)
        {
            throw new NotImplementedException();
        }

        public FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path)
        {
            throw  new NotImplementedException();
        }
    }
}
