using System;
using System.Collections.Generic;
using Fluky.Types;

namespace Fluky
{
  public interface IRandomizer
  {
    //string AmPm();
    //string UnixTime();

    //string Color();
    //string Domain();
    //string Email();
    //string HashTag();
    //string Ip();
    //string Ipv6();
    //string Tld();
    //string TwitterHandle();
    //string FacebookId();
    //string GoogleAnalytics();
    /// <summary>
    /// Return a random boolean value (true or false).
    /// </summary>
    /// <param name="likelyHood">The default likelyHood of success (returning true) is 50%. Can optionally specify the likelihood in percent.</param>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="likelyHood"/> parameter is less than the zero or greater than 100.</exception>
    /// <example>
    ///   <code language="cs">var yesNo = _random.Bool(likelyHood: 25);</code>
    /// </example>
    /// <returns>A bool based on likelyHood.</returns>
    bool Bool(int likelyHood = 50);

    /// <summary>
    /// Return a random character.
    /// </summary>
    /// <param name="symbols">specify use of symbols (!@#$%^&*()).</param>
    /// <param name="alpha">specify alpha for only an alphanumeric character.</param>
    /// <param name="pool">specify a pool and the character will be generated with characters only from that pool.</param>
    /// <param name="casing">specify casing</param>
    /// <example>
    ///   <code language="cs">var character = _random.Character(false, true);</code>
    /// </example>
    /// <returns>A char from the char pool.</returns>
    char Character(bool symbols = false, bool alpha = true, string pool = Constants.DefaultStringPool, CasingType casing = CasingType.Both);

    /// <summary>
    /// Return a random decimal.
    /// </summary>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="fix"/> parameter is less than the zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a decimal between -10 and 10. (ex. 8.36542)
    ///     var number = _random.Decimal(-10, 10, 5);
    ///   </code>
    /// </example>
    /// <returns>A decimal within a range.</returns>
    decimal Decimal(int min = int.MinValue, int max = int.MaxValue, int fix = 4);

    /// <summary>
    /// Return a random decimal using a seed.
    /// </summary>
    /// <param name="seed">Seed Random internal.</param>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="fix"/> parameter is less than the zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a decimal between -10 and 10. (ex. 8.36542)
    ///     var number = _random.Decimal(6546513, -10, 10, 5);
    ///   </code>
    /// </example>
    /// <returns>A decimal within a range.</returns>
    decimal DecimalWithSeed(int seed, int min = int.MinValue, int max = int.MaxValue, int fix = 4);

    /// <summary>
    /// Return a random decimal as a string.
    /// </summary>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="fix"/> parameter is less than the zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a decimal between -10 and 10. (ex. 8.36542)
    ///     var number = _random.DecimalString(-10, 10, 5);
    ///   </code>
    /// </example>
    /// <returns>A string representation of a decimal.</returns>
    string DecimalString(int min = int.MinValue, int max = int.MaxValue, int fix = 4);

    /// <summary>
    /// Return a random decimal as a string.
    /// </summary>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="fix"/> parameter is less than the zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a decimal between -10.1f and 10.1f. (ex. 8.36542)
    ///     var number = _random.DecimalString(-10.1f, 10.1f, 5);
    ///   </code>
    /// </example>
    /// <returns>A string representation of a decimal.</returns>
    string DecimalFloatString(float min = float.MinValue, float max = float.MaxValue, int fix = 4);

    /// <summary>
    /// Return a random decimal as a string.
    /// </summary>
    /// <param name="seed">Seed Random internal.</param>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <exception cref="ArgumentOutOfRangeException">This is thrown if <paramref name="fix"/> parameter is less than the zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a decimal between -10 and 10. (ex. 8.36542)
    ///     var number = _random.DecimalString(-10, 10, 5);
    ///   </code>
    /// </example>
    /// <returns>A string representation of a decimal.</returns>
    string DecimalStringWithSeed(int seed, int min = int.MinValue, int max = int.MaxValue, int fix = 4);

    /// <summary>
    /// Return a random integer.
    /// </summary>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return an int between -10 and 10. (ex. 8)
    ///     var number = _random.Integer(-10, 10);
    ///   </code>
    /// </example>
    /// <returns>An int between the min and max range.</returns>
    int Integer(int min = int.MinValue, int max = int.MaxValue);

    /// <summary>
    /// Return a random float.
    /// </summary>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="fix"/> parameter is less than the zero.</exception>
    /// <returns>A float between the min and max range.</returns>
    float Float(int min = int.MinValue, int max = int.MaxValue, int fix = 4);

    float Float(float min = float.MinValue, float max = float.MaxValue, int fix = 4);

    /// <summary>
    /// Return a natural number.
    /// </summary>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="min"/> parameter is less than zero.</exception>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return an int between 0 and 10. (ex. 2)
    ///     var number = _random.Natural(0, 10);
    ///   </code>
    /// </example>
    /// <returns></returns>
    int Natural(int min = 0, int max = int.MaxValue);

    /// <summary>
    /// Return a random string.
    /// </summary>
    /// <param name="length">The total length of the string to be returned.</param>
    /// <param name="pool">Pool of characters that the generator can use.</param>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="length"/> parameter is less than or equal to zero.</exception>
    /// <example>
    ///   <code language="cs">
    ///     // this will return a string with a length of 8. (ex. "ponjirew")
    ///     var number = _random.String(8);
    ///   </code>
    /// </example>
    /// <returns>A string with a set length.</returns>
    string String(int? length = null, string pool = Constants.DefaultStringPool);

    float DistributionNormal(float mean, float standardDeviation);
    float DistributionStandardNormal();
    float DistributionRangeSlope(float min, float max, float skew, DistributionDirection direction);
    float DistributionSloped(float skew, DistributionDirection direction);
    float DistributionRangeLinear(float min, float max, float slope);
    float DistributionRandomLinear(float slope);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="twentyfour"></param>
    /// <returns></returns>
    int Hour(bool twentyfour = false);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    int Minute();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    int Second();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    int Millisecond();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    int Timestamp();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="minYear"></param>
    /// <returns></returns>
    DateTime Date(int? minYear = null);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="american"></param>
    /// <returns></returns>
    string Date(bool american);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Month Month();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    string MonthName();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    int Year(int min, int? max = null);

    T Choose<T>(IList<T> list) where T : IWeighted;

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
    string Address(bool shortStreetSuffix = true);

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
    string Areacode(bool parens = true);

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
    string City();

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
    string Coordinates(int fix = 5);

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
    string GeoJson(int fix = 2);

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
    decimal Altitude(int min = 0, int max = Constants.MaxAltitude, int fix = 5);

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
    decimal Depth(int min = Constants.MinDepth, int max = 0, int fix = 5);

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
    decimal Latitude(int min = Constants.MinLatitude, int max = Constants.MaxLatitude, int fix = 5);

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
    decimal Longitude(int min = Constants.MinLongitude, int max = Constants.MaxLongitude, int fix = 5);

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
    string Phone(bool formatted = true);

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
    string Postal();

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
    string Zip(bool plusFour = false);

    /// <summary>
    /// Return a random province.
    /// </summary>
    /// <returns>Full Province Object</returns>
    Province Province();

    /// <summary>
    /// Return a random province.
    /// </summary>
    /// <returns>full or short Province string</returns>
    string Province(bool full);

    /// <summary>
    /// Generate a random radio call sign. Optionally specify a side of the Mississippi River to limit stations to that side.
    /// </summary>
    /// <param name="sideType"></param>
    /// <returns></returns>
    string Radio(SideType? sideType = null);

    /// <summary>
    /// Generate a TV station call sign. This is an alias for radio() since they both follow the same rules. Optionally specify a side of the Mississippi River to limit stations to that side.
    /// </summary>
    /// <param name="sideType"></param>
    /// <returns></returns>
    string Tv(SideType? sideType = null);

    /// <summary>
    /// <para>Return a random state.</para>
    /// <para>Optionally add U.S. Territories (‘American Samoa’, ‘Federated States of Micronesia’, ‘Guam’, ‘Marshall Islands’, ‘Northern Mariana Islands’, ‘Puerto Rico’, ‘Virgin Islands, U.S.’) to the mix of randomly selected items</para>
    /// <para>Optionally add Armed Forces to the list as well.</para>
    /// </summary>
    /// <param name="full"></param>
    /// <param name="territories"></param>
    /// <param name="armedForces"></param>
    /// <returns></returns>
    string State(bool full, bool territories, bool armedForces);

    /// <summary>
    /// <para>Return a random state.</para>
    /// <para>Optionally add U.S. Territories (‘American Samoa’, ‘Federated States of Micronesia’, ‘Guam’, ‘Marshall Islands’, ‘Northern Mariana Islands’, ‘Puerto Rico’, ‘Virgin Islands, U.S.’) to the mix of randomly selected items</para>
    /// <para>Optionally add Armed Forces to the list as well.</para>
    /// </summary>
    /// <param name="territories"></param>
    /// <param name="armedForces"></param>
    /// <returns>State Object</returns>
    State State(bool territories = false, bool armedForces = false);

    /// <summary>
    /// Generate a random street.
    /// </summary>
    /// <param name="shortSuffix"></param>
    /// <returns></returns>
    string Street(bool shortSuffix = true);

    /// <summary>
    /// Generate a random street.
    /// </summary>
    /// <returns></returns>
    StreetSuffix StreetSuffix();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    int Age(AgeType type = AgeType.Any);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    DateTime Birthday(AgeType type = AgeType.Any);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="genderType"></param>
    /// <returns></returns>
    string FirstName(GenderType genderType = GenderType.Any);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    GenderType Gender();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    string LastName();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="genderType"></param>
    /// <param name="prefix"></param>
    /// <param name="middle"></param>
    /// <param name="middleInitial"></param>
    /// <returns></returns>
    string Name(GenderType genderType = GenderType.Any, bool prefix = false, bool middle = false, bool middleInitial = false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="genderType"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    Honorific Honorific(GenderType genderType = GenderType.Any, HonorificType type = HonorificType.Any);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ssnFour"></param>
    /// <param name="dashes"></param>
    /// <param name="masked"></param>
    /// <returns></returns>
    string Ssn(bool ssnFour = false, bool dashes = false, bool masked = false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sentences"></param>
    /// <returns></returns>
    string Paragraph(int? sentences = null);

    /// <summary>
    /// Generate a random credit card number. This card number will pass the Luhn algorithm so it looks like a legit card.
    /// </summary>
    /// <param name="ccType"></param>
    /// <returns></returns>
    string CreditCardNumber(CreditCardType? ccType = null);

    /// <summary>
    /// Generate a random credit card number. This card number will pass the Luhn algorithm so it looks like a legit card.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    CreditCard CreditCard(CreditCardType? type = null);

    /// <summary>
    /// Generate a random currency.
    /// </summary>
    /// <returns></returns>
    Currency Currency();

    /// <summary>
    /// Return a random dollar amount.
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    string Dollar(int min = 0, int max = 10000);

    /// <summary>
    /// Generate a random credit card expiration date.
    /// </summary>
    /// <param name="future"></param>
    /// <returns></returns>
    string Expiration(bool future = true);

    /// <summary>
    /// Generate a random credit card expiration month.
    /// </summary>
    /// <param name="future"></param>
    /// <returns></returns>
    int ExpirationMonth(bool future = true);

    /// <summary>
    /// Generate a random credit card expiration year.
    /// </summary>
    /// <param name="future"></param>
    /// <returns></returns>
    int ExpirationYear(bool future = true);

    /// <summary>
    /// Return a value equal to the roll of a die.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    int Dice(DiceType? type = null);

    /// <summary>
    /// Return a random hex hash.
    /// </summary>
    /// <param name="length"></param>
    /// <param name="casing"></param>
    /// <returns></returns>
    string Hash(int length = 40, CasingType casing = CasingType.Lower);

    /// <summary>
    /// Return a normally-distributed random variate.
    /// </summary>
    /// <param name="mean"></param>
    /// <param name="deviation"></param>
    /// <returns></returns>
    double Normal(int mean = 0, int deviation = 1);

    /// <summary>
    /// Given an input looking like #d#, where the first # is the number of dice to roll and the second # is the max of each die, returns an array of dice values.
    /// </summary>
    /// <param name="die"></param>
    /// <param name="sum"></param>
    /// <returns></returns>
    string Rpg(string die, bool sum = false);

    /// <summary>
    /// Return a random color.
    /// </summary>
    /// <param name="format">Type of ColorFormat to return</param>
    /// <param name="casing"></param>
    /// <param name="grayscale"></param>
    /// <returns></returns>
    string Color(ColorFormat format, CasingType casing = CasingType.Lower, bool grayscale = true);


    string AmPm();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="minYear"></param>
    /// <returns></returns>
    string UnixTime(int? minYear = null);
  }
}