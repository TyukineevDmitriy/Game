using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class Game
    {
        protected int[,] Field;
        protected Point[] FieldIndexes;
        public Game(params int[] p)
        {
            if (Math.Sqrt(p.Length) % 1 != 0)
                throw new ArgumentException("Field must be square");
            int fieldSize = (int)Math.Sqrt(p.Length);
            Field = new int[fieldSize, fieldSize];
            FieldIndexes = new Point[p.Length];
            int currentP = 0;
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    Field[i, j] = p[currentP];
                    try
                    {
                        FieldIndexes[p[currentP]].X = i;
                        FieldIndexes[p[currentP]].Y = j;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        throw new ArgumentException("Numbers must be consecutive");
                    }
                    currentP++;
                }
            }
        }
        public int this[int x, int y]
        {
            get { return Field[x, y]; }
        }
        public int[] GetLocation(int value)
        {
            return new int[] { FieldIndexes[value].X, FieldIndexes[value].Y };
        }
        public virtual Game Shift(int value)
        {
            int[] coordinatesOfZero = GetLocation(0);
            int[] coordinatesOfValue = GetLocation(value);
            if (Math.Abs(coordinatesOfValue[0] - coordinatesOfZero[0]) +
                Math.Abs(coordinatesOfValue[1] - coordinatesOfZero[1]) != 1)
                throw new ArgumentException("Value must be a zero's neighbor");
            Field[coordinatesOfZero[0], coordinatesOfZero[1]] = value;
            FieldIndexes[value].X = coordinatesOfZero[0];
            FieldIndexes[value].Y = coordinatesOfZero[1];
            Field[coordinatesOfValue[0], coordinatesOfValue[1]] = 0;
            FieldIndexes[0].X = coordinatesOfValue[0];
            FieldIndexes[0].Y = coordinatesOfValue[1];
            return this;
        }
    }
}
