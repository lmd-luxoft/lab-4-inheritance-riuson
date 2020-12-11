namespace Chess.Figures
{
    public class QueenFigure : ChessFigure
    {
        public QueenFigure(string currentCoord) : base(currentCoord)
        {
        }

        protected override bool CheckRules(MovementData movementData)
        {
            if (movementData.IsDiagonal)
                return true;
            if (movementData.IsVertical)
                return true;
            if (movementData.IsHorizontal)
                return true;

            return false;
        }
    }
}