using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interfaces_UI_BLL
{
    public interface IArticleLogic
    {
        List<Article> GetAllArticles();
        Article AddArticle(Article article);
        Category AddCategoryToArticle(int id, string CategoryName);
        FileModel AddFile(HttpPostedFileBase fileModel, int ArticleId, string Path);
        Article GetCurrentArticle(int articleId);
        Article EditArticle(Article EditedArticle);
        Article DeleteArticle(int articleId);
        FileModel DeleteFile(int ArticleID, int FileID);
        FileModel GetCurrentFile(int ArticleID, string File);
    }
}
