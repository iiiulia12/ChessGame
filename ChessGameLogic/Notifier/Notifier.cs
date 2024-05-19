using ChessGameLogic.Enums;
using ChessGameLogic.Events;
using ChessGameLogic.Interfaces;

namespace ChessGameLogic.Notifier
{
    internal class Notifier : INotifier
    {
        private readonly Dictionary<EventType, IEvent> events = new Dictionary<EventType, IEvent>();

        public Notifier()
        {
            events[EventType.MakeMove] = new MakeMoveEvent();
            events[EventType.MoveMade] = new MoveMadeEvent();
            events[EventType.MoveProposed] = new MoveProposedEvent();
            events[EventType.ChangeTurn] = new ChangeTurnEvent();
            events[EventType.EndGame] = new EndGameEvent();
        }

        public void Notify(EventType eventName, object args)
        {
            events[eventName].Notify(args);
        }

        public void Subscribe(EventType eventName, Delegate handler)
        {
            events[eventName].Subscribe(handler);
        }

        public void Unsubscribe(EventType eventName, Delegate handler)
        {
            events[eventName].Unsubscribe(handler);
        }
    }
}