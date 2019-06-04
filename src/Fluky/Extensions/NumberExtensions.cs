namespace Fluky.Extensions
{
  internal static class NumberExtensions
  {
    public static string ToFixed(this double number, int decimals)
    {
      var fix = $"F{decimals}";
      return number.ToString(fix);
    }

    public static string ToFixed(this int number, int decimals)
    {
      var fix = $"F{decimals}";
      return number.ToString(fix);
    }

    public static string ToFixed(this decimal number, int decimals)
    {
      var fix = $"F{decimals}";
      return number.ToString(fix);
    }
  }
}