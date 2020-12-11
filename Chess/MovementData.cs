using System;

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
        public bool IsValid => Start.IsValid && End.IsValid && Start != End;
        public bool IsDiagonal => IsValid && Math.Abs(DeltaX) == Math.Abs(DeltaY);
    }
}