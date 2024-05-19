using ChessGameLogic.Interfaces;

namespace ChessGameLogic.Events
{
    internal class MakeMoveEvent : IEvent
    {
        private event Action<IMove> OnMakeMove;

        public void Notify(object args)
        {
            OnMakeMove?.Invoke((IMove)args);
        }

        public void Subscribe(Delegate handler)
        {
            if (handler is Action<IMove> makeMove)
            {
                OnMakeMove += makeMove;
            }
        }

        public void Unsubscribe(Delegate handler)
        {
            if (handler is Action<IMove> makeMove)
            {
                OnMakeMove -= makeMove;
            }
        }
    }
}