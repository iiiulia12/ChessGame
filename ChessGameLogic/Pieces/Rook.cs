using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;
using ChessGameLogic.Interfaces.Layout;
using System.Drawing;

namespace ChessGameLogic.Pieces
{
    internal class Rook : IPiece
    {
        private GameColor color;

        public Rook(GameColor color)
        {
            this.color = color;
        }

        public List<Position> GetAvailableMoves(Position currentPosition, ILayout actualLayout, ILayout opponentLayout)
        {
            List<Position> availableMoves = new List<Position>();
            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            for (int d = 0; d < 4; d++)
            {
                int x = currentPosition.X;
                int y = currentPosition.Y;

                while (true)
                {
                    x += dx[d];
                    y += dy[d];

                    Position position = new Position(x, y);

                    if (!position.IsValidPosition(actualLayout))
                    {
                        break;
                    }

                    availableMoves.Add(new Position(x, y));

                    if (opponentLayout.ContainsPieceAt(position))
                    {
                        break;
                    }
                }
            }

            return availableMoves;
        }

        public Bitmap GetImage()
        {
            Bitmap bitmap;
            if (color.Equals(GameColor.White))
            {
                bitmap = new Bitmap(Resources.rook_w);
            }
            else
            {
                bitmap = new Bitmap(Resources.rook_b);
            }

            return bitmap;
        }
    }
}