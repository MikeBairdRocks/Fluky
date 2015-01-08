using System.Linq;
using Fluky.Core.Models;
using Fluky.Framework;
using NUnit.Framework;
using Shouldly;
using Randomizer = Fluky.Framework.Randomizer;

namespace Fluky.Tests.Framework
{
  [TestFixture]
  public class FinanceTests
  {
    private IRandomizer _sut;

    [SetUp]
    public void SetUp()
    {
      _sut = new Randomizer();
    }

    [Test]
    public void CreditCardNumber_ShouldReturnValidNumber()
    {
      // Arrange
      
      // Act
      var result = _sut.CreditCardNumber();

      // Assert
      Assert.IsNotNullOrEmpty(result);
      result.Split('-').Count().ShouldBeInRange(1, 3);
    }

    [TestCase(CreditCardType.AmericanExpress)]
    [TestCase(CreditCardType.Bankcard)]
    [TestCase(CreditCardType.ChinaUnionPay)]
    [TestCase(CreditCardType.ChinaUnionPay)]
    [TestCase(CreditCardType.DinersClubCarteBlanche)]
    [TestCase(CreditCardType.DinersClubInternational)]
    [TestCase(CreditCardType.DinersClubUnitedStatesCanada)]
    [TestCase(CreditCardType.DinersClubenRoute)]
    [TestCase(CreditCardType.Discover)]
    [TestCase(CreditCardType.InstaPayment)]
    public void CreditCard_ShouldReturnValidNumber(CreditCardType type)
    {
      // Arrange

      // Act
      var result = _sut.CreditCard(type);

      // Assert
      Assert.IsNotNull(result);
      result.Type.ShouldBe(type);
    }

    [Test]
    public void Currency()
    {
      // Arrange

      // Act
      var result = _sut.Currency();

      // Assert
      Assert.IsNotNull(result);
    }
  }
}
