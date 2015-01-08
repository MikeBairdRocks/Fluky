using System;
using System.Globalization;
using Fluky.Core;
using Fluky.Core.Extensions;
using Fluky.Core.Models;
using Fluky.Framework;
using NUnit.Framework;
using Shouldly;

namespace Fluky.Tests.Framework
{
  [TestFixture]
  public class BasicsTests
  {
    private IRandomizer _sut;

    [SetUp]
    public void SetUp()
    {
      _sut = new Fluky.Framework.Randomizer();
    }

    [Test]
    public void Bool_ShouldBeTrue()
    {
      // Arrange

      // Act
      var result = _sut.Bool(100);

      // Assert
      result.ShouldBe(true);
    }

    [Test]
    public void Bool_ShouldBeFalse()
    {
      // Arrange

      // Act
      var result = _sut.Bool(0);

      // Assert
      result.ShouldBe(false);
    }

    [Test]
    public void Character_ReturnsAlphaNumeric()
    {
      // Arrange

      // Act
      var result = _sut.Character();

      // Assert
      Assert.IsNotNullOrEmpty(result.ToString(CultureInfo.InvariantCulture));
      result.ShouldNotBeOneOf("$%^&*()#@!".ToCharArray());
    }

    [Test]
    public void Character_ReturnsSymbols()
    {
      // Arrange

      // Act
      var result = _sut.Character(true, false, string.Empty);

      // Assert
      Assert.IsNotNullOrEmpty(result.ToString(CultureInfo.InvariantCulture));
      result.ShouldBeOneOf(Constants.CharSymbols.ToCharArray());
    }

    [Test]
    public void Character_ReturnsAlpha()
    {
      // Arrange

      // Act
      var result = _sut.Character(false, true, string.Empty);

      // Assert
      Assert.IsNotNullOrEmpty(result.ToString(CultureInfo.InvariantCulture));
      result.ShouldBeOneOf((Constants.CharsLower + Constants.CharsUpper).ToCharArray());
    }

    [Test]
    public void Character_ReturnsAlphaWithUpper()
    {
      // Arrange

      // Act
      var result = _sut.Character(false, true, string.Empty, CasingType.Upper);

      // Assert
      Assert.IsNotNullOrEmpty(result.ToString(CultureInfo.InvariantCulture));
      result.ShouldBeOneOf((Constants.CharsUpper).ToCharArray());
    }

    [Test]
    public void Character_ReturnsAlphaWithLower()
    {
      // Arrange

      // Act
      var result = _sut.Character(false, true, string.Empty, CasingType.Lower);

      // Assert
      Assert.IsNotNullOrEmpty(result.ToString(CultureInfo.InvariantCulture));
      result.ShouldBeOneOf((Constants.CharsLower).ToCharArray());
    }

    [Test]
    public void Character_ReturnsAny()
    {
      // Arrange

      // Act
      var result = _sut.Character(false, false, string.Empty);

      // Assert
      Assert.IsNotNullOrEmpty(result.ToString(CultureInfo.InvariantCulture));
      result.ShouldBeOneOf((Constants.CharsLower + Constants.CharsUpper + Constants.Numbers + Constants.CharSymbols).ToCharArray());
    }

    [Test]
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
      Assert.IsNotNull(result1);
      Assert.IsNotNull(result2);
      result1.ShouldNotBe(result2);
    }

    [Test]
    public void Decimal_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.Decimal();

      // Assert
      Assert.IsNotNull(result);
      result.ShouldBeInRange(int.MinValue, int.MaxValue);
    }

    [Test]
    public void Decimal_ShouldBeInSpecifiedRange()
    {
      // Arrange
      const int min = 1;
      const int max = 1;

      // Act
      var result = _sut.Decimal(min, max);

      // Assert
      Assert.IsNotNull(result);
      result.ShouldBeInRange(min, max);
    }

    [Test]
    public void Decimal_ShouldHaveMinPrecision()
    {
      // Arrange
      const int min = 1;
      const int max = 10;
      const int fix = 6;

      // Act
      var result = _sut.Decimal(min, max, fix);

      // Assert
      Assert.IsNotNull(result);
      result.ToString(CultureInfo.InvariantCulture).GetDecimalLength().ShouldBe(fix);
   }

    [Test]
    public void DecimalString_ShouldBeUnique()
    {
      // Arrange

      // Act
      var result1 = _sut.DecimalString();
      var result2 = _sut.DecimalString();

      // Assert
      Assert.IsNotNullOrEmpty(result1);
      Assert.IsNotNullOrEmpty(result2);
      result1.ShouldNotBe(result2);
    }

    [Test]
    public void DecimalString_ShouldHaveCorrectPrecision()
    {
      // Arrange
      const int min = 1;
      const int max = 10;
      const int fix = 6;

      // Act
      var result = _sut.DecimalString(min, max, fix);

      // Assert
      Assert.IsNotNull(result);
      var split = result.Split('.');
      split[1].Length.ShouldBe(fix);
    }

    [Test]
    public void Integer_ShouldReturnCorrectRange()
    {
      // Arrange
      const int min = 10;
      const int max = 50;

      // Act
      var result = _sut.Integer(min, max);

      // Assert
      Assert.IsNotNull(result);
      result.ShouldBeInRange(min, max);
    }

    [Test]
    public void Natural_ShouldReturnCorrectRange()
    {
      // Arrange
      const int min = 1;
      const int max = 50;

      // Act
      var result = _sut.Natural(min, max);

      // Assert
      Assert.IsNotNull(result);
      result.ShouldBeInRange(min, max);
    }

    [Test]
    public void Natural_ShouldThrowIfLessThanZero()
    {
      // Arrange
      const int min = -1;
      const int max = 50;

      // Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Natural(min, max));
    }

    [Test]
    public void Natural_ShouldThrowIfMinIsGreaterThanMax()
    {
      // Arrange
      const int min = 50;
      const int max = 1;

      // Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Natural(min, max));
    }

    [Test]
    public void String_ReturnsValue()
    {
      // Arrange

      // Act
      var result = _sut.String();

      // Assert
      Assert.IsNotNullOrEmpty(result);
    }

    [Test]
    public void String_ReturnsCorrectLength()
    {
      // Arrange
      const int length = 10;

      // Act
      var result = _sut.String(length);

      // Assert
      Assert.IsNotNullOrEmpty(result);
      result.Length.ShouldBe(length);
    }

    [Test]
    public void String_ShouldThrowIfLengthIsZero()
    {
      // Arrange
      const int length = 0;

      // Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.String(length));
    }

    [Test]
    public void String_ShouldThrowIfLengthIsLessThanZero()
    {
      // Arrange
      const int length = -12;

      // Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.String(length));
    }
  }
}
