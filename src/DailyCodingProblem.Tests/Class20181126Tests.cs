using DailyCodingProblem.Problem20181126;
using NUnit.Framework;

namespace DailyCodingProblem.Tests
{
    [TestFixture]
    public class Class20181126Tests
    {
        [TestCase(new int[] {10, 15, 3, 7}, 17, true)]
        [TestCase(new int[] { 10, 15, 3, 7 }, 18, true)]
        [TestCase(new int[] { 10, 15, 3, 7 }, 1, false)]
        [TestCase(new int[] { 10, -15, 3 }, -5, true)]
        public void DoesTwoNumbersAddUpTests(int[] array, int number, bool expected)
        {
            // Arrange

            // Act
            bool actual = Class20181126.DoesTwoNumbersAddUp(array, number);

            // Assert
            Assert.That(actual, Is.True);
        }
    }
}
