using Fluky.Extensions;
using Shouldly;
using Xunit;

namespace Fluky.Tests.Extensions
{
  public class NumberExtensionsTests
  {
    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    [InlineData(1, 3)]
    [InlineData(1, 10)]
    [InlineData(1, 11)]
    [InlineData(1, 12)]
    [InlineData(100123.7234, 1)]
    [InlineData(100123.773456, 2)]
    [InlineData(100123.123456, 3)]
    [InlineData(100123.123456, 10)]
    [InlineData(100123.123456, 11)]
    [InlineData(100123.123456, 12)]
    public void ToFixed_Double_SetCorrectPositions(double value, int fix)
    {
      // Arrange
    
      // Act
      var result = value.ToFixed(fix);
    
      // Assert
      var length = result.GetDecimalLength();
      length.ShouldBe(fix);
    }
    
    [Theory]
    [InlineData(1, 1)]
    [InlineData(-1, 2)]
    [InlineData(1, 3)]
    [InlineData(-1, 10)]
    [InlineData(1, 11)]
    [InlineData(1, 12)]
    [InlineData(100123, 1)]
    [InlineData(int.MaxValue, 2)]
    [InlineData(int.MinValue, 3)]
    public void ToFixed_Integer_SetCorrectPositions(int value, int fix)
    {
      // Arrange
    
      // Act
      var result = value.ToFixed(fix);
    
      // Assert
      var length = result.GetDecimalLength();
      length.ShouldBe(fix);
    }
    
    [Theory]
    [InlineData(1.0, 1)]
    [InlineData(1.000, 2)]
    [InlineData(1.000000, 3)]
    [InlineData(1.0, 10)]
    [InlineData(1, 11)]
    [InlineData(1, 12)]
    [InlineData(100123.7234, 1)]
    [InlineData(100123.773456, 2)]
    [InlineData(100123.123456, 3)]
    [InlineData(100123.123456, 10)]
    [InlineData(100123.123456, 11)]
    [InlineData(100123.123456, 12)]
    public void ToFixed_Decimal_SetCorrectPositions(decimal value, int fix)
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