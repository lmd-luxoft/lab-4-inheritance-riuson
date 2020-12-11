using System;
using System.Collections.Generic;

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

        private static readonly Dictionary<FigureType, CheckMovement> _checks =
            new Dictionary<FigureType, CheckMovement>
            {
                {FigureType.PAWN, CheckPawn},
                {FigureType.ROOK, CheckRook},
                {FigureType.KNIGHT, CheckKnight},
                {FigureType.BISHOP, CheckBishop},
                {FigureType.KING, CheckKing},
                {FigureType.QUEEN, CheckQueen}
            };

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

            var checkMovement = _checks[_type];

            return checkMovement(mvData);
        }

        private static bool CheckPawn(MovementData movementData)
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

        private static bool CheckRook(MovementData movementData)
        {
            if (movementData.DeltaX != 0 && movementData.DeltaY != 0)
                return false;

            return true;
        }

        private static bool CheckKnight(MovementData movementData)
        {
            if (Math.Abs(movementData.DeltaX) == 1 && Math.Abs(movementData.DeltaY) == 2)
                return true;
            if (Math.Abs(movementData.DeltaX) == 2 && Math.Abs(movementData.DeltaY) == 1)
                return true;

            return false;
        }

        private static bool CheckBishop(MovementData movementData)
        {
            return movementData.IsDiagonal;
        }

        private static bool CheckKing(MovementData movementData)
        {
            if (Math.Abs(movementData.DeltaX) <= 1 && Math.Abs(movementData.DeltaY) <= 1)
                return true;

            return false;
        }

        private static bool CheckQueen(MovementData movementData)
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