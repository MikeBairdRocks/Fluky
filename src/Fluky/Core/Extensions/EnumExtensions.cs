using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluky.Core.Extensions
{
  internal static class EnumExtensions
  {
    public static IEnumerable<T> GetEnumValues<T>(this Enum value)
    {
      return Enum.GetValues(typeof(T)).Cast<T>();
    }

    public static IEnumerable<T> GetEnumValues<T>() where T : struct
    {
      return Enum.GetValues(typeof(T)).Cast<T>();
    }

    public static IEnumerable<string> GetEnumNames<T>()
    {
      return typeof(T).GetFields()
          .Select(info => info.Name)
          .Distinct()
          .ToList();
    }
  }
}
