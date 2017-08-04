using Fluky.Types;
using Shouldly;
using Xunit;
using Fluky.Extensions;

namespace Fluky.Tests
{
  public class MiscTests
  {
    private readonly IRandomizer _sut;

    public MiscTests()
    {
      _sut = new Randomizer();
    }

    [Fact]
    public void Dice_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.Dice();

      // Assert
      Assert.NotNull(result);
      result.ShouldBeInRange(1, 100);
    }

    [Theory]
    [InlineData(DiceType.D4, 1, 4)]
    [InlineData(DiceType.D6, 1, 6)]
    [InlineData(DiceType.D8, 1, 8)]
    [InlineData(DiceType.D10, 1, 10)]
    [InlineData(DiceType.D12, 1, 12)]
    [InlineData(DiceType.D20, 1, 20)]
    [InlineData(DiceType.D30, 1, 30)]
    [InlineData(DiceType.D100, 1, 100)]
    public void Dice_ShouldBeInRange_OfSpecifiedType(DiceType type, int expectedMin, int expectedMax)
    {
      // Arrange

      // Act
      var result = _sut.Dice(type);

      // Assert
      Assert.NotNull(result);
      result.ShouldBeInRange(expectedMin, expectedMax);
    }

    [Fact]
    public void Hash_IsLowerCase()
    {
      // Arrange

      // Act
      var result = _sut.Hash();

      // Assert
      Assert.NotNull(result);
      var isLower = result.IsLower();
      isLower.ShouldBe(true);
    }

    [Fact]
    public void Hash_IsUpperCase()
    {
      // Arrange

      // Act
      var result = _sut.Hash(casing: CasingType.Upper);

      // Assert
      Assert.NotNull(result);
      var isUpper = result.IsUpper();
      isUpper.ShouldBe(true);
    }

    [Fact]
    public void Hash_IsBothUpperAndLower()
    {
      // Arrange

      // Act
      var result = _sut.Hash(casing: CasingType.Both);

      // Assert
      Assert.NotNull(result);
      result.ContainsUpper().ShouldBe(true);
      result.ContainsLower().ShouldBe(true);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(30)]
    [InlineData(40)]
    [InlineData(50)]
    [InlineData(60)]
    [InlineData(70)]
    [InlineData(80)]
    [InlineData(90)]
    [InlineData(100)]
    public void Hash_IsCorrectLength(int length)
    {
      // Arrange

      // Act
      var result = _sut.Hash(length: length);

      // Assert
      Assert.NotNull(result);
      result.Length.ShouldBe(length);
    }

    [Theory]
    [InlineData("1d20", 1)]
    [InlineData("2d20", 2)]
    [InlineData("3d20", 3)]
    [InlineData("4d20", 4)]
    [InlineData("5d20", 5)]
    [InlineData("6d20", 6)]
    public void Rpg_ShouldReturnCorrectCommaDelimted(string dice, int expectedCount)
    {
      // Arrange

      // Act
      var result = _sut.Rpg(dice);

      // Assert
      Assert.NotNull(result);
      var split = result.Split(',');
      split.Length.ShouldBe(expectedCount);
    }

    [Fact]
    public void Rpg_ShouldReturnSum()
    {
      // Arrange

      // Act
      var result = _sut.Rpg("3d20", true);

      // Assert
      Assert.NotNull(result);
      result.ShouldNotContain(',');
      var split = result.Split(',');
      split.Length.ShouldBe(1);
    }
  }
}
