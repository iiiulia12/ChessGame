using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;
using ChessGameLogic.Interfaces.Layout;
using ChessGameLogic.Notifier;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGameLogic
{
    internal class Board : Panel, IBoard
    {
        public ILayout OpponentLayout { get; set; }
        public ILayout CurrentLayout { get; set; }

        private readonly int squareSize;
        private readonly IMove pendingMove;
        private readonly INotifier notifier;
        private readonly IDrawManager drawManager;

        public Board(ILayout currentLayout, ILayout opponentLayout, INotifier moveNotifier, IMove pendingMove, IDrawManager drawManager, int squareSize)
        {
            this.Height = 640;
            this.Width = 640;
            this.squareSize = squareSize;
            this.CurrentLayout = currentLayout;
            this.OpponentLayout = opponentLayout;
            this.notifier = moveNotifier;
            this.pendingMove = pendingMove;
            this.drawManager = drawManager;
            moveNotifier.Subscribe(EventType.MoveMade, this.Refresh);
        }

        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            drawManager.DrawSquares(paintEventArgs.Graphics);
            drawManager.DrawPieces(paintEventArgs.Graphics, CurrentLayout);
            drawManager.DrawPieces(paintEventArgs.Graphics, OpponentLayout);
        }

        protected override void OnClick(EventArgs eventArgs)
        {
            this.Refresh();
            Position position = getMousePosition();

            if (CurrentLayout.ContainsPieceAt(position))
            {
                pendingMove.SetStart(position, CurrentLayout.GetPieceAt(position));
                drawManager.DrawAvailableMoves(this.CreateGraphics(), pendingMove.Piece.GetAvailableMoves(position, CurrentLayout, this.OpponentLayout));
            }
            else
            {
                if (pendingMove.IsInitialized())
                {
                    pendingMove.SetDestination(position);
                    notifier.Notify(EventType.MoveProposed, pendingMove);
                    pendingMove.Clear();
                }
            }
        }

        public void Initialize()
        {
            CurrentLayout.Initialize();
            OpponentLayout.Initialize();
        }

        private Position getMousePosition()
        {
            Point point = PointToClient(MousePosition);
            return new Position(point.X / squareSize, point.Y / squareSize);
        }
    }
}