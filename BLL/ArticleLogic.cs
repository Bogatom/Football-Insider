using DAL;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ArticleLogic
    {
        private ArticleRepositoy repository = new ArticleRepositoy(StorageType.Database);

        public List<Article> GetAllArticles()
        {
            return repository.GetAllArticles();
        }
    }
}
