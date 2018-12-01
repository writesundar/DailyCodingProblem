using NUnit.Framework;

namespace DailyCodingProblem.Tests
{
    [TestFixture]
    public class ProblemTests
    {
        [TestCase(new[] {10, 15, 3, 7}, 17, true)]
        [TestCase(new[] { 10, 15, 3, 7 }, 18, true)]
        [TestCase(new[] { 10, 15, 3, 7 }, 1, false)]
        [TestCase(new[] { 10, -15, 3 }, -5, true)]
        public void DoesTwoNumbersAddUpTests(int[] array, int number, bool expected)
        {
            // Arrange

            // Act
            bool actual = Problems.DoesTwoNumbersAddUp(array, number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 120, 60, 40, 30, 24 })]
        public void TransformUsingDivisionTests(int[] input, int[] expected)
        {
            // Arrange

            // Act
            int[] actual = Problems.TransformUsingDivision(input);

            // Assert
            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
