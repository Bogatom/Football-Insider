using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using Interfaces_BLL_DAL;

namespace DAL.Context
{
    public class ArticleMemoryContext : IArticleContext
    {
        List<Article> Articles = new List<Article>();
        List<Category> Categories = new List<Category>();

        public List<Article> GetAllArticles()
        {

            Article article = new Article
            {
                ArticleId = 1,
                Title = "Artikel 1",
                Category = "Opmerkelijk",
                Content = "Lorem Ipsum",
                CreationDate = DateTime.Now.ToShortDateString()
            };
            Articles.Add(article);

            return Articles;
        }

        public Article AddArticle(Article article)
        {
            Articles.Add(article);
            return article;
        }

        public FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path)
        {
            throw new NotImplementedException();
        }

        public Category AddCategoryToArticle(int id, string name)
        {
            Category category = new Category
            {
                ArticleId = 2,
                CategoryId = 2
            };
            Categories.Add(category);

            return category;
        }

        public Article GetCurrentArticle(int articleId)
        {
            Article newArticle = new Article
            {
                ArticleId = articleId
            };
            return newArticle;
        }

        public Article EditArticle(Article EditedArticle)
        {
            EditedArticle.Content = "Bla Bla Bla";
            return EditedArticle;
        }

        public FileModel DeleteFile(int articleId, string image)
        {
            throw  new  NotImplementedException();
        }

        public Article DeleteArticle(int articleId)
        {
            throw new NotImplementedException();
        }

        public FileModel DeleteFile(int ArticleID, int FileID)
        {
            throw new NotImplementedException();
        }

        public FileModel GetCurrentFile(int ArticleID, string File)
        {
            throw  new NotImplementedException();
        }
    }
}
