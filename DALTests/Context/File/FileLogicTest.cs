using System;
using System.Collections.Generic;
using Factory;
using Interfaces_UI_BLL;
using MDL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DAL.Contexts.Tests
{
    [TestClass]
    public class FileLogicTest
    {
        [TestMethod]
        public void GetAllFiles()
        {
            //Arrange
            IFileLogic logic = LogicFactory.CreateFileMemoryLogic();
            List<FileModel> AllFiles = logic.GetAllFiles();

            //Act
            int expected = 3;
            int actual = AllFiles.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
