using System;

namespace Chess
{
    public class ChessFigure
    {
        public enum FigureType
        {
            /// <summary>
            ///     Ладья.
            /// </summary>
            ROOK,

            /// <summary>
            ///     Конь.
            /// </summary>
            KNIGHT,

            /// <summary>
            ///     Слон.
            /// </summary>
            BISHOP,

            /// <summary>
            ///     Пешка.
            /// </summary>
            PAWN,

            /// <summary>
            ///     Король.
            /// </summary>
            KING,

            /// <summary>
            ///     Ферзь.
            /// </summary>
            QUEEN
        }

        private readonly FigureType _type;

        public ChessFigure(FigureType type, string currentCoord)
        {
            _type = type;

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

            if (_type == FigureType.PAWN) return CheckPawn(mvData);

            if (_type == FigureType.ROOK) return CheckRook(mvData);

            if (_type == FigureType.KNIGHT) return CheckKnight(mvData);

            if (_type == FigureType.BISHOP) return CheckBishop(mvData);

            if (_type == FigureType.KING) return CheckKing(mvData);

            if (_type == FigureType.QUEEN) return CheckQueen(mvData);

            return false;
        }

        private bool CheckPawn(MovementData movementData)
        {
            if (!movementData.IsVertical)
                return false;
            if (movementData.DeltaY <= 0)
                return false;
            if (movementData.Start.Y == '2' && movementData.End.Y == '4')
                return true;
            if (movementData.DeltaY != 1)
                return false;

            return true;
        }

        private bool CheckRook(MovementData movementData)
        {
            if (movementData.DeltaX != 0 && movementData.DeltaY != 0)
                return false;

            return true;
        }

        private bool CheckKnight(MovementData movementData)
        {
            if (Math.Abs(movementData.DeltaX) == 1 && Math.Abs(movementData.DeltaY) == 2)
                return true;
            if (Math.Abs(movementData.DeltaX) == 2 && Math.Abs(movementData.DeltaY) == 1)
                return true;

            return false;
        }

        private bool CheckBishop(MovementData movementData)
        {
            return movementData.IsDiagonal;
        }

        private bool CheckKing(MovementData movementData)
        {
            if (Math.Abs(movementData.DeltaX) <= 1 && Math.Abs(movementData.DeltaY) <= 1)
                return true;

            return false;
        }

        private bool CheckQueen(MovementData movementData)
        {
            if (movementData.IsDiagonal)
                return true;
            if (movementData.IsVertical)
                return true;
            if (movementData.IsHorizontal)
                return true;

            return false;
        }

        private delegate bool CheckMovement(MovementData movementData);
    }
}