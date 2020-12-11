using System;

namespace Chess.Figures
{
    public class KingFigure : ChessFigure
    {
        public KingFigure(string currentCoord) : base(FigureType.KING, currentCoord)
        {
        }

        protected override bool CheckRules(MovementData movementData)
        {
            if (Math.Abs(movementData.DeltaX) <= 1 && Math.Abs(movementData.DeltaY) <= 1)
                return true;

            return false;
        }
    }
}