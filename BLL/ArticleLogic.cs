using DAL;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class ArticleLogic : IArticleLogic
    {
        IArticleRepository _repo;
        private ArticleRepository articleRepository;

        public ArticleLogic(IArticleRepository repo)
        {
            _repo = repo;
        }

        public List<Article> GetAllArticles()
        {
            return _repo.GetAllArticles();
        }
    }
}
