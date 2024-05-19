using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces.Layout;
using ChessGameLogic.Pieces;
using System.Drawing;

namespace ChessGameLogic.Layout
{
    internal class BlackLayout : BaseLayout, ILayout
    {
        private GameColor PieceColor => GameColor.Black;

        public BlackLayout(BlackLayout blackLayout)
        {
            this.Arrangement = new Dictionary<Position, Interfaces.IPiece>(blackLayout.Arrangement);
            this.CurrentGameState = blackLayout.CurrentGameState;
        }

        public BlackLayout()
        {
        }

        public void Initialize()
        {
            this.CurrentGameState = Status.OnGoing;

            Arrangement.Add(new Position(0, 0), new Rook(PieceColor));
            Arrangement.Add(new Position(7, 0), new Rook(PieceColor));
            Arrangement.Add(new Position(1, 0), new Knight(PieceColor));
            Arrangement.Add(new Position(6, 0), new Knight(PieceColor));
            Arrangement.Add(new Position(2, 0), new Bishop(PieceColor));
            Arrangement.Add(new Position(5, 0), new Bishop(PieceColor));
            Arrangement.Add(new Position(3, 0), new Queen(PieceColor));
            Arrangement.Add(new Position(4, 0), new King(PieceColor));

            for (int i = 0; i < 8; i++)
            {
                Arrangement.Add(new Position(i, 1), new Pawn(PieceColor));
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
            return new BlackLayout(this);
        }
    }
}