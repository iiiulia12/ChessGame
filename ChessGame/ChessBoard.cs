using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using ChessGameLogic;
using ChessGameLogic.Enums;
using ChessGameLogic.Events;
using ChessGameLogic.Interfaces;
using ChessGameLogic.Interfaces.Layout;
using ChessGameLogic.Layout;
using ChessGameLogic.Notifier;

namespace ChessGame
{
    public partial class ChessBoard : Form
    {
        private readonly Start startForm;
        private  Board board;
        private  Refree refree;
        private  ILayout whiteLayout;
        private  ILayout blackLayout;
        private  IDrawManager drawManager;
        private  INotifier notifier;
        private IMove move;
        private int squareSize = 80;

        public ChessBoard(Start start)
        {
            InitializeComponent();
            this.startForm = start;

            initializeDependencies();

            refree.StartGame();
            this.Controls.Add(board);
            CurrentMovingPlayer.Text = "White's turn";

        }

        public void OnTurnChange(GameColor currentPlayer)
        {
            CurrentMovingPlayer.Text = currentPlayer.ToString() + "'s turn";
        }

        public void OnEndGame(GameColor winner)
        {
            MessageBox.Show(winner.ToString() + "WINS");
            this.Hide();
            startForm.Show();
        }

        private void initializeDependencies()
        {
            whiteLayout = new WhiteLayout();
            blackLayout = new BlackLayout();
            notifier = new Notifier();
            drawManager = new DrawManager(squareSize);
            move = new Move();

            notifier.Subscribe(EventType.ChangeTurn, OnTurnChange);
            notifier.Subscribe(EventType.EndGame,OnEndGame);

            board = new Board(whiteLayout, blackLayout, notifier, move, drawManager, squareSize);
            board.Location = new Point(40, 15);
            refree = new Refree(board, notifier);
        }
    }
}