using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;

namespace ChessGameLogic.Events
{
    internal class ChangeTurnEvent : IEvent
    {
        private event Action<GameColor> OnChangeTurn;

        public void Notify(object args)
        {
            OnChangeTurn?.Invoke((GameColor)args);
        }

        public void Subscribe(Delegate handler)
        {
            if (handler is Action<GameColor> changeTurnHandler)
            {
                OnChangeTurn += changeTurnHandler;
            }
        }

        public void Unsubscribe(Delegate handler)
        {
            if (handler is Action<GameColor> changeTurnHandler)
            {
                OnChangeTurn -= changeTurnHandler;
            }
        }
    }
}