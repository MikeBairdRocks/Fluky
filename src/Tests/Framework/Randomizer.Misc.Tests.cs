using System.Linq;
using Fluky.Core.Extensions;
using Fluky.Core.Models;
using Fluky.Framework;
using NUnit.Framework;
using Shouldly;

namespace Fluky.Tests.Framework
{
  [TestFixture]
  public class MiscTests
  {
    private IRandomizer _sut;

    [SetUp]
    public void SetUp()
    {
      _sut = new Fluky.Framework.Randomizer();
    }

    [Test]
    public void Dice_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.Dice();

      // Assert
      Assert.IsNotNull(result);
      result.ShouldBeInRange(1, 100);
    }

    [TestCase(DiceType.D4, 1, 4)]
    [TestCase(DiceType.D6, 1, 6)]
    [TestCase(DiceType.D8, 1, 8)]
    [TestCase(DiceType.D10, 1, 10)]
    [TestCase(DiceType.D12, 1, 12)]
    [TestCase(DiceType.D20, 1, 20)]
    [TestCase(DiceType.D30, 1, 30)]
    [TestCase(DiceType.D100, 1, 100)]
    public void Dice_ShouldBeInRange_OfSpecifiedType(DiceType type, int expectedMin, int expectedMax)
    {
      // Arrange

      // Act
      var result = _sut.Dice(type);

      // Assert
      Assert.IsNotNull(result);
      result.ShouldBeInRange(expectedMin, expectedMax);
    }

    [Test]
    public void Hash_IsLowerCase()
    {
      // Arrange

      // Act
      var result = _sut.Hash();

      // Assert
      Assert.IsNotNull(result);
      var isLower = result.IsLower();
      isLower.ShouldBe(true);
    }

    [Test]
    public void Hash_IsUpperCase()
    {
      // Arrange

      // Act
      var result = _sut.Hash(casing: CasingType.Upper);

      // Assert
      Assert.IsNotNull(result);
      var isUpper = result.IsUpper();
      isUpper.ShouldBe(true);
    }

    [Test]
    public void Hash_IsBothUpperAndLower()
    {
      // Arrange

      // Act
      var result = _sut.Hash(casing: CasingType.Both);

      // Assert
      Assert.IsNotNull(result);
      result.ContainsUpper().ShouldBe(true);
      result.ContainsLower().ShouldBe(true);
    }

    [TestCase(10)]
    [TestCase(20)]
    [TestCase(30)]
    [TestCase(40)]
    [TestCase(50)]
    [TestCase(60)]
    [TestCase(70)]
    [TestCase(80)]
    [TestCase(90)]
    [TestCase(100)]
    public void Hash_IsCorrectLength(int length)
    {
      // Arrange

      // Act
      var result = _sut.Hash(length: length);

      // Assert
      Assert.IsNotNull(result);
      result.Length.ShouldBe(length);
    }

    [TestCase("1d20", 1)]
    [TestCase("2d20", 2)]
    [TestCase("3d20", 3)]
    [TestCase("4d20", 4)]
    [TestCase("5d20", 5)]
    [TestCase("6d20", 6)]
    public void Rpg_ShouldReturnCorrectCommaDelimted(string dice, int expectedCount)
    {
      // Arrange

      // Act
      var result = _sut.Rpg(dice);

      // Assert
      Assert.IsNotNullOrEmpty(result);
      var split = result.Split(',');
      split.Count().ShouldBe(expectedCount);
    }

    [Test]
    public void Rpg_ShouldReturnSum()
    {
      // Arrange

      // Act
      var result = _sut.Rpg("3d20", true);

      // Assert
      Assert.IsNotNullOrEmpty(result);
      result.ShouldNotContain(',');
      var split = result.Split(',');
      split.Count().ShouldBe(1);
    }
  }
}
