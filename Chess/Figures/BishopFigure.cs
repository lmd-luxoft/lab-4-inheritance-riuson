namespace Chess.Figures
{
    public class BishopFigure : ChessFigure
    {
        public BishopFigure(string currentCoord) : base(FigureType.BISHOP, currentCoord)
        {
        }

        protected override bool CheckRules(MovementData movementData)
        {
            return movementData.IsDiagonal;
        }
    }
}