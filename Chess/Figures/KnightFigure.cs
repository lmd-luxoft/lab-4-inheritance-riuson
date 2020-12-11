using System;

namespace Chess.Figures
{
    public class KnightFigure : ChessFigure
    {
        public KnightFigure(string currentCoord) : base(FigureType.KNIGHT, currentCoord)
        {
        }

        protected override bool CheckRules(MovementData movementData)
        {
            if (Math.Abs(movementData.DeltaX) == 1 && Math.Abs(movementData.DeltaY) == 2)
                return true;
            if (Math.Abs(movementData.DeltaX) == 2 && Math.Abs(movementData.DeltaY) == 1)
                return true;

            return false;
        }
    }
}