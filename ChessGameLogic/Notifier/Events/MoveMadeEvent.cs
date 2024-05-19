using ChessGameLogic.Interfaces;

namespace ChessGameLogic.Events
{
    internal class MoveMadeEvent : IEvent
    {
        private Action OnMoveMade;

        public void Notify(object args)
        {
            OnMoveMade?.Invoke();
        }

        public void Subscribe(Delegate handler)
        {
            if (handler is Action moveMade)
            {
                OnMoveMade += moveMade;
            }
        }

        public void Unsubscribe(Delegate handler)
        {
            if (handler is Action moveMade)
            {
                OnMoveMade -= moveMade;
            }
        }
    }
}