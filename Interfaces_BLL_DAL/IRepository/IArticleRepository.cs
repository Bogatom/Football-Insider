using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MDL;

namespace Interfaces_BLL_DAL
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticles();
        Article AddArticle(Article article);
        Category AddCategoryToArticle(int id, string CategoryName);
        Article GetCurrentArticle(int articleId);
        Article EditArticle(Article EditedArticle);
        Article DeleteArticle(int articleId);       
    }
}
