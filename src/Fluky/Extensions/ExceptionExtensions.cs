using System;

namespace Fluky.Extensions
{
  /// <summary>
  /// 
  /// </summary>
  public static class ExceptionExtensions
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="max"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfGreaterThan(this int value, int max)
    {
      if (value > max)
        throw new ArgumentOutOfRangeException($"Value has to be greater than {max}.", "value");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="max"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfGreaterThanOrEqualTo(this int value, int max)
    {
      if (value >= max)
        throw new ArgumentOutOfRangeException($"Value has to be greater than or equal to {max}.", "value");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfLessThan(this int value, int min)
    {
      if (value < min)
        throw new ArgumentOutOfRangeException($"Value can not be less than {min}.", "value");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfLessThanOrEqualTo(this int value, int min)
    {
      if (value <= min)
        throw new ArgumentOutOfRangeException($"Value can not be less than or equal to {min}.", "value");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfOutOfRange(this int value, int min, int max)
    {
      if (value < min || value > max)
        throw new ArgumentOutOfRangeException($"Value must be between {min} and {max}.", "value");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="max"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfGreaterThan(this float value, float max)
    {
      if (value > max)
        throw new ArgumentOutOfRangeException($"Value has to be greater than {max}.", "value");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="max"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfGreaterThanOrEqualTo(this float value, float max)
    {
      if (value >= max)
        throw new ArgumentOutOfRangeException($"Value has to be greater than or equal to {max}.", "value");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfLessThan(this float value, float min)
    {
      if (value < min)
        throw new ArgumentOutOfRangeException($"Value can not be less than {min}.", "value");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfLessThanOrEqualTo(this float value, float min)
    {
      if (value <= min)
        throw new ArgumentOutOfRangeException($"Value can not be less than or equal to {min}.", "value");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfOutOfRange(this float value, float min, float max)
    {
      if (value < min || value > max)
        throw new ArgumentOutOfRangeException($"Value must be between {min} and {max}.", "value");
    }
  }
}
