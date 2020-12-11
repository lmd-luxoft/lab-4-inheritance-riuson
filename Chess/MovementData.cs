namespace Chess
{
    public class MovementData
    {
        public MovementData(Coordinates start, Coordinates end)
        {
            Start = start;
            End = end;
        }

        public Coordinates Start { get; }
        public Coordinates End { get; }

        public int DeltaX => End.X - Start.X;
        public int DeltaY => End.Y - Start.Y;
        public bool IsValid => Start.IsValid && End.IsValid;
        public bool IsDiagonal { get; }
    }
}