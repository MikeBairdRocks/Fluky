using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluky.Extensions
{
  internal static class ListExtensions
  {
    private static readonly Random Random = new Random();

    public static int GetRandomIndex<T>(this ICollection<T> source)
    {
      return Random.Next(source.Count);
    }

    public static T Pick<T>(this IList<T> source)
    {
      return source[source.GetRandomIndex()];
    }

    public static List<T> Pick<T>(this IEnumerable<T> list, int count)
    {
      return list.OrderBy(arg => Guid.NewGuid()).Take(count).ToList();
    }

    public static IList<T> Shuffle<T>(this IList<T> source)
    {
      var rng = new Random();
      var n = source.Count;

      while (n > 1)
      {
        n--;
        var k = rng.Next(n + 1);
        var value = source[k];
        source[k] = source[n];
        source[n] = value;
      }

      return source;
    }
  }
}
