using System.Linq;
using Fluky.Framework;
using NUnit.Framework;
using Shouldly;

namespace Fluky.Tests.Framework
{
  [TestFixture]
  public class TextTests
  {
    private IRandomizer _sut;

    [SetUp]
    public void SetUp()
    {
      _sut = new Fluky.Framework.Randomizer();
    }

    [Test]
    public void Paragraph_ShouldReturnSentences()
    {
      // Arrange

      // Act
      var result = _sut.Paragraph();

      // Assert
      result.Split('.').Count().ShouldBeGreaterThanOrEqualTo(4);
    }
  }
}
