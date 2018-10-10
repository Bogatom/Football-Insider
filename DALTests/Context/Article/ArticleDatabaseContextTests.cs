using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDL;
using BLL;

namespace DAL.Contexts.Tests
{
    [TestClass()]
    public class ArticleDatabaseContextTests
    {
        [TestMethod()]
        public void GetAllArticlesTest()
        {
            //arrange
            IArticleContext context = new ArticleDatabaseContext();
            ArticleRepository repo = new ArticleRepository(context);
            ArticleLogic logic = new ArticleLogic(repo);

            List<Article> AllArticles = logic.GetAllArticles();

            //act
            int expected = 3;
            int actual = AllArticles.Count();

            //assert
            Assert.AreEqual(expected, actual);


            //todo: meer unit test maken

        }
    }
}