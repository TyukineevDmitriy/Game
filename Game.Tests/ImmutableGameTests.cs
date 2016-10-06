using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
    [TestClass]
    public class ImmutableGameTests : GameTests
    {
        protected override Game CreateGame(params int[] p)
        {
            return new ImmutableGame(p);
        }
        [TestMethod]
        public void Game_GoodNumbers_NewObjectCreates()
        {
            Game immutableGame = CreateGame(0, 1, 2, 3);
            int neighborValue = 1;
            Game newImmutableGame = immutableGame.Shift(neighborValue);
            int[] a0 = immutableGame.GetLocation(0);
            int[] b0 = new int[] { 0, 0 };
            int[] a1 = immutableGame.GetLocation(1);
            int[] b1 = new int[] { 0, 1 };
            int[] newa0 = newImmutableGame.GetLocation(0);
            int[] newb0 = new int[] { 0, 1 };
            int[] newa1 = newImmutableGame.GetLocation(1);
            int[] newb1 = new int[] { 0, 0 };
            Assert.IsTrue(a0[0] == b0[0] && a0[1] == b0[1]
                && a1[0] == b1[0] && a1[1] == b1[1]
                && newa0[0] == newb0[0] && newa0[1] == newb0[1]
                && newa1[0] == newb1[0] && newa1[1] == newb1[1]);
        }
    }
}
