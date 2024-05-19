namespace ChessGameLogic.Interfaces
{
    internal interface IMove
    {
        Position Destination { get; set; }
        IPiece Piece { get; set; }
        Position Start { get; set; }

        void Clear();
        bool IsInitialized();
        void SetDestination(Position destination);
        void SetStart(Position start, IPiece piece);
    }
}