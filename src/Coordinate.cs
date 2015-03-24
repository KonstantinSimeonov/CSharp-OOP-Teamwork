using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame
{
    public struct Coordinates : IEquatable<Coordinates>
    {
        private int x;
        private int y;

        public Coordinates(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.y = value;
            }
        }

        public bool Equals(Coordinates other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
