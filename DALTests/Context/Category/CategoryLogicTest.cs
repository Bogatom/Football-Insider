using System;
using System.Collections.Generic;
using Factory;
using Interfaces_UI_BLL;
using MDL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DAL.Contexts.Tests
{
    [TestClass]
    public class CategoryLogicTest
    {
        [TestMethod]
        public void GetAllCategories()
        {
            //Arrange
            ICategoryLogic logic = LogicFactory.CreateCategoryMemoryLogic();
            List<Category> AllCategories = logic.GetAllCategories();

            //Act
            int expected = 5;
            int actual = AllCategories.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
