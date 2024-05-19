using ChessGameLogic.Interfaces.Layout;


namespace ChessGameLogic.Interfaces
{
    internal interface IBoard
    {
        ILayout CurrentLayout { get; set; }
        ILayout OpponentLayout { get; set; }

        void Initialize();
    }
}