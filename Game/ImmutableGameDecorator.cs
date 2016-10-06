using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ImmutableGameDecorator
    {
        private ImmutableGame FirstImmutableGame;
        private ImmutableGame ImmutableGame;
        private Stack<int> ShiftedNumbers;
        public ImmutableGameDecorator(ImmutableGame immutableGame)
        {
            FirstImmutableGame = immutableGame;
            ImmutableGame = immutableGame;
            ShiftedNumbers = new Stack<int>();
        }
        public int this[int x, int y]
        {
            get { return ImmutableGame[x, y]; }
        }
        public int[] GetLocation(int value)
        {
            return ImmutableGame.GetLocation(value);
        }
        public ImmutableGameDecorator Shift(int value)
        {
            ImmutableGame newImmutableGame = (ImmutableGame)ImmutableGame.Shift(value);
            ShiftedNumbers.Push(value);
            return this;
        }
    }
}
