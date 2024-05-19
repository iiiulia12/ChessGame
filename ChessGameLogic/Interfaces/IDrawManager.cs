using ChessGameLogic.Interfaces.Layout;
using System.Drawing;

namespace ChessGameLogic.Interfaces
{
    internal interface IDrawManager
    {
        void DrawAvailableMoves(Graphics graphics, List<Position> availablePositions);
        void DrawPieces(Graphics graphics, ILayout layout);
        void DrawSquares(Graphics graphics);
    }
}