using System.Linq;
using Shouldly;
using Xunit;

namespace Fluky.Tests
{
  public class TextTests
  {
    private readonly IRandomizer _sut;

    public TextTests()
    {
      _sut = new Randomizer();
    }

    [Fact]
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
