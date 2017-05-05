using System.Linq;
using Fluky.Types;
using Shouldly;
using Xunit;

namespace Fluky.Tests
{
  public class FinanceTests
  {
    private readonly IRandomizer _sut;

    public FinanceTests()
    {
      _sut = new Randomizer();
    }

    [Fact]
    public void CreditCardNumber_ShouldReturnValidNumber()
    {
      // Arrange
      
      // Act
      var result = _sut.CreditCardNumber();

      // Assert
      Assert.NotNull(result);
      result.Split('-').Count().ShouldBeInRange(1, 3);
    }

    [InlineData(CreditCardType.AmericanExpress)]
    [InlineData(CreditCardType.Bankcard)]
    [InlineData(CreditCardType.ChinaUnionPay)]
    [InlineData(CreditCardType.ChinaUnionPay)]
    [InlineData(CreditCardType.DinersClubCarteBlanche)]
    [InlineData(CreditCardType.DinersClubInternational)]
    [InlineData(CreditCardType.DinersClubUnitedStatesCanada)]
    [InlineData(CreditCardType.DinersClubenRoute)]
    [InlineData(CreditCardType.Discover)]
    [InlineData(CreditCardType.InstaPayment)]
    public void CreditCard_ShouldReturnValidNumber(CreditCardType type)
    {
      // Arrange

      // Act
      var result = _sut.CreditCard(type);

      // Assert
      Assert.NotNull(result);
      result.Type.ShouldBe(type);
    }

    [Fact]
    public void Currency()
    {
      // Arrange

      // Act
      var result = _sut.Currency();

      // Assert
      Assert.NotNull(result);
    }
  }
}
