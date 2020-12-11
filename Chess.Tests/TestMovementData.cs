using NUnit.Framework;

namespace Chess.Tests
{
    [TestFixture]
    internal class TestMovementData
    {
        [Test]
        public void ShouldInitialize()
        {
            // Arrange.
            Coordinates.TryParse("A1", out var start);
            Coordinates.TryParse("C4", out var end);

            // Act.
            var movementData = new MovementData(start, end);

            // Assert.
            Assert.That(movementData.Start, Is.EqualTo(start));
            Assert.That(movementData.End, Is.EqualTo(end));
        }

        [TestCase("A1", "H7", 7, 6)]
        [TestCase("A1", "B2", 1, 1)]
        [TestCase("A1", "A1", 0, 0)]
        [TestCase("B2", "A1", -1, -1)]
        public void ShouldCalculateDeltas(string startStr, string endStr, int expectedDeltaX, int expectedDeltaY)
        {
            // Arrange.
            Coordinates.TryParse(startStr, out var start);
            Coordinates.TryParse(endStr, out var end);

            // Act.
            var movementData = new MovementData(start, end);

            // Assert.
            Assert.That(movementData.DeltaX, Is.EqualTo(expectedDeltaX));
            Assert.That(movementData.DeltaY, Is.EqualTo(expectedDeltaY));
        }

        [TestCase("A1", "H7", ExpectedResult = true)]
        [TestCase("A1", "B2", ExpectedResult = true)]
        [TestCase("A1", "A1", ExpectedResult = false)]
        [TestCase("B2", "A1", ExpectedResult = true)]
        [TestCase("A1", "H9", ExpectedResult = false)]
        [TestCase("A0", "B2", ExpectedResult = false)]
        [TestCase("A0", "F9", ExpectedResult = false)]
        [TestCase("B2", "A10", ExpectedResult = false)]
        [TestCase("B7", "B7", ExpectedResult = false)]
        public bool ShouldCheck(string startStr, string endStr)
        {
            // Arrange.
            Coordinates.TryParse(startStr, out var start);
            Coordinates.TryParse(endStr, out var end);

            // Act.
            var movementData = new MovementData(start, end);

            // Assert.
            return movementData.IsValid;
        }

        [TestCase("A1", "H8", ExpectedResult = true)]
        [TestCase("A1", "B2", ExpectedResult = true)]
        [TestCase("B3", "D5", ExpectedResult = true)]
        [TestCase("G1", "D4", ExpectedResult = true)]
        [TestCase("A1", "B1", ExpectedResult = false)]
        [TestCase("E2", "E4", ExpectedResult = false)]
        [TestCase("D3", "E3", ExpectedResult = false)]
        [TestCase("E5", "E4", ExpectedResult = false)]
        public bool ShoudCheckDiagonal(string startStr, string endStr)
        {
            // Arrange.
            Coordinates.TryParse(startStr, out var start);
            Coordinates.TryParse(endStr, out var end);

            // Act.
            var movementData = new MovementData(start, end);

            // Assert.
            return movementData.IsDiagonal;
        }

        [TestCase("A1", "B1", ExpectedResult = true)]
        [TestCase("H7", "E7", ExpectedResult = true)]
        [TestCase("A3", "B3", ExpectedResult = true)]
        [TestCase("A1", "A1", ExpectedResult = false)]
        [TestCase("B7", "B7", ExpectedResult = false)]
        [TestCase("A1", "A2", ExpectedResult = false)]
        [TestCase("E2", "E4", ExpectedResult = false)]
        [TestCase("A1", "H8", ExpectedResult = false)]
        public bool ShoudCheckHorizontal(string startStr, string endStr)
        {
            // Arrange.
            Coordinates.TryParse(startStr, out var start);
            Coordinates.TryParse(endStr, out var end);

            // Act.
            var movementData = new MovementData(start, end);

            // Assert.
            return movementData.IsHorizontal;
        }

        [TestCase("A1", "A2", ExpectedResult = true)]
        [TestCase("H7", "H1", ExpectedResult = true)]
        [TestCase("B3", "B6", ExpectedResult = true)]
        [TestCase("A1", "A1", ExpectedResult = false)]
        [TestCase("A1", "B1", ExpectedResult = false)]
        [TestCase("H7", "G6", ExpectedResult = false)]
        [TestCase("H8", "A1", ExpectedResult = false)]
        public bool ShoudCheckVertical(string startStr, string endStr)
        {
            // Arrange.
            Coordinates.TryParse(startStr, out var start);
            Coordinates.TryParse(endStr, out var end);

            // Act.
            var movementData = new MovementData(start, end);

            // Assert.
            return movementData.IsVertical;
        }
    }
}