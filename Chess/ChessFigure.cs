
using System;

namespace Chess
{
    public class ChessFigure
    {
        private FigureType type;

        public ChessFigure(FigureType type, string currentCoord)
        {
            this.type = type;

            if (Coordinates.TryParse(currentCoord, out var coordinates))
            {
                this.Coordinates = coordinates;
            }
            else
            {
                throw new FigureException("Нельзя разместить фигуру по неправильным координатам!");
            }
        }

		public Coordinates Coordinates { get; }

        public enum FigureType
        {
			/// <summary>
			/// Ладья.
			/// </summary>
            ROOK,
			/// <summary>
			/// Конь.
			/// </summary>
            KNIGHT,
			/// <summary>
			/// Слон.
			/// </summary>
            BISHOP,
			/// <summary>
			/// Пешка.
			/// </summary>
            PAWN,
			/// <summary>
			/// Король.
			/// </summary>
            KING,
			/// <summary>
			/// Ферзь.
			/// </summary>
            QUEEN
        }

        public bool Move(string strNextCoord)
        {
            if (!Coordinates.TryParse(strNextCoord, out var nextCoord))
            {
                return false;
            }

			if (type == FigureType.PAWN)
			{
				if (nextCoord.X != Coordinates.X || nextCoord.Y <= Coordinates.Y || (nextCoord.Y - Coordinates.Y != 1 && (Coordinates.Y != '2' || nextCoord.Y != '4')))
					return false;
				else
					return true;
			}

			else if (type == FigureType.ROOK)
			{
				if ((nextCoord.X != Coordinates.X) && (nextCoord.Y != Coordinates.Y) || ((nextCoord.X == Coordinates.X) && (nextCoord.Y == Coordinates.Y)))
					return false;
				else
					return true;
			}
			else if (type == FigureType.KNIGHT)
			{
				int dx, dy;
				dx = Math.Abs(nextCoord.X - Coordinates.X);
				dy = Math.Abs(nextCoord.Y - Coordinates.Y);
				if (!(Math.Abs(nextCoord.X - Coordinates.X) == 1 && Math.Abs(nextCoord.Y - Coordinates.Y) == 2 || Math.Abs(nextCoord.X - Coordinates.X) == 2 && Math.Abs(nextCoord.Y - Coordinates.Y) == 1))
					return false;
				else
					return true;
			}

			else if (type == FigureType.BISHOP)
			{
				if (!(Math.Abs(nextCoord.X - Coordinates.X) == Math.Abs(nextCoord.Y - Coordinates.Y)))
					return false;
				else
					return true;
			}

			else if (type == FigureType.KING)
			{
				if (!(Math.Abs(nextCoord.X - Coordinates.X) <= 1 && Math.Abs(nextCoord.Y - Coordinates.Y) <= 1))
					return false;
				else
					return true;
			}
			else if (type == FigureType.QUEEN)
			{
				if (!(Math.Abs(nextCoord.X - Coordinates.X) == Math.Abs(nextCoord.Y - Coordinates.Y) || nextCoord.X == Coordinates.X || nextCoord.Y == Coordinates.Y))
					return false;
				else
					return true;
			}
			else
				return false;
		}
    }
}
