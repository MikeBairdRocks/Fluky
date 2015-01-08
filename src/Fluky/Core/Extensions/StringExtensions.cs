using System;
using System.Linq;

namespace Fluky.Core.Extensions
{
  internal static class StringExtensions
  {
    public static string Capitalize(this string input)
    {
      return string.IsNullOrEmpty(input) ? string.Empty : string.Format("{0}{1}", char.ToUpper(input[0]), input.Substring(1));
    }

    public static int GetDecimalLength(this string input)
    {
      decimal dec;
      if(!decimal.TryParse(input, out dec))
        throw new ArgumentException("String is not of type decimal.", input);

      var decimalLength = 0;
      if (!input.Contains(".") && !input.Contains(","))
        return decimalLength;

      var separator = new char[] { '.', ',' };
      var tempstring = input.Split(separator);
      decimalLength = tempstring[1].Length;

      return decimalLength;
    }

    public static bool ContainsUpper(this string value)
    {
      return value.Count(t => !char.IsLower(t)) > 0;
    }

    public static bool ContainsLower(this string value)
    {
      return value.Count(t => !char.IsUpper(t)) > 0;
    }

    public static bool IsUpper(this string value)
    {
      // Consider string to be uppercase if it has no lowercase letters.
      return value.All(t => !char.IsLower(t));
    }

    public static bool IsLower(this string value)
    {
      // Consider string to be lowercase if it has no uppercase letters.
      return value.All(t => !char.IsUpper(t));
    }
  }
}