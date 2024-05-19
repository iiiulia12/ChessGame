using ChessGameLogic.Enums;
using System.Drawing;
using System.Xml.Schema;

namespace ChessGameLogic.Interfaces.Layout
{
    internal interface ILayout : IBaseLayout
    {
        void Initialize();
        HashSet<Position> GetAllAvailablePositions(ILayout opponent);
        ILayout Clone();

    }
}