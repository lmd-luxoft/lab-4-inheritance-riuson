namespace Chess.Figures
{
    public class PawnFigure : ChessFigure
    {
        public PawnFigure(string currentCoord) : base(FigureType.PAWN, currentCoord)
        {
        }

        protected override bool CheckRules(MovementData movementData)
        {
            if (!movementData.IsVertical)
                return false;
            if (movementData.DeltaY <= 0)
                return false;
            if (movementData.Start.Y == '2' && movementData.End.Y == '4')
                return true;
            if (movementData.DeltaY != 1)
                return false;

            return true;
        }
    }
}