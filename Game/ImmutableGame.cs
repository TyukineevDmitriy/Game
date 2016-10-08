using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ImmutableGame : Game
    {
        public ImmutableGame(params int[] p) : base(p)
        {
        }
        private ImmutableGame(ImmutableGame immutableGame) : base(immutableGame)
        {
        }
        public override Game Shift(int value)
        {
            base.Shift(value);
            Game newImmutableGame = new ImmutableGame(this);
            base.Shift(value);
            return newImmutableGame;
        }
    }
}
