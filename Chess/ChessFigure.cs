
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
				if (nextCoord.X != Coordinates.X)
					return false;
				if (nextCoord.Y <= Coordinates.Y)
					return false;
				if (nextCoord.Y - Coordinates.Y != 1 && (Coordinates.Y != '2' || nextCoord.Y != '4'))
					return false;

                return true;
            }

			if (type == FigureType.ROOK)
			{
				if ((nextCoord.X != Coordinates.X) && (nextCoord.Y != Coordinates.Y))
					return false;
				if ((nextCoord.X == Coordinates.X) && (nextCoord.Y == Coordinates.Y))
					return false;

                return true;
			}
			
            if (type == FigureType.KNIGHT)
			{
				var dx = Math.Abs(nextCoord.X - Coordinates.X);
				var dy = Math.Abs(nextCoord.Y - Coordinates.Y);

                if (Math.Abs(nextCoord.X - Coordinates.X) == 1 && Math.Abs(nextCoord.Y - Coordinates.Y) == 2)
					return true;
				if (Math.Abs(nextCoord.X - Coordinates.X) == 2 && Math.Abs(nextCoord.Y - Coordinates.Y) == 1)
					return true;

				return false;
			}

			if (type == FigureType.BISHOP)
			{
				if (Math.Abs(nextCoord.X - Coordinates.X) == Math.Abs(nextCoord.Y - Coordinates.Y))
					return true;
				
				return false;
			}

			if (type == FigureType.KING)
			{
				if (Math.Abs(nextCoord.X - Coordinates.X) <= 1 && Math.Abs(nextCoord.Y - Coordinates.Y) <= 1)
					return true;
			
                return false;
			}
			
            if (type == FigureType.QUEEN)
			{
				if (Math.Abs(nextCoord.X - Coordinates.X) == Math.Abs(nextCoord.Y - Coordinates.Y))
					return true;
				if (nextCoord.X == Coordinates.X)
					return true;
				if (nextCoord.Y == Coordinates.Y)
					return true;
				
                return false;
			}
			
            return false;
		}
    }
}
