using DAL;
using Interfaces_UI_BLL;
using MDL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Factory
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
            try
            {
                return _repo.GetAllArticles();
            }
            catch (Exception sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
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

        public Category AddCategoryToArticle(int id, string CategoryName)
        {
            return _repo.AddCategoryToArticle(id, CategoryName);
        }

        public Article GetCurrentArticle(int articleId)
        {
            return _repo.GetCurrentArticle(articleId);
        }

        public Article EditArticle(BindModel EditedArticle)
        {
            return _repo.EditArticle(EditedArticle);
        }

        public Article DeleteArticle(int articleId)
        {
            return _repo.DeleteArticle(articleId);
        }

        public FileModel DeleteFile(int ArticleID, int FileID)
        {
            return _repo.DeleteFile(ArticleID, FileID);
        }

        public FileModel GetCurrentFile(int ArticleID, string File)
        {
            return _repo.GetCurrentFile(ArticleID, File);
        }
    }
}
