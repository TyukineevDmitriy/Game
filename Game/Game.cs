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
        public Game(ImmutableGame immutableGame)
        {
            int fieldSize = (int)Math.Sqrt(immutableGame.Field.Length);
            Field = new int[fieldSize, fieldSize];
            FieldIndexes = new Point[immutableGame.Field.Length];
            Field = (int[,])immutableGame.Field.Clone();
            FieldIndexes = (Point[])immutableGame.FieldIndexes.Clone();
        }
        public int this[int x, int y]
        {
            get { return Field[x, y]; }
        }
        public Point GetLocation(int value)
        {
            Point point = new Point();
            point.X = FieldIndexes[value].X;
            point.Y = FieldIndexes[value].Y;
            return point;
        }
        public virtual Game Shift(int value)
        {
            Point coordinatesOfZero = GetLocation(0);
            Point coordinatesOfValue = GetLocation(value);
            if (Math.Abs(coordinatesOfValue.X - coordinatesOfZero.X) +
                Math.Abs(coordinatesOfValue.Y - coordinatesOfZero.Y) != 1)
                throw new ArgumentException("Value must be a zero's neighbor");
            Field[coordinatesOfZero.X, coordinatesOfZero.Y] = value;
            FieldIndexes[value].X = coordinatesOfZero.X;
            FieldIndexes[value].Y = coordinatesOfZero.Y;
            Field[coordinatesOfValue.X, coordinatesOfValue.Y] = 0;
            FieldIndexes[0].X = coordinatesOfValue.X;
            FieldIndexes[0].Y = coordinatesOfValue.Y;
            return this;
        }
    }
}
