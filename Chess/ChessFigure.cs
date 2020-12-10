
using System;

namespace Chess
{
    public class ChessFigure
    {
        private FigureType type;
        private string currentCoord;

        public ChessFigure(FigureType type, string currentCoord)
        {
            this.type = type;
            this.currentCoord = currentCoord.ToUpper();
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

        public bool Move(string nextCoord)
        {
            string nextCoordUpperCase = nextCoord.ToUpper();

			if (type == FigureType.PAWN)
			{
				if (nextCoordUpperCase[0] >= 'A' && nextCoordUpperCase[0] <= 'H' && nextCoordUpperCase[1] >= '1' && nextCoordUpperCase[1] <= '8')
				{
					if (nextCoordUpperCase[0] != currentCoord[0] || nextCoordUpperCase[1] <= currentCoord[1] || (nextCoordUpperCase[1] - currentCoord[1] != 1 && (currentCoord[1] != '2' || nextCoordUpperCase[1] != '4')))
						return false;
					else
						return true;
				}
				else return false;

			}

			else if (type == FigureType.ROOK)
			{
				if (nextCoordUpperCase[0] >= 'A' && nextCoordUpperCase[0] <= 'H' && nextCoordUpperCase[1] >= '1' && nextCoordUpperCase[1] <= '8')
				{
					if ((nextCoordUpperCase[0] != currentCoord[0]) && (nextCoordUpperCase[1] != currentCoord[1]) || ((nextCoordUpperCase[0] == currentCoord[0]) && (nextCoordUpperCase[1] == currentCoord[1])))
						return false;
					else
						return true;

				}
				else return false;
			}
			else if (type == FigureType.KNIGHT)
			{
				if (nextCoordUpperCase[0] >= 'A' && nextCoordUpperCase[0] <= 'H' && nextCoordUpperCase[1] >= '1' && nextCoordUpperCase[1] <= '8')
				{
					int dx, dy;
					dx = Math.Abs(nextCoordUpperCase[0] - currentCoord[0]);
					dy = Math.Abs(nextCoordUpperCase[1] - currentCoord[1]);
					if (!(Math.Abs(nextCoordUpperCase[0] - currentCoord[0]) == 1 && Math.Abs(nextCoordUpperCase[1] - currentCoord[1]) == 2 || Math.Abs(nextCoordUpperCase[0] - currentCoord[0]) == 2 && Math.Abs(nextCoordUpperCase[1] - currentCoord[1]) == 1))
						return false;
					else
						return true;
				}
				else return false;
			}

			else if (type == FigureType.BISHOP)
			{
				if (nextCoordUpperCase[0] >= 'A' && nextCoordUpperCase[0] <= 'H' && nextCoordUpperCase[1] >= '1' && nextCoordUpperCase[1] <= '8')
				{
					if (!(Math.Abs(nextCoordUpperCase[0] - currentCoord[0]) == Math.Abs(nextCoordUpperCase[1] - currentCoord[1])))
						return false;
					else
						return true;
				}
				else return false;
			}

			else if (type == FigureType.KING)
			{
				if (nextCoordUpperCase[0] >= 'A' && nextCoordUpperCase[0] <= 'H' && nextCoordUpperCase[1] >= '1' && nextCoordUpperCase[1] <= '8')
				{
					if (!(Math.Abs(nextCoordUpperCase[0] - currentCoord[0]) <= 1 && Math.Abs(nextCoordUpperCase[1] - currentCoord[1]) <= 1))
						return false;
					else
						return true;
				}
				else return false;
			}
			else if (type == FigureType.QUEEN)
			{
				if (nextCoordUpperCase[0] >= 'A' && nextCoordUpperCase[0] <= 'H' && nextCoordUpperCase[1] >= '1' && nextCoordUpperCase[1] <= '8')
				{
					if (!(Math.Abs(nextCoordUpperCase[0] - currentCoord[0]) == Math.Abs(nextCoordUpperCase[1] - currentCoord[1]) || nextCoordUpperCase[0] == currentCoord[0] || nextCoordUpperCase[1] == currentCoord[1]))
						return false;
					else
						return true;
				}
				else return false;
			}
			else
				return false;
		}
    }
}
