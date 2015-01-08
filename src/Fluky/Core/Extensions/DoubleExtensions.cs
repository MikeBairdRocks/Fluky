using System;

namespace Fluky.Core.Extensions
{
  public static class DoubleExtensions
  {
    public static float ToFloat(this double value)
    {
      var result = Convert.ToSingle(value);
      if (float.IsPositiveInfinity(result))
        result = float.MaxValue;
      else if (float.IsNegativeInfinity(result))
        result = float.MinValue;

      return result;
    }
  }
}
