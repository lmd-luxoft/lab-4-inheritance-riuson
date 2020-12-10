using System;

namespace Chess
{
    public class CoordinatesException : Exception
    {
        public CoordinatesException(string message) : base(message)
        {
        }
    }
}