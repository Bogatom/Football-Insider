using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDL;
using Factory;
using Interfaces_UI_BLL;

namespace DAL.Contexts.Tests
{
    [TestClass()]
    public class ArticleMemoryContextTests
    {
        [TestMethod()]
        public void GetAllArticlesTest()
        {
            //Arrange
            IArticleLogic logic = LogicFactory.CreateArticleMemoryLogic();
            List<Article> AllArticles = logic.GetAllArticles();

            //Act
            int expected = 1;
            int actual = AllArticles.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddArticle()
        {
            //Arrange
            IArticleLogic logic = LogicFactory.CreateArticleMemoryLogic();
            Article article = new Article();
            article = new Article
            {
                ArticleId = 2,
                Title = "Artikel 2",
                Category = "Populair",
                Content = "Ipsum Lorem",
                CreationDate = DateTime.Now.ToShortDateString()
            };
            logic.AddArticle(article);

            //Act
            int expected = 2;
            int actual = logic.GetAllArticles().Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAllCategories()
        {
            //Arrange
            ICategoryLogic logic = LogicFactory.CreateCategoryLogic();
            List<Category> AllCategories = logic.GetAllCategories();

            //Act
            int expected = 1
;
            int actual = AllCategories.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddCategoryToArticle()
        {
            //Arrang
            IArticleLogic logic = LogicFactory.CreateArticleMemoryLogic();


            Article article = new Article();
            article = logic.GetCurrentArticle(1);

            //Act
            string expected = article.Category = "Trending";
            string actual = article.Category = "Opmerkelijk";

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCurrentArticle()
        {
            //Arrange
            IArticleLogic logic = LogicFactory.CreateArticleMemoryLogic();
            
            Article article = new Article();
            article = logic.GetCurrentArticle(1);           

            //Act
            int expected = 1;
            int actual = article.ArticleId;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EditArticle()
        {
            //Arrange
            IArticleLogic logic = LogicFactory.CreateArticleMemoryLogic();

            Article article = new Article
            {
                ArticleId = 1,
                Content = "TESTEN"
            };

            logic.EditArticle(article);

            //Act
            string actual = article.Content;
            string expected = "Bla Bla Bla";

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}