namespace Chess.Figures
{
    public abstract class ChessFigure
    {
        public ChessFigure(string currentCoord)
        {
            if (Coordinates.TryParse(currentCoord, out var coordinates))
                Coordinates = coordinates;
            else
                throw new FigureException("Нельзя разместить фигуру по неправильным координатам!");
        }

        public Coordinates Coordinates { get; }

        public bool Move(string strNextCoord)
        {
            if (!Coordinates.TryParse(strNextCoord, out var nextCoord)) return false;

            var mvData = new MovementData(Coordinates, nextCoord);

            if (!mvData.IsValid) return false;

            return CheckRules(mvData);
        }

        protected abstract bool CheckRules(MovementData movementData);
    }
}