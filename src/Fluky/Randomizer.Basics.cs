using System;
using Fluky.Extensions;
using Fluky.Types;

namespace Fluky
{
  public partial class Randomizer
  {
    /// <summary>
    /// Return a random boolean value (true or false).
    /// </summary>
    /// <param name="likelyHood">The default likelyHood of success (returning true) is 50%. Can optionally specify the likelihood in percent.</param>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="likelyHood"/> parameter is less than the zero or greater than 100.</exception>
    /// <example>
    ///   <code language="cs">var yesNo = _random.Bool(likelyHood: 25);</code>
    /// </example>
    /// <returns>A bool based on likelyHood.</returns>
    public bool Bool(int likelyHood = 50)
    {
      likelyHood.ThrowIfOutOfRange(0, 100);

      var internalRandom = InternalRandom();
      var nextDouble = internalRandom.NextDouble();

      return nextDouble * 100 < likelyHood;
    }

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
    public char Character(bool symbols = false, bool alpha = true, string pool = Constants.DefaultStringPool, CasingType casing = CasingType.Both)
    {
      string letters;
      string charPool;

      switch (casing)
      {
        case CasingType.Lower:
          letters = Constants.CharsLower;
          break;
        case CasingType.Upper:
          letters = Constants.CharsUpper;
          break;
        default:
          letters = Constants.CharsLower + Constants.CharsUpper;
          break;
      }

      if (!string.IsNullOrEmpty(pool))
      {
        charPool = pool;
      }
      else if (alpha)
      {
        charPool = letters;
      }
      else if (symbols)
      {
        charPool = Constants.CharSymbols;
      }
      else
      {
        charPool = string.Format("{0}{1}{2}", letters, Constants.Numbers, Constants.CharSymbols);
      }

      var natural = Natural(max: charPool.Length - 1);
      return charPool[natural];
    }

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
    public decimal Decimal(int min = int.MinValue, int max = int.MaxValue, int fix = 4)
    {
      min.ThrowIfGreaterThan(max);
      fix.ThrowIfLessThan(0);

      return decimal.Parse(DecimalString(min, max, fix));
    }

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
    public decimal DecimalWithSeed(int seed, int min = int.MinValue, int max = int.MaxValue, int fix = 4)
    {
      min.ThrowIfGreaterThan(max);
      fix.ThrowIfLessThan(0);

      return decimal.Parse(DecimalStringWithSeed(seed, min, max, fix));
    }

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
    public string DecimalString(int min = int.MinValue, int max = int.MaxValue, int fix = 4)
    {
      min.ThrowIfGreaterThan(max);
      fix.ThrowIfLessThan(0);

      var next = InternalRandom().NextDecimal(min, max);
      var numFixed = next.ToFixed(fix);

      return numFixed;
    }

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
    public string DecimalFloatString(float min = float.MinValue, float max = float.MaxValue, int fix = 4)
    {
      min.ThrowIfGreaterThan(max);
      fix.ThrowIfLessThan(0);

      var next = InternalRandom().NextDecimal(decimal.Parse(min.ToString("F8")), decimal.Parse(max.ToString("F8")));
      var numFixed = next.ToFixed(fix);

      return numFixed;
    }

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
    public string DecimalStringWithSeed(int seed, int min = int.MinValue, int max = int.MaxValue, int fix = 4)
    {
      min.ThrowIfGreaterThan(max);
      fix.ThrowIfLessThan(0);

      var next = InternalRandom(seed).NextDecimal(min, max);
      var numFixed = next.ToFixed(fix);

      return numFixed;
    }

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
    public int Integer(int min = int.MinValue, int max = int.MaxValue)
    {
      min.ThrowIfGreaterThan(max);

      var intRandom = InternalRandom().Next(min, max);
      return (int)Math.Floor((decimal)intRandom);
    }

    /// <summary>
    /// Return a random float.
    /// </summary>
    /// <param name="min">Minimum value of the range.</param>
    /// <param name="max">Maximum value of the range.</param>
    /// <param name="fix">Fixed precision of the decimal.</param>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="min"/> parameter is greater than the <paramref name="max"/> parameter.</exception>
    /// <exception cref="ArgumentException">This is thrown if <paramref name="fix"/> parameter is less than the zero.</exception>
    /// <returns>A float between the min and max range.</returns>
    public float Float(int min = int.MinValue, int max = int.MaxValue, int fix = 4)
    {
      min.ThrowIfGreaterThan(max);
      fix.ThrowIfLessThan(0);

      return float.Parse(DecimalString(min, max, fix));
    }

    public float Float(float min = float.MinValue, float max = float.MaxValue, int fix = 4)
    {
      min.ThrowIfGreaterThan(max);
      fix.ThrowIfLessThan(0);

      return float.Parse(DecimalFloatString(min, max, fix));
    }

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
    public int Natural(int min = 0, int max = int.MaxValue)
    {
      min.ThrowIfLessThan(0);
      min.ThrowIfGreaterThan(max);

      return Integer(min, max);
    }

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
    public string String(int? length = null, string pool = Constants.DefaultStringPool)
    {
      length.GetValueOrDefault(1).ThrowIfLessThanOrEqualTo(0);

      length = length.HasValue ? length.Value : Natural(5, 20);
      var text = "";

      for (var i = 0; i < length; i++)
      {
        text += Character(pool: pool);
      }

      return text;
    }
  }
}