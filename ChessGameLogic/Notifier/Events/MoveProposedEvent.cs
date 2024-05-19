using ChessGameLogic.Interfaces;

namespace ChessGameLogic.Events
{
    internal class MoveProposedEvent : IEvent
    {
        private Action<IMove> OnMoveProposed;

        public void Notify(object args)
        {
            OnMoveProposed?.Invoke((IMove)args);
        }

        public void Subscribe(Delegate handler)
        {
            if (handler is Action<IMove> proposedMove)
            {
                OnMoveProposed += proposedMove;
            }
        }

        public void Unsubscribe(Delegate handler)
        {
            if (handler is Action<IMove> proposedMove)
            {
                OnMoveProposed -= proposedMove;
            }
        }
    }
}