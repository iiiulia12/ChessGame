using ChessGameLogic.Interfaces.Layout;

namespace ChessGameLogic
{
    internal class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y;
        }

        public bool IsInsideBoard()
        {
            if (X >= 0 && Y >= 0 && X <= 7 && Y <= 7)
                return true;
            return false;
        }

        public bool IsValidPosition(ILayout actualLayout)
        {
            if (!IsInsideBoard())
            {
                return false;
            }

            if (actualLayout.ContainsPieceAt(this))
            {
                return false;
            }
            return true;
        }
    }
}