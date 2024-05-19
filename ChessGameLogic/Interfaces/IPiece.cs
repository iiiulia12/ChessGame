
using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces.Layout;
using System.Drawing;

namespace ChessGameLogic.Interfaces
{
    internal interface IPiece
    {
       // GameColor PieceColor { get; set; }

        Bitmap GetImage();

        List<Position> GetAvailableMoves(Position currentPosition, ILayout actualLayout, ILayout oponentLayout);


    }
}
