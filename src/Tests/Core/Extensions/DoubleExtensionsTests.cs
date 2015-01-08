using Fluky.Core.Extensions;
using NUnit.Framework;
using Shouldly;

namespace Fluky.Tests.Core.Extensions
{
  [TestFixture]
  public class DoubleExtensionsTests
  {
    [TestCase(1, 1)]
    [TestCase(1, 2)]
    [TestCase(1, 3)]
    [TestCase(1, 10)]
    [TestCase(1, 11)]
    [TestCase(1, 12)]
    [TestCase(100123.7234, 1)]
    [TestCase(100123.773456, 2)]
    [TestCase(100123.123456, 3)]
    [TestCase(100123.123456, 10)]
    [TestCase(100123.123456, 11)]
    [TestCase(100123.123456, 12)]
    public void ToFixed_SetCorrectPositions(double value, int fix)
    {
      // Arrange

      // Act
      var result = value.ToFixed(fix);

      // Assert
      var length = result.GetDecimalLength();
      length.ShouldBe(fix);
    }
  }
}
