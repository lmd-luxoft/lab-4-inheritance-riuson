﻿// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using NUnit.Framework;

namespace Chess.Tests
{
    [TestFixture]
    public class TestMovements
    {
        [Test]
        public void RookShouldBeCorrectMove()
        {
            var figure = ChessFigureFactory.Create(FigureType.ROOK, "E2");
            Assert.AreEqual(true, figure.Move("C2"));
        }

        [Test]
        public void RookShouldBeIncorrectMove()
        {
            var figure = ChessFigureFactory.Create(FigureType.ROOK, "E2");
            Assert.AreEqual(false, figure.Move("C5"));
        }

        [Test]
        public void KnightShouldBeCorrectMove()
        {
            var figure = ChessFigureFactory.Create(FigureType.KNIGHT, "B1");
            Assert.AreEqual(true, figure.Move("C3"));
        }

        [Test]
        public void KnightShouldBeIncorrectMove()
        {
            var figure = ChessFigureFactory.Create(FigureType.KNIGHT, "B1");
            Assert.AreEqual(false, figure.Move("C5"));
        }

        [Test]
        public void BishopShouldBeCorrectMove()
        {
            var figure = ChessFigureFactory.Create(FigureType.BISHOP, "C1");
            Assert.AreEqual(true, figure.Move("E3"));
        }

        [Test]
        public void BishopShouldBeIncorrectMove()
        {
            var figure = ChessFigureFactory.Create(FigureType.BISHOP, "C1");
            Assert.AreEqual(false, figure.Move("C3"));
        }

        [Test]
        public void PawnShouldBeCorrectMove0()
        {
            var figure = ChessFigureFactory.Create(FigureType.PAWN, "E2");
            Assert.AreEqual(true, figure.Move("E3"));
        }

        [Test]
        public void PawnShouldBeCorrectMove1()
        {
            var figure = ChessFigureFactory.Create(FigureType.PAWN, "E2");
            Assert.AreEqual(true, figure.Move("E4"));
        }

        [Test]
        public void PawnShouldBeCorrectMove2()
        {
            var figure = ChessFigureFactory.Create(FigureType.PAWN, "E4");
            Assert.AreEqual(true, figure.Move("E5"));
        }

        [Test]
        public void PawnShouldBeIncorrectMove()
        {
            var figure = ChessFigureFactory.Create(FigureType.PAWN, "E2");
            Assert.AreEqual(false, figure.Move("C5"));
        }

        [Test]
        public void KingShouldBeCorrectMove()
        {
            var figure = ChessFigureFactory.Create(FigureType.KING, "E1");
            Assert.AreEqual(true, figure.Move("E2"));
        }

        [Test]
        public void KingShouldBeIncorrectMove()
        {
            var figure = ChessFigureFactory.Create(FigureType.KING, "E1");
            Assert.AreEqual(false, figure.Move("E8"));
        }

        [Test]
        public void QueenShouldBeCorrectMoveVertical()
        {
            var figure = ChessFigureFactory.Create(FigureType.QUEEN, "D1");
            Assert.AreEqual(true, figure.Move("D8"));
        }

        [Test]
        public void QueenShouldBeCorrectMoveDiagonal()
        {
            var figure = ChessFigureFactory.Create(FigureType.QUEEN, "D1");
            Assert.AreEqual(true, figure.Move("H5"));
        }

        [Test]
        public void QueenShouldBeIncorrectMove()
        {
            var figure = ChessFigureFactory.Create(FigureType.QUEEN, "D1");
            Assert.AreEqual(false, figure.Move("E3"));
        }


        [Test]
        public void FigureCanUseLowerCasePosition()
        {
            var figure = ChessFigureFactory.Create(FigureType.QUEEN, "d1");
            Assert.AreEqual(true, figure.Move("h5"));
        }

        [Test]
        public void FigureCannotMoveToInvalidPosition()
        {
            var figure = ChessFigureFactory.Create(FigureType.KING, "E1");
            Assert.AreEqual(false, figure.Move("E0"));
        }
    }
}