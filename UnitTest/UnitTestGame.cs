using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Com.Factset;
using System.IO;
namespace UnitTest
{
    [TestClass]
    public class UnitTestGame
    {
        Game g = new Game();
        //[TestMethod]
        public void GetRandomNumber()
        {
            // Write(g.GetRandomNumber(7).ToString());
        }
        [TestMethod]
        public void TestInitialEmptyCells()
        {
            //Assert.AreEqual(9, g.EmptyCellsCount);
        }
        [TestMethod]
        public void PrintGridState()
        {
            Write(g.PrintGridState());
        }
        [TestMethod]
        public void MoveCellsDown()
        {
            PrintGridState();
            for (int i = 0; i < 10; i++)
            {
                g.MoveCellsDown();
                PrintGridState();
            }
        }
        [TestMethod]
        public void MoveCellsUp()
        {
            PrintGridState();
            for (int i = 0; i < 10; i++)
            {
                g.MoveCellsUp();
                PrintGridState();
            }
        }
        [TestMethod]
        public void MoveCellsLeft()
        {
            PrintGridState();
            for (int i = 0; i < 10; i++)
            {
                g.MoveCellsLeft();
                PrintGridState();
            }
        }
        [TestMethod]
        public void MoveCellsRight()
        {
            PrintGridState();
            for (int i = 0; i < 10; i++)
            {
                g.MoveCellsRight();
                PrintGridState();
            }
        }
        private void Write(string message)
        {
            string path = "C:\\Debug\\Output.txt";
            File.WriteAllText(path, message);
        }
        private void Append(string message)
        {
            string path = "C:\\Debug\\Output.txt";
            File.AppendAllText(path, message);
        }
    }
}
