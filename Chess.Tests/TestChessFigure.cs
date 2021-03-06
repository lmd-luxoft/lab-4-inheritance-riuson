﻿using NUnit.Framework;

namespace Chess.Tests
{
    [TestFixture]
    internal class TestChessFigure
    {
        [TestCase("A1")]
        [TestCase("B8")]
        [TestCase("h7")]
        public void CanCreateFigureWithValidCoordinates(string coord)
        {
            // Arrange & Act.
            var figure = ChessFigureFactory.Create(FigureType.PAWN, coord);

            // Assert.
            Assert.That(figure.Coordinates.IsValid, Is.True);
        }

        [TestCase("A9")]
        [TestCase("__")]
        [TestCase("")]
        [TestCase(null)]
        public void CannotCreateFigureWithInvalidCoordinates(string coord)
        {
            // Arrange & Act && Assert.
            Assert.Throws<FigureException>(() => ChessFigureFactory.Create(FigureType.PAWN, coord));
        }
    }
}