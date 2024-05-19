using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;
using System.Drawing;

namespace ChessGameLogic.Interfaces.Layout
{
    internal interface IBaseLayout
    {
        Status CurrentGameState { get; }
        bool ContainsPieceAt(Position position);

        Dictionary<Position, Bitmap> GetImages();

        Position GetKingsPosition();

        IPiece GetPieceAt(Position position);

        void MovePiece(IMove move);

        void RemovePiece(Position position);

        IPiece GetKing();
        void UpdateStatus(Status newStatus);
    }
}