using Fluky.Extensions;
using Shouldly;
using Xunit;

namespace Fluky.Tests.Extensions
{
  public class DoubleExtensionsTests
  {
    [Theory]
    [InlineData(100123.7234, 100123.7234f)]
    [InlineData(200.555, 200.555f)]
    [InlineData(800.123456, 800.123456f)]
    [InlineData(-800.123456, -800.123456f)]
    [InlineData(900.987654, 900.987654f)]
    [InlineData(double.MaxValue + 1, float.MaxValue + 1)]
    [InlineData(double.MinValue - 1, float.MinValue - 1)]
    public void ToFloat_ShouldConvertCorrectly(double value, float fix)
    {
      // Arrange

      // Act
      var result = value.ToFloat();

      // Assert
      result.ShouldBe(fix);
    }
  }
}
