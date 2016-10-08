using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
    [TestClass] 
    class ImmutableGameDecoratorTests : GameTests
    {
        protected new ImmutableGameDecorator CreateGame(params int[] p)
        {
            ImmutableGame game = new ImmutableGame(p);
            return new ImmutableGameDecorator(game);
        }
        [TestMethod]
        public override void Shift_NeighborValue_NumberShifts()
        {
            Game immutableGame = new ImmutableGame(0, 1, 2, 3);
            ImmutableGameDecorator dec = CreateGame(0, 1, 2, 3);
            dec.Shift(1);
            dec.Shift(3);
            Point a1 = dec.GetLocation(0);
            Point b1 = new Point { X = 1, Y = 1 };
            Assert.AreEqual(a1, b1);
        }
    }
}
