using MDL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contexts
{
    internal interface IArticleContext
    {
        IEnumerable<Article> GetAll();
    }
}
