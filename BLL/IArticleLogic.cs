using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IArticleLogic
    {
        List<Article> GetAllArticles();
        List<Category> GetAllCategories();
    }
}
