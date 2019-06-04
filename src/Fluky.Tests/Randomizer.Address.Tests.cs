using System;
using System.Linq;
using System.Text.RegularExpressions;
using Fluky.DataSets;
using Shouldly;
using Xunit;
using Fluky.Types;
using Fluky.Extensions;

namespace Fluky.Tests
{
  public class RandomizerAddressTests
  {
    private readonly Randomizer _sut;

    public RandomizerAddressTests()
    {
      _sut = new Randomizer();
    }

    [Fact]
    public void Address_ShouldHaveThreeSections_AndStreetIsShort()
    {
      // Arrange

      // Act
      var result = _sut.Address();

      // Assert
      Assert.NotNull(result);
      var sections = result.Split(' ');
      Assert.Equal(3, sections.Count());
      sections[2].Length.ShouldBeLessThanOrEqualTo(4);
    }

    [Fact]
    public void Address_ShouldHaveThreeSections_AndStreetIsLong()
    {
      // Arrange

      // Act
      var result = _sut.Address(false);

      // Assert
      Assert.NotNull(result);
      var sections = result.Split(' ');
      Assert.Equal(3, sections.Count());
      sections[2].Length.ShouldBeGreaterThanOrEqualTo(3);
    }

    [Fact]
    public void AreaCode_ShouldHaveParens_AndFiveCharacters()
    {
      // Arrange

      // Act
      var result = _sut.Areacode();

      // Assert
      Assert.NotNull(result);
      Assert.True(result.Contains("("));
      Assert.Equal(5, result.Length);
    }

    [Fact]
    public void AreaCode_ShouldNotHaveParens_AndThreeCharacters()
    {
      // Arrange

      // Act
      var result = _sut.Areacode(false);

      // Assert
      Assert.NotNull(result);
      Assert.True(!result.Contains("("));
      Assert.Equal(3, result.Length);
    }

    [Fact]
    public void City()
    {
      // Arrange

      // Act
      var result = _sut.City();

      // Assert
      Assert.NotNull(result);
    }

    [Fact]
    public void Longitude_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.Longitude();

      // Assert
      result.ShouldBeInRange(-180, 180);
    }

    [Fact]
    public void Longitude_ShouldThrowException_ForMinGreaterThanMax()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Longitude(10, 0));
    }

    [Fact]
    public void Longitude_ShouldThrowException_ForFixLessThanZero()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Longitude(fix: -1));
    }

    [Fact]
    public void Latitude_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.Latitude();

      // Assert
      result.ShouldBeInRange(-90, 90);
    }


    [Fact]
    public void Latitude_ShouldThrowException_ForMinGreaterThanMax()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Latitude(10, 0));
    }

    [Fact]
    public void Latitude_ShouldThrowException_ForFixLessThanZero()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Latitude(fix: -1));
    }

    [Fact]
    public void GeoJson_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.GeoJson();

      // Assert
      Assert.NotNull(result);
      var splitValues = result.Replace(",", "").Split(' ');
      Assert.Equal(3, splitValues.Count());
      var latitude = float.Parse(splitValues[0]);
      var longitude = float.Parse(splitValues[1]);
      var altitude = float.Parse(splitValues[2]);

      latitude.ShouldBeInRange(Constants.MinLatitude, Constants.MaxLatitude);
      longitude.ShouldBeInRange(Constants.MinLongitude, Constants.MaxLongitude);
      altitude.ShouldBeInRange(Constants.MinAltitude, Constants.MaxAltitude);
    }

    [Fact]
    public void Coordinates_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.Coordinates();

      // Assert
      Assert.NotNull(result);
      var splitValues = result.Replace(",", "").Split(' ');
      Assert.Equal(2, splitValues.Count());
      var latitude = float.Parse(splitValues[0]);
      var longitude = float.Parse(splitValues[1]);
      latitude.ShouldBeInRange(Constants.MinLatitude, Constants.MaxLatitude);
      longitude.ShouldBeInRange(Constants.MinLongitude, Constants.MaxLongitude);
    }

    [Fact]
    public void Depth_ShouldBeInRange()
    {
      // Arrange

      // Act
      var depth = _sut.Depth();

      // Assert
      Assert.NotNull(depth);
      depth.ShouldBeInRange(Constants.MinDepth, Constants.MaxDepth);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    public void Depth_ShouldBeInFixedPosition(int expectedFixed)
    {
      // Arrange

      // Act
      var depth = _sut.Depth(fix: expectedFixed);

      // Assert
      Assert.NotNull(depth);
      var value = depth.ToString("");
      var length = value.GetDecimalLength();
      length.ShouldBe(expectedFixed);
    }

    [Fact]
    public void Phone_ShouldBeFormattedCorrectly()
    {
      // Arrange

      // Act
      var result = _sut.Phone();

      // Assert
      Assert.NotNull(result);
      var valid = Regex.IsMatch(result, @"\(\d{3}\) \d{3}-\d{4}");
      Assert.True(valid);
    }

    [Fact]
    public void Phone_ShouldBeCorrectLength()
    {
      // Arrange

      // Act
      var result = _sut.Phone(false);

      // Assert
      Assert.NotNull(result);
      result.Length.ShouldBe(10);
    }

    [Fact]
    public void Postal_ShouldBeCorrectLength_AndCanadianFormat()
    {
      // Arrange

      // Act
      var result = _sut.Postal();

      // Assert
      Assert.NotNull(result);
      result.Length.ShouldBe(7);
      var split = result.Split(' ');
      split.Count().ShouldBe(2);
    }

    [Fact]
    public void Zip_ShouldBeCorrectLength()
    {
      // Arrange

      // Act
      var result = _sut.Zip();

      // Assert
      Assert.NotNull(result);
      result.Length.ShouldBe(5);
    }

    [Fact]
    public void Zip_ShouldBeCorrectLength_PlusFour()
    {
      // Arrange

      // Act
      var result = _sut.Zip(true);

      // Assert
      Assert.NotNull(result);
      result.Length.ShouldBe(10);
      var split = result.Split('-');
      split.Count().ShouldBe(2);
    }

    [Fact]
    public void Province_Returns()
    {
      // Arrange

      // Act
      var result = _sut.Province();

      // Assert
      Assert.NotNull(result);
    }

    [Fact]
    public void Province_ReturnsString()
    {
      // Arrange

      // Act
      var result = _sut.Province(true);

      // Assert
      Assert.NotNull(result);
      result.Length.ShouldBeGreaterThan(3);
    }

    [Fact]
    public void Province_ReturnsShortString()
    {
      // Arrange

      // Act
      var result = _sut.Province(false);

      // Assert
      Assert.NotNull(result);
      result.Length.ShouldBeLessThanOrEqualTo(3);
    }

    [Fact]
    public void RadioAndTv_ShouldStartWithKorW()
    {
      // Arrange
      var elementPredicate = new[] { 'K', 'W' };

      // Act
      var radio = _sut.Radio();
      var tv = _sut.Tv();

      // Assert
      Assert.NotNull(radio);
      Assert.NotNull(tv);
      radio[0].ShouldBeOneOf(elementPredicate);
      tv[0].ShouldBeOneOf(elementPredicate);
    }

    [Fact]
    public void RadioAndTv_ShouldStartWithK()
    {
      // Arrange
      var elementPredicate = new[] { 'K' };

      // Act
      var radio = _sut.Radio(SideType.West);
      var tv = _sut.Radio(SideType.West);

      // Assert
      Assert.NotNull(radio);
      Assert.NotNull(tv);
      radio[0].ShouldBeOneOf(elementPredicate);
      tv[0].ShouldBeOneOf(elementPredicate);
    }

    [Fact]
    public void RadioAndTv_ShouldStartWithW()
    {
      // Arrange
      var elementPredicate = new[] { 'W' };

      // Act
      var radio = _sut.Radio(SideType.East);
      var tv = _sut.Radio(SideType.East);

      // Assert
      Assert.NotNull(radio);
      Assert.NotNull(tv);
      radio[0].ShouldBeOneOf(elementPredicate);
      tv[0].ShouldBeOneOf(elementPredicate);
    }

    [Fact]
    public void State_ShouldReturnFullName()
    {
      // Arrange

      // Act
      var state = _sut.State(true, true, true);

      // Assert
      Assert.NotNull(state);
      state.Length.ShouldBeGreaterThan(3);
    }

    [Fact]
    public void State_ShouldReturnShortName()
    {
      // Arrange

      // Act
      var state = _sut.State(false, true, true);

      // Assert
      Assert.NotNull(state);
      state.Length.ShouldBeLessThanOrEqualTo(3);
    }

    [Fact]
    public void Street_ShouldReturnCorrectShortLength()
    {
      // Act

      // Arrange
      var result = _sut.Street();

      // Assert
      Assert.NotNull(result);
      var split = result.Split(' ');
      split.Count().ShouldBe(2);
      split[1].Length.ShouldBeLessThanOrEqualTo(4);
    }

    [Fact]
    public void Street_ShouldReturnCorrectLongLength()
    {
      // Act

      // Arrange
      var result = _sut.Street(false);

      // Assert
      Assert.NotNull(result);
      var split = result.Split(' ');
      split.Count().ShouldBe(2);
      split[1].Length.ShouldBeGreaterThanOrEqualTo(3);
    }
  }
}
