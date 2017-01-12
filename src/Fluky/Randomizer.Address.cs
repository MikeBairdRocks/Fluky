using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Fluky.Extensions;
using Fluky.Types;

namespace Fluky
{
  public partial class Randomizer
  {
    /// <summary>
    /// Generate a random street address.
    /// </summary>
    /// <param name="shortStreetSuffix">Use short street suffix or long.</param>
    /// <example>
    ///   <code language="cs">
    ///     // this will return an address. (ex. "842 Pongjera Ln")
    ///     var address = _random.Address(true);
    /// 
    ///     // this will return an address. (ex. "842 Pongjera Lane")
    ///     var address = _random.Address(false);
    ///   </code>
    /// </example>
    /// <returns>Street Address</returns>
    public string Address(bool shortStreetSuffix = true)
    {
      return string.Format("{0} {1}", Natural(5, 2000), Street(shortStreetSuffix));
    }

    /// <summary>
    /// Generate a random area code.
    /// </summary>
    /// <param name="parens">use parenthese</param>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a string with parens. (ex. "(518)")
    ///     var areaCode = _random.Areacode();
    /// 
    ///     // this will return a string without parens. (ex. "518")
    ///     var areaCode = _random.Areacode(false);
    ///   </code>
    /// </example>
    /// <returns>Area Code</returns>
    public string Areacode(bool parens = true)
    {
      // Don't want area codes to start with 1, or have a 9 as the second digit
      var areacode = string.Format("{0}{1}{2}", Natural(2, 9), Natural(0, 8), Natural(0, 9));
      return parens ? string.Format("({0})", areacode) : areacode;
    }

    /// <summary>
    /// Generate a random city name.
    /// </summary>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a string. (ex. "Goruy")
    ///     var city = _random.City();
    ///   </code>
    /// </example>
    /// <returns>A random city</returns>
    public string City()
    {
      return Capitalize(Word(syllables: 3));
    }

    /// <summary>
    /// Generate random coordinates, which are latitude and longitude, comma separated.
    /// </summary>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="fix"/> parameter is less than or equal to zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a string with latitude and longitude. (ex. "46.51234, 21.98276")
    ///     var coordinates = _random.Coordinates();
    ///   </code>
    /// </example>
    /// <returns>By default includes 5 fixed digits after decimal, can specify otherwise.</returns>
    public string Coordinates(int fix = 5)
    {
      fix.ThrowIfLessThan(0);

      return string.Format("{0}, {1}", Latitude(fix:fix), Longitude(fix:fix));
    }

    /// <summary>
    /// Generate random coordinates, which are latitude, longitude and altitude comma separated.
    /// </summary>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="fix"/> parameter is less than or equal to zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a string with latitude, longitude and altitude. (ex. "46.51234, 21.98276, 65.21345")
    ///     var geo = _random.GeoJson(5);
    ///   </code>
    /// </example>
    /// <returns>By default includes 2 fixed digits after decimal, can specify otherwise.</returns>
    public string GeoJson(int fix = 2)
    {
      fix.ThrowIfLessThan(0);

      return Latitude(fix: fix) + ", " + Longitude(fix: fix) + ", " + Altitude(fix: fix);
    }

    /// <summary>
    /// Generate a random altitude.
    /// </summary>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="min"/> parameter is less than zero.</exception>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="fix"/> parameter is less than or equal to zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a decimal with altitude. (ex. 56.51234)
    ///     var altitude = _random.Altitude(50, 100, 5);
    ///   </code>
    /// </example>
    /// <returns>By default includes 5 fixed digits after decimal, can specify otherwise.</returns>
    public decimal Altitude(int min = 0, int max = Constants.MaxAltitude, int fix = 5)
    {
      min.ThrowIfOutOfRange(0, Constants.MaxAltitude);
      min.ThrowIfGreaterThan(max);
      max.ThrowIfOutOfRange(0, Constants.MaxAltitude);
      fix.ThrowIfLessThan(0);

      return Decimal(min, max, fix);
    }

    /// <summary>
    /// Generate a random depth.
    /// </summary>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="max"/> parameter is greter than zero.</exception>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="fix"/> parameter is less than or equal to zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a decimal with depth. (ex. -5656.51234)
    ///     var depth = _random.Depth(-10000, 0, 5);
    ///   </code>
    /// </example>
    /// <returns>By default includes 5 fixed digits after decimal, can specify otherwise.</returns>
    public decimal Depth(int min = Constants.MinDepth, int max = 0, int fix = 5)
    {
      min.ThrowIfOutOfRange(Constants.MinDepth, 0);
      min.ThrowIfGreaterThan(max);
      max.ThrowIfOutOfRange(Constants.MinDepth, 0);
      fix.ThrowIfLessThan(0);

      return Decimal(min, max, fix);
    }

    /// <summary>
    /// Generate a random latitude.
    /// </summary>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="fix"/> parameter is less than or equal to zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a decimal with latitude. (ex. -56.51234)
    ///     var latitude = _random.Latitude(-90, 90, 5);
    ///   </code>
    /// </example>
    /// <returns>By default includes 5 fixed digits after decimal, can specify otherwise.</returns>
    public decimal Latitude(int min = Constants.MinLatitude, int max = Constants.MaxLatitude, int fix = 5)
    {
      min.ThrowIfOutOfRange(Constants.MinLatitude, Constants.MaxLatitude);
      min.ThrowIfGreaterThan(max);
      max.ThrowIfOutOfRange(Constants.MinLatitude, Constants.MaxLatitude);
      fix.ThrowIfLessThan(0);

      return Decimal(min, max, fix);
    }

    /// <summary>
    /// Generate a random longitude.
    /// </summary>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="fix"/> parameter is less than or equal to zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a decimal with longitude. (ex. -156.51234)
    ///     var longitude = _random.Longitude(-180, 180, 5);
    ///   </code>
    /// </example>
    /// <returns>By default includes 5 fixed digits after decimal, can specify otherwise.</returns>
    public decimal Longitude(int min = Constants.MinLongitude, int max = Constants.MaxLongitude, int fix = 5)
    {
      min.ThrowIfOutOfRange(Constants.MinLongitude, Constants.MaxLongitude);
      min.ThrowIfGreaterThan(max);
      max.ThrowIfOutOfRange(Constants.MinLongitude, Constants.MaxLongitude);
      fix.ThrowIfLessThan(0);

      return Decimal(min, max, fix);
    }

    /// <summary>
    /// Generate a random phone.
    /// </summary>
    /// <param name="formatted">True if you want the phone have dashes and parens for area code.</param>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a string of a phone. (ex. "(123) 405-6321")
    ///     var phone = _random.Phone();
    ///   </code>
    /// </example>
    /// <returns>Conforms to <a href="http://en.wikipedia.org/wiki/North_American_Numbering_Plan">NANP</a></returns>
    public string Phone(bool formatted = true)
    {
      var areacode = Areacode(formatted);
      var exchange = string.Format("{0}{1}{2}", Natural(0, 9), Natural(2, 9), Natural(0, 9));
      var subscriber = Natural(1000, 9999); // this could be random [0-9]{4}

      return formatted ? string.Format("{0} {1}-{2}", areacode, exchange, subscriber) : string.Format("{0}{1}{2}", areacode, exchange, subscriber);
    }

    /// <summary>
    /// Return a Canadian Postal code. Returned postal code is valid with respect to the Postal District (first character) and format only.
    /// </summary>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a string of a postal code. (ex. "XVT GCB")
    ///     var postal = _random.Postal();
    ///   </code>
    /// </example>
    /// <returns>Canadian Postal code</returns>
    public string Postal()
    {
      // Postal District
      var pd = Character(pool: "XVTSRPNKLMHJGECBA");
      // Forward Sortation Area (FSA)
      var fsa = string.Format("{0}{1}{2}", pd, Character(alpha: true, casing: CasingType.Upper), Natural(max: 9));
      // Local Delivery Unut (LDU)
      var ldu = string.Format("{0}{1}{2}", Natural(max: 9), Character(alpha: true, casing: CasingType.Upper), Natural(max: 9));

      return string.Format("{0} {1}", fsa, ldu);
    }

    /// <summary>
    /// Generate a random (U.S.) zip code.
    /// </summary>
    /// <param name="plusFour">Include zip plus-four code.</param>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a string of a zip code. (ex. "12345-5432")
    ///     var zip = _random.Zip(true);
    ///   </code>
    /// </example>
    /// <returns>Can optionally specify that it ought to return a Zip+4</returns>
    public string Zip(bool plusFour = false)
    {
      var zip = Natural(10000, 99999).ToString(CultureInfo.InvariantCulture);

      if (plusFour)
        zip = string.Concat(zip, "-", Natural(1000, 9999).ToString(CultureInfo.InvariantCulture));

      return zip;
    }

    /// <summary>
    /// Return a random province.
    /// </summary>
    /// <returns>Full Province Object</returns>
    public Province Province()
    {
      var list = _data.Provinces.ToList();
      return Pick(list);
    }

    /// <summary>
    /// Return a random province.
    /// </summary>
    /// <returns>full or short Province string</returns>
    public string Province(bool full)
    {
      return full ? Province().Name : Province().Abbreviation;
    }

    /// <summary>
    /// Generate a random radio call sign. Optionally specify a side of the Mississippi River to limit stations to that side.
    /// </summary>
    /// <param name="sideType"></param>
    /// <returns></returns>
    public string Radio(SideType? sideType = null)
    {
      // Initial Letter (Typically Designated by SideType of Mississippi River)
      string fl;
      switch (sideType)
      {
        case SideType.East:
          fl = "W";
          break;
        case SideType.West:
          fl = "K";
          break;
        default:
          fl = Character(pool: "KW").ToString();
          break;
      }

      return $"{fl}{Character(alpha: true, casing: CasingType.Upper)}{Character(alpha: true, casing: CasingType.Upper)}{Character(alpha: true, casing: CasingType.Upper)}";
    }

    /// <summary>
    /// Generate a TV station call sign. This is an alias for radio() since they both follow the same rules. Optionally specify a side of the Mississippi River to limit stations to that side.
    /// </summary>
    /// <param name="sideType"></param>
    /// <returns></returns>
    public string Tv(SideType? sideType = null)
    {
      return Radio(sideType);
    }

    /// <summary>
    /// <para>Return a random state.</para>
    /// <para>Optionally add U.S. Territories (‘American Samoa’, ‘Federated States of Micronesia’, ‘Guam’, ‘Marshall Islands’, ‘Northern Mariana Islands’, ‘Puerto Rico’, ‘Virgin Islands, U.S.’) to the mix of randomly selected items</para>
    /// <para>Optionally add Armed Forces to the list as well.</para>
    /// </summary>
    /// <param name="full"></param>
    /// <param name="territories"></param>
    /// <param name="armedForces"></param>
    /// <returns></returns>
    public string State(bool full, bool territories, bool armedForces)
    {
      return full ? State(territories, armedForces).Name : State(territories, armedForces).Abbreviation;
    }

    /// <summary>
    /// <para>Return a random state.</para>
    /// <para>Optionally add U.S. Territories (‘American Samoa’, ‘Federated States of Micronesia’, ‘Guam’, ‘Marshall Islands’, ‘Northern Mariana Islands’, ‘Puerto Rico’, ‘Virgin Islands, U.S.’) to the mix of randomly selected items</para>
    /// <para>Optionally add Armed Forces to the list as well.</para>
    /// </summary>
    /// <param name="territories"></param>
    /// <param name="armedForces"></param>
    /// <returns>State Object</returns>
    public State State(bool territories = false, bool armedForces = false)
    {
      var states = States(territories, armedForces).ToList();
      return Pick(states);
    }

    /// <summary>
    /// Generate a random street.
    /// </summary>
    /// <param name="shortSuffix"></param>
    /// <returns></returns>
    public string Street(bool shortSuffix = true)
    {
      var street = Word(syllables: 2);
      street = Capitalize(street);
      street += " ";
      street += shortSuffix ? StreetSuffix().Abbreviation : StreetSuffix().Name;

      return street;
    }

    /// <summary>
    /// Generate a random street.
    /// </summary>
    /// <returns></returns>
    public StreetSuffix StreetSuffix()
    {
      var list = _data.StreetSuffixes.ToList();
      return Pick(list);
    }

    private IEnumerable<State> States(bool territories = false, bool armedForces = true)
    {
      var states = _data.States.ToList();
      if (territories)
        states.AddRange(_data.Territories);

      if (armedForces)
        states.AddRange(_data.ArmedForces);

      return states;
    }
  }
}
