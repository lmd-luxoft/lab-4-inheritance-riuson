// NUnit 3 tests
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
            var figure = new ChessFigure(ChessFigure.Type.ROOK, "E2");
            Assert.AreEqual(true, figure.Move("C2"));
        }

        [Test]
        public void RookShouldBeIncorrectMove()
        {
            var figure = new ChessFigure(ChessFigure.Type.ROOK, "E2");
            Assert.AreEqual(false, figure.Move("C5"));
        }

        [Test]
        public void KnightShouldBeCorrectMove()
        {
            var figure = new ChessFigure(ChessFigure.Type.KNIGHT, "B1");
            Assert.AreEqual(true, figure.Move("C3"));
        }

        [Test]
        public void KnightShouldBeIncorrectMove()
        {
            var figure = new ChessFigure(ChessFigure.Type.KNIGHT, "B1");
            Assert.AreEqual(false, figure.Move("C5"));
        }

        [Test]
        public void BishopShouldBeCorrectMove()
        {
            var figure = new ChessFigure(ChessFigure.Type.BISHOP, "C1");
            Assert.AreEqual(true, figure.Move("E3"));
        }

        [Test]
        public void BishopShouldBeIncorrectMove()
        {
            var figure = new ChessFigure(ChessFigure.Type.BISHOP, "C1");
            Assert.AreEqual(false, figure.Move("C3"));
        }

        [Test]
        public void PawnShouldBeCorrectMove0()
        {
            var figure = new ChessFigure(ChessFigure.Type.PAWN, "E2");
            Assert.AreEqual(true, figure.Move("E3"));
        }

        [Test]
        public void PawnShouldBeCorrectMove1()
        {
            var figure = new ChessFigure(ChessFigure.Type.PAWN, "E2");
            Assert.AreEqual(true, figure.Move("E4"));
        }

        [Test]
        public void PawnShouldBeCorrectMove2()
        {
            var figure = new ChessFigure(ChessFigure.Type.PAWN, "E4");
            Assert.AreEqual(true, figure.Move("E5"));
        }

        [Test]
        public void PawnShouldBeIncorrectMove()
        {
            var figure = new ChessFigure(ChessFigure.Type.PAWN, "E2");
            Assert.AreEqual(false, figure.Move("C5"));
        }

        [Test]
        public void KingShouldBeCorrectMove()
        {
            var figure = new ChessFigure(ChessFigure.Type.KING, "E1");
            Assert.AreEqual(true, figure.Move("E2"));
        }

        [Test]
        public void KingShouldBeIncorrectMove()
        {
            var figure = new ChessFigure(ChessFigure.Type.KING, "E1");
            Assert.AreEqual(false, figure.Move("E8"));
        }

        [Test]
        public void QueenShouldBeCorrectMoveVertical()
        {
            var figure = new ChessFigure(ChessFigure.Type.QUEEN, "D1");
            Assert.AreEqual(true, figure.Move("D8"));
        }

        [Test]
        public void QueenShouldBeCorrectMoveDiagonal()
        {
            var figure = new ChessFigure(ChessFigure.Type.QUEEN, "D1");
            Assert.AreEqual(true, figure.Move("H5"));
        }

        [Test]
        public void QueenShouldBeIncorrectMove()
        {
            var figure = new ChessFigure(ChessFigure.Type.QUEEN, "D1");
            Assert.AreEqual(false, figure.Move("E3"));
        }


        [Test]
        public void FigureCanUseLowerCasePosition()
        {
            var figure = new ChessFigure(ChessFigure.Type.QUEEN, "d1");
            Assert.AreEqual(true, figure.Move("h5"));
        }
    }
}