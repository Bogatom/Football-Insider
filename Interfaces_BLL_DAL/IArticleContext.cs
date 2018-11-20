using MDL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DAL.Contexts
{
    public interface IArticleContext
    {
        List<Article> GetAllArticles();
        List<Category> GetAllCategories();
        Article AddArticle(BindModel article);
        FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path);
        Category AddCategoryToArticle(int id, string CategoryName);
        Article GetCurrentArticle(int articleId);
        Article EditArticle(BindModel articleEditedArticle);
        Article DeleteArticle(int articleId);
    }
}
