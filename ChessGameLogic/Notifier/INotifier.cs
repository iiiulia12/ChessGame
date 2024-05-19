using ChessGameLogic.Enums;
using ChessGameLogic.Interfaces;

namespace ChessGameLogic.Notifier
{
    internal interface INotifier
    {
        void Notify(EventType eventName,  object args= null);
        void Subscribe(EventType eventName, Delegate handler);
        void Unsubscribe(EventType eventName, Delegate handler);

    }
}