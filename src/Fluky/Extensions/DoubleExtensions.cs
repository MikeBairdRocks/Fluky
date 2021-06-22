using System;

namespace Fluky.Extensions
{
  /// <summary>
  /// 
  /// </summary>
  public static class DoubleExtensions
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
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
