namespace ChessGameLogic.Interfaces
{
    internal interface IEvent
    {
        void Notify(object args = null);
        void Subscribe(Delegate handler);
        void Unsubscribe( Delegate handler);
    }
}