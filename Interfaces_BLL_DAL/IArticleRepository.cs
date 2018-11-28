using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MDL;

namespace Interfaces_UI_BLL
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticles();
        List<Category> GetAllCategories();
        Article AddArticle(Article article);
        FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path);
        Category AddCategoryToArticle(int id, string CategoryName);
        Article GetCurrentArticle(int articleId);
        Article EditArticle(Article EditedArticle);
        Article DeleteArticle(int articleId);
        FileModel DeleteFile(int ArticleID, int FileID);
        FileModel GetCurrentFile(int ArticleID, string File);
    }
}
