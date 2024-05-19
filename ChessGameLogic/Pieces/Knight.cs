using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;
using ChessGameLogic.Interfaces.Layout;
using System.Drawing;

namespace ChessGameLogic.Pieces
{
    internal class Knight : IPiece
    {
        private GameColor color;

        public Knight(GameColor color)
        {
            this.color = color;
        }

        public List<Position> GetAvailableMoves(Position currentPosition, ILayout actualLayout, ILayout opponentLayout)
        {
            List<Position> availableMoves = new List<Position>();
            int[] dx = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] dy = { -1, -2, -2, -1, 1, 2, 2, 1 };

            for (int i = 0; i < 8; i++)
            {
                Position position = new Position(currentPosition.X + dx[i], currentPosition.Y + dy[i]);

                if (position.IsValidPosition(actualLayout))
                {
                    availableMoves.Add(position);
                }
            }
            return availableMoves;
        }

        public Bitmap GetImage()
        {
            Bitmap bitmap;
            if (color.Equals(GameColor.White))
            {
                bitmap = new Bitmap(Resources.knight_w);
            }
            else
            {
                bitmap = new Bitmap(Resources.knight_b);
            }

            return bitmap;
        }
    }
}