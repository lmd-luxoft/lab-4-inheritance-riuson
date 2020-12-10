using System;

namespace Chess
{
    public class Coordinates
    {
        public char X { get; }
        public char Y { get; }

        public static Coordinates Empty { get; }

        public bool IsEmpty { get; }
        public bool IsValid { get; }

        public static bool TryParse(string s, out Coordinates result)
        {
            throw new NotImplementedException();
        }
    }
}