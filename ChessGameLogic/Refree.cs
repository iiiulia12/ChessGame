using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;
using ChessGameLogic.Interfaces.Layout;
using ChessGameLogic.Notifier;
using ChessGameLogic.Pieces;

namespace ChessGameLogic
{
    internal class Refree
    {
        private readonly IBoard board;
        private readonly INotifier notifier;
        private GameColor currentMovingPlayer;
        private ILayout currentLayout;
        private ILayout opponentLayout;

        public Refree(IBoard board, INotifier notifier)
        {
            this.board = board ?? throw new ArgumentNullException(nameof(board));
            this.notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));

            this.currentLayout = board.CurrentLayout;
            this.opponentLayout = board.OpponentLayout;
            this.currentMovingPlayer = GameColor.White;

            notifier.Subscribe(EventType.MoveProposed, OnMoveProposed);
            notifier.Subscribe(EventType.MakeMove, checkEndGame);
            notifier.Subscribe(EventType.MakeMove, removePiece);
            notifier.Subscribe(EventType.MakeMove, makeMove);
            notifier.Subscribe(EventType.MoveMade, onTurnChanged);
        }

        public void StartGame()
        {
            board.Initialize();
        }

        private void OnMoveProposed(IMove move)
        {
            if (isCorrectMove(move))
            {
                notifier.Notify(EventType.MakeMove, move);
                notifier.Notify(EventType.MoveMade);
                changeTurn();
            }
        }

        private bool isCorrectMove(IMove move)
        {
            IPiece piece = move.Piece;

            if (piece.GetAvailableMoves(move.Start, currentLayout, opponentLayout).Contains(move.Destination))
            {
                var currentLayoutClone = currentLayout.Clone();
                var opponentLayoutClone = opponentLayout.Clone();
                simulateMove(currentLayoutClone, opponentLayoutClone, move);
                if (isKingThreatened(currentLayoutClone.GetKingsPosition(), currentLayoutClone, opponentLayoutClone))
                {
                    return false;
                }

                return true;
            }
            return false;
        }

        private void checkEndGame(IMove move)
        {
            if (currentLayout.CurrentGameState is Status.OnGoing)
            {
                List<Position> currentPieceAvailableMoves = move.Piece.GetAvailableMoves(move.Destination, currentLayout, opponentLayout);
                if (currentPieceAvailableMoves.Contains(opponentLayout.GetKingsPosition()))
                {
                    opponentLayout.UpdateStatus(Status.Check);

                    var currentLayoutClone = currentLayout.Clone();
                    var opponentLayoutClone = opponentLayout.Clone();
                    simulateMove(currentLayoutClone, opponentLayoutClone, move);
                    if (isCheckmateOnSimulatedMove(currentLayoutClone, opponentLayoutClone))
                    {
                        opponentLayout.UpdateStatus(Status.Checkmate);
                        notifier.Notify(EventType.EndGame, currentMovingPlayer);
                    }
                }
            }
            else
            {
                if (currentLayout.CurrentGameState is Status.Check)
                {
                    if (move.Piece is King)
                    {
                        if (isKingThreatened(move.Destination, currentLayout, opponentLayout))
                        {
                            currentLayout.UpdateStatus(Status.Checkmate);
                        }
                        else
                        {
                            currentLayout.UpdateStatus(Status.OnGoing);
                        }
                    }
                    else
                    {
                        var currentLayoutClone = currentLayout.Clone();
                        var opponentLayoutClone = opponentLayout.Clone();
                        simulateMove(currentLayoutClone, opponentLayoutClone, move);
                        if (!isCheckmateOnSimulatedMove(currentLayoutClone, opponentLayoutClone))
                        {
                            currentLayout.UpdateStatus(Status.OnGoing);
                        }
                        else
                        {
                            currentLayout.UpdateStatus(Status.Checkmate);
                            GameColor winner = currentMovingPlayer.Equals(GameColor.White) ? GameColor.Black : GameColor.White;
                            notifier.Notify(EventType.EndGame, winner);
                        }
                    }
                }
            }
        }

        private void makeMove(IMove move)
        {
            currentLayout.MovePiece(move);
        }

        private void removePiece(IMove move)
        {
            if (opponentLayout.ContainsPieceAt(move.Destination))
            {
                opponentLayout.RemovePiece(move.Destination);
            }
        }

        private void onTurnChanged()
        {
            ILayout temp = board.CurrentLayout;
            board.CurrentLayout = board.OpponentLayout;
            board.OpponentLayout = temp;

            this.currentLayout = board.CurrentLayout;
            this.opponentLayout = board.OpponentLayout;
        }

        private void changeTurn()
        {
            this.currentMovingPlayer = currentMovingPlayer.Equals(GameColor.White) ? GameColor.Black : GameColor.White;
            notifier.Notify(EventType.ChangeTurn, currentMovingPlayer);
        }

        private bool isKingThreatened(Position kingsPosition, ILayout kingsLayout, ILayout opponentLayout)
        {
            HashSet<Position> allOpponentAvailableMoves = opponentLayout.GetAllAvailablePositions(kingsLayout);

            return allOpponentAvailableMoves.Contains(kingsPosition);
        }

        private void simulateMove(ILayout currentClone, ILayout opponentClone, IMove move)
        {
            if (opponentClone.ContainsPieceAt(move.Destination))
            {
                opponentClone.RemovePiece(move.Destination);
            }

            currentClone.MovePiece(move);
        }

        private bool isCheckmateOnSimulatedMove(ILayout currentClone, ILayout opponentClone)
        {
            var opponentKingPiece = currentClone.GetKing();
            var opponentKingPosition = opponentClone.GetKingsPosition();

            List<Position> opponentKingAvailableMoves = opponentKingPiece.GetAvailableMoves(opponentKingPosition, opponentClone, currentClone);

            if (opponentKingAvailableMoves.All(p => isKingThreatened(p, opponentClone, currentClone)))
            {
                return true;
            }

            return false;
        }
    }
}