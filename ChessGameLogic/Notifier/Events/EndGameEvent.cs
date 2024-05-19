using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;

namespace ChessGameLogic.Events
{
    internal class EndGameEvent : IEvent
    {
        private Action<GameColor> OnEndGame;

        public void Notify(object args)
        {
            OnEndGame?.Invoke((GameColor)args);
        }

        public void Subscribe(Delegate handler)
        {
            if (handler is Action<GameColor> endGame)
            {
                OnEndGame += endGame;
            }
        }

        public void Unsubscribe(Delegate handler)
        {
            if (handler is Action<GameColor> endGame)
            {
                OnEndGame -= endGame;
            }
        }
    }
}