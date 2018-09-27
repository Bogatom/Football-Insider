using MDL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contexts
{
    public interface IArticleContext
    {
        List<Article> GetAllArticles();
    }
}
