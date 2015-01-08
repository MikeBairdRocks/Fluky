using System;

namespace Fluky.Core.Extensions
{
  public static class ExceptionExtensions
  {
    public static void ThrowIfGreaterThan(this int value, int max)
    {
      if (value > max)
        throw new ArgumentOutOfRangeException(string.Format("Value has to be greater than {0}.", max), "value");
    }

    public static void ThrowIfGreaterThanOrEqualTo(this int value, int max)
    {
      if (value >= max)
        throw new ArgumentOutOfRangeException(string.Format("Value has to be greater than or equal to {0}.", max), "value");
    }

    public static void ThrowIfLessThan(this int value, int min)
    {
      if (value < min)
        throw new ArgumentOutOfRangeException(string.Format("Value can not be less than {0}.", min), "value");
    }

    public static void ThrowIfLessThanOrEqualTo(this int value, int min)
    {
      if (value <= min)
        throw new ArgumentOutOfRangeException(string.Format("Value can not be less than or equal to {0}.", min), "value");
    }

    public static void ThrowIfOutOfRange(this int value, int min, int max)
    {
      if (value < min || value > max)
        throw new ArgumentOutOfRangeException(string.Format("Value must be between {0} and {1}.", min, max), "value");
    }

    public static void ThrowIfGreaterThan(this float value, float max)
    {
      if (value > max)
        throw new ArgumentOutOfRangeException(string.Format("Value has to be greater than {0}.", max), "value");
    }

    public static void ThrowIfGreaterThanOrEqualTo(this float value, float max)
    {
      if (value >= max)
        throw new ArgumentOutOfRangeException(string.Format("Value has to be greater than or equal to {0}.", max), "value");
    }

    public static void ThrowIfLessThan(this float value, float min)
    {
      if (value < min)
        throw new ArgumentOutOfRangeException(string.Format("Value can not be less than {0}.", min), "value");
    }

    public static void ThrowIfLessThanOrEqualTo(this float value, float min)
    {
      if (value <= min)
        throw new ArgumentOutOfRangeException(string.Format("Value can not be less than or equal to {0}.", min), "value");
    }

    public static void ThrowIfOutOfRange(this float value, float min, float max)
    {
      if (value < min || value > max)
        throw new ArgumentOutOfRangeException(string.Format("Value must be between {0} and {1}.", min, max), "value");
    }
  }
}
