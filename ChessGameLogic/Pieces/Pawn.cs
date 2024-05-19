using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;
using ChessGameLogic.Interfaces.Layout;
using System.ComponentModel;
using System.Drawing;

namespace ChessGameLogic.Pieces
{
    internal class Pawn : IPiece
    {
        private GameColor color;

        public Pawn(GameColor color)
        {
            this.color = color;
        }

        public List<Position> GetAvailableMoves(Position currentPosition, ILayout actualLayout, ILayout opponentLayout)
        {
            List<Position> availableMoves = new List<Position>();
            int direction = color.Equals(GameColor.White) ? -1 : 1;

            int forwardX = currentPosition.X;
            int forwardY = currentPosition.Y + direction;
            Position position = new Position(forwardX, forwardY);

            if (!isBlocked(position, actualLayout, opponentLayout))
            {
                availableMoves.Add(position);

                if (isAtStartingPosition(currentPosition))
                {
                    int doubleMoveY = currentPosition.Y + 2 * direction;
                    position = new Position(forwardX, doubleMoveY);

                    if (!isBlocked(position, actualLayout, opponentLayout))
                    {
                        availableMoves.Add(position);
                    }
                }
            }

            addDiagonalPositionAvailable(currentPosition, actualLayout, opponentLayout, availableMoves);

            return availableMoves;
        }

        public Bitmap GetImage()
        {
            Bitmap bitmap;
            if (color.Equals(GameColor.White))
            {
                bitmap = new Bitmap(Resources.pawn_w);
            }
            else
            {
                bitmap = new Bitmap(Resources.pawn_b);
            }

            return bitmap;
        }

        private bool isAtStartingPosition(Position position)
        {
            int startingY = color.Equals(GameColor.White) ? 6 : 1;

            if (position.Y != startingY)
            {
                return false;
            }

            return true;
        }

        private void addDiagonalPositionAvailable(Position position, ILayout actualLayout, ILayout opponentLayout, List<Position> availableMoves)
        {
            int[] dx;
            int[] dy;
            if (color.Equals(GameColor.White))
            {
                dx = [-1, 1];
                dy = [-1, -1];
            }
            else
            {
                dx = [-1, 1];
                dy = [1, 1];
            }

            Position posibilePosition;

            for (int i = 0; i < 2; i++)
            {
                posibilePosition = new Position(position.X + dx[i], position.Y + dy[i]);

                if (posibilePosition.IsValidPosition(actualLayout) && opponentLayout.ContainsPieceAt(posibilePosition))
                {
                    availableMoves.Add(posibilePosition);
                }
            }
        }

        private bool isBlocked(Position position, ILayout actualLayout, ILayout opponentLayout)
        {
            if (!position.IsValidPosition(actualLayout))
            {
                return true;
            }

            if (opponentLayout.ContainsPieceAt(position))
            {
                return true;
            }
            return false;
        }
    }
}