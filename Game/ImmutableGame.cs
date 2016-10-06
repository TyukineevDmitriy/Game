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
        private ImmutableGame(ImmutableGame immutableGame) 
        {
            int fieldSize = (int)Math.Sqrt(immutableGame.Field.Length);
            Field = new int[fieldSize, fieldSize];
            FieldIndexes = new Point[immutableGame.Field.Length];
            Field = (int[,])immutableGame.Field.Clone();
            FieldIndexes = (Point[])immutableGame.FieldIndexes.Clone();
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
