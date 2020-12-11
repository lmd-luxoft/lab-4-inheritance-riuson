﻿namespace Chess
{
    public class ChessFigure
    {
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

            var checkMovement = MovementRules.GetRule(_type);

            return checkMovement(mvData);
        }
    }
}