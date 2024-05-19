using ChessGameLogic.Interfaces;
using ChessGameLogic.Interfaces.Layout;
using System.Drawing;

namespace ChessGameLogic
{
    internal class DrawManager : IDrawManager
    {
        private readonly int squareSize;

        public DrawManager(int squareSize)
        {
            this.squareSize = squareSize;
        }

        public void DrawPieces(Graphics graphics, ILayout layout)
        {
            foreach (var piece in layout.GetImages())
            {
                graphics.DrawImage(piece.Value, piece.Key.X * squareSize, piece.Key.Y * squareSize, squareSize, squareSize);
            }
        }

        public void DrawAvailableMoves(Graphics graphics, List<Position> availablePositions)
        {
            foreach (var position in availablePositions)
            {
                graphics.DrawRectangle(new Pen(Color.Red, 3), position.X * squareSize, position.Y * squareSize, squareSize, squareSize);
            }
        }

        public void DrawSquares(Graphics graphics)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var brush = (i + j) % 2 == 0 ? Brushes.WhiteSmoke : Brushes.DarkGray;

                    graphics.FillRectangle(brush, i * squareSize, j * squareSize, squareSize, squareSize);
                }
            }
        }
    }
}