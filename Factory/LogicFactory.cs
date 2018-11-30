using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces_UI_BLL;
using BLL;
using DAL.Context;
using DAL;

namespace Factory
{
    public class LogicFactory
    {
        public static IArticleLogic CreateArticleLogic()
        {
            return new ArticleLogic(new ArticleRepository(new ArticleDatabaseContext()));
        }    

        public static IArticleLogic CreateArticleMemoryLogic()
        {
            return new ArticleLogic(new ArticleRepository(new ArticleMemoryContext()));
        }

        public static ICategoryLogic CreateCategoryLogic()
        {
            return new CategoryLogic(new CategoryRepository(new CategoryDatabaseContext()));
        }
    }
}
