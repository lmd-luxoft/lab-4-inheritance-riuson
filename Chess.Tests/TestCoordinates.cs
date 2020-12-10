using NUnit.Framework;

namespace Chess.Tests
{
    [TestFixture]
    internal class TestCoordinates
    {
        [TestCase("A1", 'A', '1')]
        [TestCase("B5", 'B', '5')]
        [TestCase("H8", 'H', '8')]
        [TestCase("a7", 'A', '7')]
        [TestCase("e3", 'E', '3')]
        [TestCase("b5", 'B', '5')]
        public void CanParse(string value, char expectedX, char expectedY)
        {
            // Act
            var success = Coordinates.TryParse(value, out var coordinates);

            // Assert.
            Assert.That(success, Is.True);
            Assert.That(coordinates.IsValid, Is.True);
            Assert.That(coordinates.X, Is.EqualTo(expectedX));
            Assert.That(coordinates.Y, Is.EqualTo(expectedY));
        }

        [TestCase(" 5")]
        [TestCase("A 2")]
        [TestCase("AA1")]
        [TestCase("6E")]
        [TestCase(null)]
        [TestCase("")]
        public void CanDetectInvalidFormat(string value)
        {
            // Act
            var success = Coordinates.TryParse(value, out var result);

            // Assert.
            Assert.That(success, Is.False);
            Assert.That(result.IsValid, Is.False);
        }

        [TestCase("A0")]
        [TestCase("A9")]
        [TestCase("B9")]
        [TestCase("I0")]
        public void CanDetectOutOfArea(string value)
        {
            // Act
            var success = Coordinates.TryParse(value, out var _);

            // Assert.
            Assert.That(success, Is.False);
        }

        [TestCase("A1", "A1", ExpectedResult = true)]
        [TestCase("B7", "B7", ExpectedResult = true)]
        [TestCase("H8", "H8", ExpectedResult = true)]
        [TestCase("A1", "B1", ExpectedResult = false)]
        [TestCase("G7", "A1", ExpectedResult = false)]
        public bool CanDetectEqualityValid(string input1, string input2)
        {
            // Arrange.
            var success1 = Coordinates.TryParse(input1, out var coordinates1);
            var success2 = Coordinates.TryParse(input2, out var coordinates2);

            // Act && Assert.
            Assert.That(success1, Is.True);
            Assert.That(success2, Is.True);
            return coordinates1 == coordinates2;
        }

        [TestCase("A0", "A1", ExpectedResult = false)]
        [TestCase("B9", "B9", ExpectedResult = false)]
        [TestCase("  ", null, ExpectedResult = false)]
        [TestCase("bb", "B1", ExpectedResult = false)]
        [TestCase("__", "A1", ExpectedResult = false)]
        public bool CanDetectNonEqualityInvalid(string input1, string input2)
        {
            // Arrange.
            var success1 = Coordinates.TryParse(input1, out var coordinates1);
            var success2 = Coordinates.TryParse(input2, out var coordinates2);

            // Act && Assert.
            Assert.That(success1 && success2, Is.False);
            return coordinates1 == coordinates2;
        }

        [Test]
        public void CanDetectEmpty()
        {
            // Arrange.
            var emptyCoordinates = Coordinates.Empty;
            var expected = true;

            // Act.
            var actual = emptyCoordinates.IsEmpty;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanDetectNotEmpty()
        {
            // Arrange.
            Coordinates.TryParse("A1", out var notEmptyCoordinates);
            var expected = false;

            // Act.
            var actual = notEmptyCoordinates.IsEmpty;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}