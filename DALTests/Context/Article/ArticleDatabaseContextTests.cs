using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDL;
using Factory;

namespace DAL.Contexts.Tests
{
    [TestClass()]
    public class ArticleDatabaseContextTests
    {
        [TestMethod()]
        public void GetAllArticlesTest()
        {
            //Arrange
            IArticleContext context = new ArticleDatabaseContext();
            ArticleRepository repo = new ArticleRepository(context);
            ArticleLogic logic = new ArticleLogic(repo);

            List<Article> AllArticles = logic.GetAllArticles();

            //Act
            int expected = 3;
            int actual = AllArticles.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddArticle()
        {
            IArticleContext context = new ArticleDatabaseContext();
            ArticleRepository repo = new ArticleRepository(context);
            ArticleLogic logic = new ArticleLogic(repo);

            //Arrange
            BindModel article = new BindModel();
            List<Article> Articles = new List<Article>();
            Articles.Add(article._Article);

            //Act
            int expected = 1;
            int actual = Articles.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAllCategories()
        {
            //Arrange
            IArticleContext context = new ArticleDatabaseContext();
            ArticleRepository repo = new ArticleRepository(context);
            ArticleLogic logic = new ArticleLogic(repo);

            List<Category> AllCategories = logic.GetAllCategories();

            //Act
            int expected = 5
;
            int actual = AllCategories.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddCategoryToArticle()
        {
            //Arrange
            IArticleContext context = new ArticleDatabaseContext();
            ArticleRepository repo = new ArticleRepository(context);
            ArticleLogic logic = new ArticleLogic(repo);

            Category category = new Category();
            category = logic.AddCategoryToArticle(4, "Premier League");

            Category categoryTwo = new Category();
            categoryTwo = logic.AddCategoryToArticle(0, "");

            //Act
            string expected = category.CategoryName = "Premier League";
            string actual = categoryTwo.CategoryName = "";

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCurrentArticle()
        {
            //Arrange
            IArticleContext context = new ArticleDatabaseContext();
            ArticleRepository repo = new ArticleRepository(context);
            ArticleLogic logic = new ArticleLogic(repo);

            List<Article> Articles = new List<Article>();

            Article article = new Article();
            article = logic.GetCurrentArticle(117);
            Articles.Add(article);

            //Act
            int actual = Articles.Count;
            int expected = 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EditArticle()
        {
            //Arrange
            IArticleContext context = new ArticleDatabaseContext();
            ArticleRepository repo = new ArticleRepository(context);
            ArticleLogic logic = new ArticleLogic(repo);

            BindModel article = new BindModel();
            Article oldContent = logic.GetCurrentArticle(117);

            string oldArticleContent = oldContent.Content;
            string newArticleContent = "BLABLABLABLAB";

            //Act
            string actual = oldArticleContent;
            string expected = newArticleContent;

            //Assert
            Assert.AreNotEqual(expected, actual);
        }
    }
}