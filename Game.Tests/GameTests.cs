using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
    [TestClass]
    public class GameTests
    {
        protected virtual Game CreateGame(params int[] p)
        {
            return new Game(p);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_NotSquareField_ThrowArgumentException()
        {
            CreateGame(0, 1, 2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_NotConsecutiveNumbers_ThrowArgumentException()
        {
            CreateGame(0, 1, 25, 3);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetLocation_BadValue_ThrowIndexOutOfRangeException()
        {
            Game game = CreateGame(0, 1, 2, 3);
            int badValue = 4;
            game.GetLocation(badValue);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Shift_NotNeighborValue_ArgumentException()
        {
            Game game = CreateGame(0, 1, 2, 3);
            int notNeighborValue = 3;
            game.Shift(notNeighborValue);
        }
        [TestMethod]
        public void Indexer_GoodIndexes_ValueIsObtained()
        {
            Game game = CreateGame(0, 1, 2, 3);
            int value = 3;
            int x = 1;
            int y = 1;
            Assert.AreEqual(game[x,y],value);
        }
        [TestMethod]
        public void Game_GoodNumbers_ObjectCreates()
        {
            Game game = CreateGame(0, 1, 2, 3);
            Assert.IsNotNull(game);
        }
        [TestMethod]
        public void GetLocation_GoodValue_ReturnRightLocation()
        {
            Game game = CreateGame(0, 1, 2, 3);
            int goodValue = 2;
            Point a = game.GetLocation(goodValue);
            Point b = new Point { X = 1, Y = 0 };
            Assert.AreEqual(a, b);
        }
        [TestMethod]
        public virtual void Shift_NeighborValue_NumberShifts()
        {
            Game game = CreateGame(0, 1, 2, 3);
            int neighborValue = 1;
            game.Shift(neighborValue);
            Point a0 = game.GetLocation(0);
            Point b0 = new Point { X = 0, Y = 1 };
            Point a1 = game.GetLocation(1);
            Point b1 = new Point { X = 0, Y = 0 };
            Assert.AreEqual(a0, b0);
            Assert.AreEqual(a1, b1);
        }
    }
}
