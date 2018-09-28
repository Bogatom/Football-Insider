using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;

namespace Factory
{
    public class LogicFactory
    {
        public static IArticleLogic CreateArticleLogic()
        {
            return new ArticleLogic(new ArticleRepository(new ArticleDatabaseContext()));
        }
    }
}
