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
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }

        public List<Category> GetAllCategories()
        {
            try
            {
                return _repo.GetAllCategories();
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }

        public Article AddArticle(Article article)
        {
            try
            {
                return _repo.AddArticle(article);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }

        public FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path)
        {
            try
            {
                return _repo.AddFile(file, ArticleId, Path);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }

        public Category AddCategoryToArticle(int id, string CategoryName)
        {
            try
            {
                return _repo.AddCategoryToArticle(id, CategoryName);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }

        public Article GetCurrentArticle(int articleId)
        {
            try
            {
                return _repo.GetCurrentArticle(articleId);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }

        public Article EditArticle(Article EditedArticle)
        {
            try
            {
                return _repo.EditArticle(EditedArticle);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }

        public Article DeleteArticle(int articleId)
        {
            try
            {
                return _repo.DeleteArticle(articleId);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }

        public FileModel DeleteFile(int ArticleID, int FileID)
        {
            try
            {
                return _repo.DeleteFile(ArticleID, FileID);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }

        public FileModel GetCurrentFile(int ArticleID, string File)
        {
            try
            {
                return _repo.GetCurrentFile(ArticleID, File);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }
    }
}
