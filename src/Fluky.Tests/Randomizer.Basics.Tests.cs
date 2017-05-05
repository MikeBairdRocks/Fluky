using System;
using System.Globalization;
using Fluky.Types;
using Shouldly;
using Xunit;
using Fluky.Extensions;

namespace Fluky.Tests
{
  public class BasicsTests
  {
    private readonly IRandomizer _sut;

    public BasicsTests()
    {
      _sut = new Randomizer();
    }

    [Fact]
    public void Bool_ShouldBeTrue()
    {
      // Arrange

      // Act
      var result = _sut.Bool(100);

      // Assert
      result.ShouldBe(true);
    }

    [Fact]
    public void Bool_ShouldBeFalse()
    {
      // Arrange

      // Act
      var result = _sut.Bool(0);

      // Assert
      result.ShouldBe(false);
    }

    [Fact]
    public void Character_ReturnsAlphaNumeric()
    {
      // Arrange

      // Act
      var result = _sut.Character();

      // Assert
      Assert.NotNull(result.ToString());
      result.ShouldNotBeOneOf("$%^&*()#@!".ToCharArray());
    }

    [Fact]
    public void Character_ReturnsSymbols()
    {
      // Arrange

      // Act
      var result = _sut.Character(true, false, string.Empty);

      // Assert
      Assert.NotNull(result.ToString());
      result.ShouldBeOneOf(Constants.CharSymbols.ToCharArray());
    }

    [Fact]
    public void Character_ReturnsAlpha()
    {
      // Arrange

      // Act
      var result = _sut.Character(false, true, string.Empty);

      // Assert
      Assert.NotNull(result.ToString());
      result.ShouldBeOneOf((Constants.CharsLower + Constants.CharsUpper).ToCharArray());
    }

    [Fact]
    public void Character_ReturnsAlphaWithUpper()
    {
      // Arrange

      // Act
      var result = _sut.Character(false, true, string.Empty, CasingType.Upper);

      // Assert
      Assert.NotNull(result.ToString());
      result.ShouldBeOneOf((Constants.CharsUpper).ToCharArray());
    }

    [Fact]
    public void Character_ReturnsAlphaWithLower()
    {
      // Arrange

      // Act
      var result = _sut.Character(false, true, string.Empty, CasingType.Lower);

      // Assert
      Assert.NotNull(result.ToString());
      result.ShouldBeOneOf((Constants.CharsLower).ToCharArray());
    }

    [Fact]
    public void Character_ReturnsAny()
    {
      // Arrange

      // Act
      var result = _sut.Character(false, false, string.Empty);

      // Assert
      Assert.NotNull(result.ToString());
      result.ShouldBeOneOf((Constants.CharsLower + Constants.CharsUpper + Constants.Numbers + Constants.CharSymbols).ToCharArray());
    }

    [Fact]
    public void Decimal_ShouldBeUnique()
    {
      // Arrange
      const int min = 1;
      const int max = 50;
      const int fix = 6;

      // Act
      var result1 = _sut.Decimal(min, max, fix);
      var result2 = _sut.Decimal(min, max, fix);

      // Assert
      Assert.NotNull(result1);
      Assert.NotNull(result2);
      result1.ShouldNotBe(result2);
    }

    [Fact]
    public void Decimal_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.Decimal();

      // Assert
      Assert.NotNull(result);
      result.ShouldBeInRange(int.MinValue, int.MaxValue);
    }

    [Fact]
    public void Decimal_ShouldBeInSpecifiedRange()
    {
      // Arrange
      const int min = 1;
      const int max = 1;

      // Act
      var result = _sut.Decimal(min, max);

      // Assert
      Assert.NotNull(result);
      result.ShouldBeInRange(min, max);
    }

    [Fact]
    public void Decimal_ShouldHaveMinPrecision()
    {
      // Arrange
      const int min = 1;
      const int max = 10;
      const int fix = 6;

      // Act
      var result = _sut.Decimal(min, max, fix);

      // Assert
      Assert.NotNull(result);
      result.ToString(CultureInfo.InvariantCulture).GetDecimalLength().ShouldBe(fix);
   }

    [Fact]
    public void DecimalString_ShouldBeUnique()
    {
      // Arrange

      // Act
      var result1 = _sut.DecimalString();
      var result2 = _sut.DecimalString();

      // Assert
      Assert.NotNull(result1);
      Assert.NotNull(result2);
      result1.ShouldNotBe(result2);
    }

    [Fact]
    public void DecimalString_ShouldHaveCorrectPrecision()
    {
      // Arrange
      const int min = 1;
      const int max = 10;
      const int fix = 6;

      // Act
      var result = _sut.DecimalString(min, max, fix);

      // Assert
      Assert.NotNull(result);
      var split = result.Split('.');
      split[1].Length.ShouldBe(fix);
    }

    [Fact]
    public void Integer_ShouldReturnCorrectRange()
    {
      // Arrange
      const int min = 10;
      const int max = 50;

      // Act
      var result = _sut.Integer(min, max);

      // Assert
      Assert.NotNull(result);
      result.ShouldBeInRange(min, max);
    }

    [Fact]
    public void Natural_ShouldReturnCorrectRange()
    {
      // Arrange
      const int min = 1;
      const int max = 50;

      // Act
      var result = _sut.Natural(min, max);

      // Assert
      Assert.NotNull(result);
      result.ShouldBeInRange(min, max);
    }

    [Fact]
    public void Natural_ShouldThrowIfLessThanZero()
    {
      // Arrange
      const int min = -1;
      const int max = 50;

      // Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Natural(min, max));
    }

    [Fact]
    public void Natural_ShouldThrowIfMinIsGreaterThanMax()
    {
      // Arrange
      const int min = 50;
      const int max = 1;

      // Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Natural(min, max));
    }

    [Fact]
    public void String_ReturnsValue()
    {
      // Arrange

      // Act
      var result = _sut.String();

      // Assert
      Assert.NotNull(result);
    }

    [Fact]
    public void String_ReturnsCorrectLength()
    {
      // Arrange
      const int length = 10;

      // Act
      var result = _sut.String(length);

      // Assert
      Assert.NotNull(result);
      result.Length.ShouldBe(length);
    }

    [Fact]
    public void String_ShouldThrowIfLengthIsZero()
    {
      // Arrange
      const int length = 0;

      // Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.String(length));
    }

    [Fact]
    public void String_ShouldThrowIfLengthIsLessThanZero()
    {
      // Arrange
      const int length = -12;

      // Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.String(length));
    }
  }
}
