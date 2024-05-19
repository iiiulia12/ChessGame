using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;
using ChessGameLogic.Interfaces.Layout;
using System.Drawing;

namespace ChessGameLogic.Pieces
{
    internal class King : IPiece
    {
        private GameColor color;

        public King(GameColor color)
        {
            this.color = color;
        }

        public List<Position> GetAvailableMoves(Position currentPosition, ILayout actualLayout, ILayout opponentLayout)
        {
            List<Position> availableMoves = new List<Position>();
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                int x = currentPosition.X + dx[i];
                int y = currentPosition.Y + dy[i];
                Position position = new Position(x, y);

                if (position.IsValidPosition(actualLayout))
                {
                    availableMoves.Add(new Position(x, y));
                }
            }

            return availableMoves;
        }

        public Bitmap GetImage()
        {
            Bitmap bitmap;
            if (color.Equals(GameColor.White))
            {
                bitmap = new Bitmap(Resources.king_w);
            }
            else
            {
                bitmap = new Bitmap(Resources.king_b);
            }

            return bitmap;
        }
    }
}