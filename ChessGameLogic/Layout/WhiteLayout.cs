using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces.Layout;
using ChessGameLogic.Pieces;

namespace ChessGameLogic.Layout
{
    internal class WhiteLayout : BaseLayout, ILayout
    {
        private GameColor PieceColor => GameColor.White;

        public WhiteLayout(WhiteLayout whiteLayout)
        {
            this.Arrangement = new Dictionary<Position, Interfaces.IPiece>(whiteLayout.Arrangement);
            this.CurrentGameState = whiteLayout.CurrentGameState;
        }

        public WhiteLayout()
        {
        }

        public void Initialize()
        {
            this.CurrentGameState = Status.OnGoing;

            Arrangement.Add(new Position(0, 7), new Rook(PieceColor));
            Arrangement.Add(new Position(7, 7), new Rook(PieceColor));
            Arrangement.Add(new Position(1, 7), new Knight(PieceColor));
            Arrangement.Add(new Position(6, 7), new Knight(PieceColor));
            Arrangement.Add(new Position(2, 7), new Bishop(PieceColor));
            Arrangement.Add(new Position(5, 7), new Bishop(PieceColor));
            Arrangement.Add(new Position(3, 7), new Queen(PieceColor));
            Arrangement.Add(new Position(4, 7), new King(PieceColor));

            for (int i = 0; i < 8; i++)
            {
                Arrangement.Add(new Position(i, 6), new Pawn(PieceColor));
            }
        }

        public HashSet<Position> GetAllAvailablePositions(ILayout opponent)
        {
            List<Position> availablePositions = new List<Position>();
            foreach (var element in Arrangement)
            {
                availablePositions.AddRange(element.Value.GetAvailableMoves(element.Key, this, opponent));
            }
            return new HashSet<Position>(availablePositions);
        }

        public ILayout Clone()
        {
            return new WhiteLayout(this);
        }
    }
}