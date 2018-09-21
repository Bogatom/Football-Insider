using System;
using DAL.Contexts;

namespace DAL
{
    public class ArticleRepositoy
    {
        private IArticleContext context;

        public ArticleRepositoy(StorageType storagetype)
        {
            switch (storagetype)
            {
                case StorageType.Databse:
                    throw new NotImplementedException();
                case StorageType.Memory:
                    context = new ArticleMemoryContext();
                    break;
            }
        }
    }
}
