using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;
using ChessGameLogic.Interfaces.Layout;
using System.Drawing;

namespace ChessGameLogic.Pieces
{
    internal class Queen : IPiece
    {
        private GameColor color;

        public Queen(GameColor color)
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

            dx = [1, 1, -1, -1];
            dy = [1, -1, -1, 1];

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

            availableMoves.Remove(currentPosition);
            return availableMoves;
        }

        public Bitmap GetImage()
        {
            Bitmap bitmap;
            if (color.Equals(GameColor.White))
            {
                bitmap = new Bitmap(Resources.queen_w);
            }
            else
            {
                bitmap = new Bitmap(Resources.queen_b);
            }

            return bitmap;
        }
    }
}