using System;

namespace Fluky.Extensions
{
  internal static class RandomExtensions
  {
    public static decimal NextDecimal(this Random random, decimal minValue, decimal maxValue)
    {
      var next = random.NextDouble();

      return minValue + (decimal)(next * (double)(maxValue - minValue));
    }

    public static int NextInt32(this Random rg)
    {
      unchecked
      {
        var firstBits = rg.Next(0, 1 << 4) << 28;
        var lastBits = rg.Next(0, 1 << 28);

        return firstBits | lastBits;
      }
    }
  }
}
