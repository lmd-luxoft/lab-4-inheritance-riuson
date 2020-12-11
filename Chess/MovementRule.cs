using System;
using System.Collections.Generic;

namespace Chess
{
    public static class MovementRules
    {
        public delegate bool MovementRule(MovementData movementData);

        private static readonly Dictionary<ChessFigure.FigureType, MovementRule> _checks =
            new Dictionary<ChessFigure.FigureType, MovementRule>
            {
                {ChessFigure.FigureType.PAWN, CheckPawn},
                {ChessFigure.FigureType.ROOK, CheckRook},
                {ChessFigure.FigureType.KNIGHT, CheckKnight},
                {ChessFigure.FigureType.BISHOP, CheckBishop},
                {ChessFigure.FigureType.KING, CheckKing},
                {ChessFigure.FigureType.QUEEN, CheckQueen}
            };

        public static MovementRule GetRule(ChessFigure.FigureType type)
        {
            return _checks[type];
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
    }
}