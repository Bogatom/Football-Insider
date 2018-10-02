using DAL;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class ArticleLogic : IArticleLogic
    {
        IArticleRepository _repo;

        public ArticleLogic(IArticleRepository repo)
        {
            _repo = repo;
        }

        public List<Article> GetAllArticles()
        {
            return _repo.GetAllArticles();
        }

        public List<Category> GetAllCategories()
        {
            return _repo.GetAllCategories();
        }

        public Article AddArticle(BindModel article)
        {
            return _repo.AddArticle(article);
        }

        public FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path)
        {
            return _repo.AddFile(file, ArticleId, Path);
        }
    }
}
