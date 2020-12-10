using System;

namespace Chess
{
    public class FigureException : Exception
    {
        public FigureException(string message) : base(message)
        {
        }
    }
}