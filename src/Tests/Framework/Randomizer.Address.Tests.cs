using System;
using System.Linq;
using System.Text.RegularExpressions;
using Fluky.Core;
using Fluky.Core.Extensions;
using Fluky.Core.Models;
using Fluky.Framework;
using NUnit.Framework;
using Shouldly;
using Randomizer = Fluky.Framework.Randomizer;

namespace Fluky.Tests.Framework
{
  [TestFixture]
  public class RandomizerAddressTests
  {
    private IRandomizer _sut;

    [SetUp]
    public void SetUp()
    {
      _sut = new Randomizer();
    }

    [Test]
    public void Address_ShouldHaveThreeSections_AndStreetIsShort()
    {
      // Arrange

      // Act
      var result = _sut.Address();

      // Assert
      Assert.IsNotNullOrEmpty(result);
      var sections = result.Split(' ');
      Assert.AreEqual(3, sections.Count());
      Assert.LessOrEqual(sections[2].Length, 4);
    }

    [Test]
    public void Address_ShouldHaveThreeSections_AndStreetIsLong()
    {
      // Arrange

      // Act
      var result = _sut.Address(false);

      // Assert
      Assert.IsNotNullOrEmpty(result);
      var sections = result.Split(' ');
      Assert.AreEqual(3, sections.Count());
      Assert.GreaterOrEqual(sections[2].Length, 3);
    }

    [Test]
    public void AreaCode_ShouldHaveParens_AndFiveCharacters()
    {
      // Arrange

      // Act
      var result = _sut.Areacode();

      // Assert
      Assert.IsNotNullOrEmpty(result);
      Assert.IsTrue(result.Contains("("));
      Assert.AreEqual(5, result.Length);
    }

    [Test]
    public void AreaCode_ShouldNotHaveParens_AndThreeCharacters()
    {
      // Arrange

      // Act
      var result = _sut.Areacode(false);

      // Assert
      Assert.IsNotNullOrEmpty(result);
      Assert.IsTrue(!result.Contains("("));
      Assert.AreEqual(3, result.Length);
    }

    [Test]
    public void City()
    {
      // Arrange

      // Act
      var result = _sut.City();

      // Assert
      Assert.IsNotNullOrEmpty(result);
    }

    [Test]
    public void Longitude_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.Longitude();

      // Assert
      result.ShouldBeInRange(-180, 180);
    }

    [Test]
    public void Longitude_ShouldThrowException_ForMinGreaterThanMax()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Longitude(10, 0));
    }

    [Test]
    public void Longitude_ShouldThrowException_ForFixLessThanZero()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Longitude(fix: -1));
    }

    [Test]
    public void Latitude_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.Latitude();

      // Assert
      result.ShouldBeInRange(-90, 90);
    }


    [Test]
    public void Latitude_ShouldThrowException_ForMinGreaterThanMax()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Latitude(10, 0));
    }

    [Test]
    public void Latitude_ShouldThrowException_ForFixLessThanZero()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Latitude(fix: -1));
    }

    [Test]
    public void GeoJson_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.GeoJson();

      // Assert
      Assert.IsNotNullOrEmpty(result);
      var splitValues = result.Replace(",", "").Split(' ');
      Assert.AreEqual(3, splitValues.Count());
      var latitude = float.Parse(splitValues[0]);
      var longitude = float.Parse(splitValues[1]);
      var altitude = float.Parse(splitValues[2]);

      latitude.ShouldBeInRange(Constants.MinLatitude, Constants.MaxLatitude);
      longitude.ShouldBeInRange(Constants.MinLongitude, Constants.MaxLongitude);
      altitude.ShouldBeInRange(Constants.MinAltitude, Constants.MaxAltitude);
    }

    [Test]
    public void Coordinates_ShouldBeInRange()
    {
      // Arrange

      // Act
      var result = _sut.Coordinates();

      // Assert
      Assert.IsNotNullOrEmpty(result);
      var splitValues = result.Replace(",", "").Split(' ');
      Assert.AreEqual(2, splitValues.Count());
      var latitude = float.Parse(splitValues[0]);
      var longitude = float.Parse(splitValues[1]);
      latitude.ShouldBeInRange(Constants.MinLatitude, Constants.MaxLatitude);
      longitude.ShouldBeInRange(Constants.MinLongitude, Constants.MaxLongitude);
    }

    [Test]
    public void Depth_ShouldBeInRange()
    {
      // Arrange

      // Act
      var depth = _sut.Depth();

      // Assert
      Assert.IsNotNull(depth);
      depth.ShouldBeInRange(Constants.MinDepth, Constants.MaxDepth);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    public void Depth_ShouldBeInFixedPosition(int expectedFixed)
    {
      // Arrange

      // Act
      var depth = _sut.Depth(fix: expectedFixed);

      // Assert
      Assert.IsNotNull(depth);
      var value = depth.ToString("");
      var length = value.GetDecimalLength();
      length.ShouldBe(expectedFixed);
    }

    [Test]
    public void Phone_ShouldBeFormattedCorrectly()
    {
      // Arrange

      // Act
      var result = _sut.Phone();

      // Assert
      Assert.IsNotNullOrEmpty(result);
      var valid = Regex.IsMatch(result, @"\(\d{3}\) \d{3}-\d{4}");
      Assert.IsTrue(valid);
    }

    [Test]
    public void Phone_ShouldBeCorrectLength()
    {
      // Arrange

      // Act
      var result = _sut.Phone(false);

      // Assert
      Assert.IsNotNullOrEmpty(result);
      result.Length.ShouldBe(10);
    }

    [Test]
    public void Postal_ShouldBeCorrectLength_AndCanadianFormat()
    {
      // Arrange

      // Act
      var result = _sut.Postal();

      // Assert
      Assert.IsNotNullOrEmpty(result);
      result.Length.ShouldBe(7);
      var split = result.Split(' ');
      split.Count().ShouldBe(2);
    }

    [Test]
    public void Zip_ShouldBeCorrectLength()
    {
      // Arrange

      // Act
      var result = _sut.Zip();

      // Assert
      Assert.IsNotNullOrEmpty(result);
      result.Length.ShouldBe(5);
    }

    [Test]
    public void Zip_ShouldBeCorrectLength_PlusFour()
    {
      // Arrange

      // Act
      var result = _sut.Zip(true);

      // Assert
      Assert.IsNotNullOrEmpty(result);
      result.Length.ShouldBe(10);
      var split = result.Split('-');
      split.Count().ShouldBe(2);
    }

    [Test]
    public void Province_Returns()
    {
      // Arrange

      // Act
      var result = _sut.Province();

      // Assert
      Assert.IsNotNull(result);
    }

    [Test]
    public void Province_ReturnsString()
    {
      // Arrange

      // Act
      var result = _sut.Province(true);

      // Assert
      Assert.IsNotNullOrEmpty(result);
      result.Length.ShouldBeGreaterThan(3);
    }

    [Test]
    public void Province_ReturnsShortString()
    {
      // Arrange

      // Act
      var result = _sut.Province(false);

      // Assert
      Assert.IsNotNullOrEmpty(result);
      result.Length.ShouldBeLessThanOrEqualTo(3);
    }

    [Test]
    public void RadioAndTv_ShouldStartWithKorW()
    {
      // Arrange
      var elementPredicate = new[] { 'K', 'W' };

      // Act
      var radio = _sut.Radio();
      var tv = _sut.Tv();

      // Assert
      Assert.IsNotNullOrEmpty(radio);
      Assert.IsNotNullOrEmpty(tv);
      radio[0].ShouldBeOneOf(elementPredicate);
      tv[0].ShouldBeOneOf(elementPredicate);
    }

    [Test]
    public void RadioAndTv_ShouldStartWithK()
    {
      // Arrange
      var elementPredicate = new[] { 'K' };

      // Act
      var radio = _sut.Radio(SideType.West);
      var tv = _sut.Radio(SideType.West);

      // Assert
      Assert.IsNotNullOrEmpty(radio);
      Assert.IsNotNullOrEmpty(tv);
      radio[0].ShouldBeOneOf(elementPredicate);
      tv[0].ShouldBeOneOf(elementPredicate);
    }

    [Test]
    public void RadioAndTv_ShouldStartWithW()
    {
      // Arrange
      var elementPredicate = new[] { 'W' };

      // Act
      var radio = _sut.Radio(SideType.East);
      var tv = _sut.Radio(SideType.East);

      // Assert
      Assert.IsNotNullOrEmpty(radio);
      Assert.IsNotNullOrEmpty(tv);
      radio[0].ShouldBeOneOf(elementPredicate);
      tv[0].ShouldBeOneOf(elementPredicate);
    }

    [Test]
    public void State_ShouldReturnFullName()
    {
      // Arrange

      // Act
      var state = _sut.State(true, true, true);

      // Assert
      Assert.IsNotNullOrEmpty(state);
      state.Length.ShouldBeGreaterThan(3);
    }

    [Test]
    public void State_ShouldReturnShortName()
    {
      // Arrange

      // Act
      var state = _sut.State(false, true, true);

      // Assert
      Assert.IsNotNullOrEmpty(state);
      state.Length.ShouldBeLessThanOrEqualTo(3);
    }

    [Test]
    public void Street_ShouldReturnCorrectShortLength()
    {
      // Act

      // Arrange
      var result = _sut.Street();

      // Assert
      Assert.IsNotNullOrEmpty(result);
      var split = result.Split(' ');
      split.Count().ShouldBe(2);
      split[1].Length.ShouldBeLessThanOrEqualTo(4);
    }

    [Test]
    public void Street_ShouldReturnCorrectLongLength()
    {
      // Act

      // Arrange
      var result = _sut.Street(false);

      // Assert
      Assert.IsNotNullOrEmpty(result);
      var split = result.Split(' ');
      split.Count().ShouldBe(2);
      split[1].Length.ShouldBeGreaterThanOrEqualTo(3);
    }
  }
}
