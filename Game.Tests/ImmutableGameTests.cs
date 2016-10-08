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
        public override void Shift_NeighborValue_NumberShifts()
        {
            Game immutableGame = CreateGame(0, 1, 2, 3);
            int neighborValue = 1;
            Game newImmutableGame = immutableGame.Shift(neighborValue);
            Point a0 = immutableGame.GetLocation(0);
            Point b0 = new Point { X = 0, Y = 0 };
            Point a1 = immutableGame.GetLocation(1);
            Point b1 = new Point { X = 0, Y = 1 };
            Point newa0 = newImmutableGame.GetLocation(0);
            Point newb0 = new Point { X = 0, Y = 1 };
            Point newa1 = newImmutableGame.GetLocation(1);
            Point newb1 = new Point { X = 0, Y = 0 };
            Assert.AreEqual(a0, b0);
            Assert.AreEqual(a1, b1);
            Assert.AreEqual(newa0, newb0);
            Assert.AreEqual(newa1, newb1);
        }
    }
}
