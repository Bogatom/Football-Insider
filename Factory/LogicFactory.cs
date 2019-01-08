using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces_UI_BLL;
using BLL;
using DAL.Contexts;
using DAL;
using DAL.Contexts.File;
using Interfaces_BLL_DAL;

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

        public static ICategoryLogic CreateCategoryMemoryLogic()
        {
            return new CategoryLogic(new CategoryRepository(new CategoryMemoryContext()));
        }

        public static IFileLogic CreateFileLogic()
        {
            return new FileLogic(new FileRepository(new FileDatabaseContext()));
        }

        public static IFileLogic CreateFileMemoryLogic()
        {
            return new FileLogic(new FileRepository(new FileMemoryContext()));
        }

        public static IHistoryLogic CreateHistoryLogic()
        {
            return new HistoryLogic(new HistoryRepository(new HistoryDatabaseContext()));
        }
    }
}
