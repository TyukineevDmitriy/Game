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
            int[] a = game.GetLocation(goodValue);
            int[] b = new int[] { 1, 0 };
            Assert.IsTrue(a[0] == b[0] && a[1] == b[1]);
        }
        [TestMethod]
        public void Shift_NeighborValue_NumberShifts()
        {
            Game game = CreateGame(0, 1, 2, 3);
            int neighborValue = 1;
            game.Shift(neighborValue);
            int[] a0 = game.GetLocation(0);
            int[] b0 = new int[] { 0, 1 };
            int[] a1 = game.GetLocation(1);
            int[] b1 = new int[] { 0, 0 };
            Assert.IsTrue(a0[0] == b0[0] && a0[1] == b0[1]
                && a1[0] == b1[0] && a1[1] == b1[1]);
        }
    }
}
