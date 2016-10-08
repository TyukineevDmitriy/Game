using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ImmutableGameDecorator
    {
        private ImmutableGame ImmutableGame;
        private List<int> ShiftedNumbers;
        public ImmutableGameDecorator(ImmutableGame immutableGame)
        {
            ImmutableGame = immutableGame;
            ShiftedNumbers = new List<int>();
        }
        public int this[int x, int y]
        {
            get
            {
                return GetActualGame()[x, y];
            }
        }
        public Point GetLocation(int value)
        {
            return GetActualGame().GetLocation(value);
        }
        public ImmutableGameDecorator Shift(int value)
        {
            ShiftedNumbers.Add(value);
            return this;
        }
        private Game GetActualGame()
        {
            Game temp = new Game(ImmutableGame);
            foreach (int item in ShiftedNumbers)
            {
                temp.Shift(item);
            }
            return temp;
        }
    }
}
