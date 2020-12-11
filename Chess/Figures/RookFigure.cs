namespace Chess.Figures
{
    public class RookFigure : ChessFigure
    {
        public RookFigure(string currentCoord) : base(FigureType.ROOK, currentCoord)
        {
        }

        protected override bool CheckRules(MovementData movementData)
        {
            if (movementData.DeltaX != 0 && movementData.DeltaY != 0)
                return false;

            return true;
        }
    }
}