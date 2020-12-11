
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

            var mvData = new MovementData(this.Coordinates, nextCoord);

            if (!mvData.IsValid)
            {
                return false;
            }

			if (type == FigureType.PAWN)
			{
				if (!mvData.IsVertical)
					return false;
				if (mvData.DeltaY <= 0)
					return false;
                if (mvData.Start.Y == '2' && mvData.End.Y == '4')
                    return true;
				if (mvData.DeltaY != 1)
					return false;

                return true;
            }

			if (type == FigureType.ROOK)
			{
				if ((mvData.DeltaX != 0) && (mvData.DeltaY != 0))
					return false;

                return true;
			}
			
            if (type == FigureType.KNIGHT)
			{
                if (Math.Abs(mvData.DeltaX) == 1 && Math.Abs(mvData.DeltaY) == 2)
					return true;
				if (Math.Abs(mvData.DeltaX) == 2 && Math.Abs(mvData.DeltaY) == 1)
					return true;

				return false;
			}

			if (type == FigureType.BISHOP)
			{
				return mvData.IsDiagonal;
			}

			if (type == FigureType.KING)
			{
				if (Math.Abs(mvData.DeltaX) <= 1 && Math.Abs(mvData.DeltaY) <= 1)
					return true;
			
                return false;
			}
			
            if (type == FigureType.QUEEN)
			{
				if (mvData.IsDiagonal)
					return true;
				if (mvData.IsVertical)
					return true;
				if (mvData.IsHorizontal)
					return true;
				
                return false;
			}
			
            return false;
		}
    }
}
