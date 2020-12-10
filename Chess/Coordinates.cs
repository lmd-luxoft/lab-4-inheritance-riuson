namespace Chess
{
    public class Coordinates
    {
        private Coordinates()
        {
        }

        public Coordinates(char x, char y)
        {
            IsEmpty = false;
            X = x;
            Y = y;
        }

        public char X { get; }
        public char Y { get; }

        public static Coordinates Empty { get; } = new Coordinates();

        public bool IsEmpty { get; } = true;

        public bool IsValid => IsValidValues(X, Y);

        public static bool TryParse(string s, out Coordinates result)
        {
            result = new Coordinates(' ', ' ');

            if (string.IsNullOrWhiteSpace(s)) return false;

            if (s.Length != 2) return false;

            var upperCase = s.ToUpper();

            result = new Coordinates(upperCase[0], upperCase[1]);

            return result.IsValid;
        }

        private static bool IsValidValues(char x, char y)
        {
            return x >= 'A' && x <= 'H' && y >= '1' && y <= '8';
        }

        public bool Equals(Coordinates other)
        {
            if (ReferenceEquals(other, null)) return false;

            if (ReferenceEquals(this, other)) return true;

            if (GetType() != other.GetType()) return false;

            if (IsEmpty && other.IsEmpty) return true;

            if (!IsValid || !other.IsValid) return false;

            return X == other.X && Y == other.Y;
        }

        public static bool operator ==(Coordinates lhs, Coordinates rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Coordinates lhs, Coordinates rhs)
        {
            return !(lhs == rhs);
        }
    }
}