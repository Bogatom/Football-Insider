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
        public void GetAllArticles()
        {
            //Arrange
            IArticleLogic logic = LogicFactory.CreateArticleMemoryLogic();
            List<Article> AllArticles = logic.GetAllArticles();

            //Act
            int expected = 2;
            int actual = AllArticles.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }              

        [TestMethod()]
        public void GetCurrentArticle()
        {
            //Arrange
            IArticleLogic logic = LogicFactory.CreateArticleMemoryLogic();
            Article article = logic.GetCurrentArticle(3);

            //Act
            int expected = 3;
            int actual = article.ArticleId;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EditArticle()
        {
            //Arrange
            IArticleLogic logic = LogicFactory.CreateArticleMemoryLogic();
            Article article = logic.GetCurrentArticle(3);
            Article editedArticle = logic.GetCurrentArticle(2);
            article = logic.EditArticle(editedArticle);

            //Act
            Article expected = editedArticle;
            Article actual = article;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}