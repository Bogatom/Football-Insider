using MDL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Interfaces_BLL_DAL
{
    public interface IArticleContext
    {
        List<Article> GetAllArticles();
        Article AddArticle(Article article);
        FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path);
        Category AddCategoryToArticle(int id, string CategoryName);
        Article GetCurrentArticle(int articleId);
        Article EditArticle(Article articleEditedArticle);
        Article DeleteArticle(int articleId);
        FileModel DeleteFile(int ArticleID, int FileID);
        FileModel GetCurrentFile(int ArticleID, string File);
    }
}
