using DailyCodingProblem.Problem20181127;
using NUnit.Framework;

namespace DailyCodingProblem.Tests
{
    public class Class20181127Tests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new[] { 120, 60, 40, 30, 24 })]
        public void TransformUsingDivisionTests(int[] input, int[] expected)
        {
            // Arrange

            // Act
            int[] actual = Class20181127.TransformUsingDivision(input);

            // Assert
            CollectionAssert.AreEqual(actual, expected);
        }
    }
}