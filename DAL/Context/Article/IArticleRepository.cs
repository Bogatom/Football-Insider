using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDL;

namespace DAL
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticles();
    }
}
