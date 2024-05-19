using ChessGameLogic.Interfaces;

namespace ChessGameLogic
{
    internal class Move : IMove
    {
        public Position Start { get; set; }
        public Position Destination { get; set; }

        public IPiece Piece { get; set; }

        public void SetStart(Position start, IPiece piece)
        {
            Start = start;
            Piece = piece;
        }

        public void SetDestination(Position destination)
        {
            Destination = destination;
        }

        public bool IsInitialized()
        {
            return Start != null && Piece != null;
        }

        public void Clear()
        {
            Start = null;
            Destination = null;
            Piece = null;
        }
    }
}