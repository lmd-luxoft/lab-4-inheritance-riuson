using System;

namespace Chess
{
    public class MovementData
    {
        public MovementData(Coordinates start, Coordinates end)
        {
        }

        public Coordinates Start { get; }
        public Coordinates End { get; }

        public int DeltaX => throw new NotImplementedException();
        public int DeltaY => throw new NotImplementedException();
        public bool IsValid { get; }
    }
}