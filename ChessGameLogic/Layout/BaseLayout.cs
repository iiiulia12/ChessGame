using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;
using ChessGameLogic.Interfaces.Layout;
using ChessGameLogic.Pieces;
using System.Drawing;

namespace ChessGameLogic.Layout
{
    internal class BaseLayout : IBaseLayout
    {
        protected Dictionary<Position, IPiece> Arrangement;
        public Status CurrentGameState { get; protected set; }
        public BaseLayout()
        {
            Arrangement = new Dictionary<Position, IPiece>();
        }

        public void MovePiece(IMove move)
        {
            Arrangement.Remove(move.Start);
            Arrangement.Add(move.Destination, move.Piece);
        }
        public void RemovePiece(Position position)
        {
            Arrangement.Remove(position);

        }

        public bool ContainsPieceAt(Position position)
        {
            return Arrangement.ContainsKey(position);
        }

        public Position GetKingsPosition()
        {
            foreach (Position position in Arrangement.Keys)
            {
                if (Arrangement[position] is King)
                {
                    return position;
                }
            }
            return null;
        }

        public IPiece GetPieceAt(Position position)
        {
            return Arrangement[position];
        }


        Dictionary<Position, Bitmap> IBaseLayout.GetImages()
        {
            Dictionary<Position, Bitmap> images = new Dictionary<Position, Bitmap>();
            foreach (var piece in Arrangement)
            {
                images.Add(piece.Key, piece.Value.GetImage());
            }
            return images;
        }

        public IPiece  GetKing()
        {
            return Arrangement.Values.FirstOrDefault(piece => piece is King);
        }
        public void UpdateStatus(Status newStatus)
        {
            CurrentGameState = newStatus;
        }

    }
}
