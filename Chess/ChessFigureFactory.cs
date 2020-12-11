using System;
using System.Collections.Generic;
using Chess.Figures;

namespace Chess
{
    public static class ChessFigureFactory
    {
        private static readonly Dictionary<FigureType, Func<string, ChessFigure>> _constructors =
            new Dictionary<FigureType, Func<string, ChessFigure>>
            {
                {FigureType.PAWN, coord => new PawnFigure(coord)},
                {FigureType.ROOK, coord => new RookFigure(coord)},
                {FigureType.KNIGHT, coord => new KnightFigure(coord)},
                {FigureType.BISHOP, coord => new BishopFigure(coord)},
                {FigureType.KING, coord => new KingFigure(coord)},
                {FigureType.QUEEN, coord => new QueenFigure(coord)}
            };

        public static ChessFigure Create(FigureType type, string currentCoord)
        {
            return _constructors[type](currentCoord);
        }
    }
}