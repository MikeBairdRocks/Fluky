using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Fluky.DataSets;
using Fluky.Extensions;
using Random = System.Random;

namespace Fluky
{
  /// <summary>
  /// Fluky is a minimalist generator of random strings, numbers, etc. to help reduce the monotony particularly while writing automated tests or anywhere else you need anything random.
  /// </summary>
  public partial class Randomizer
  {
    private static readonly Lazy<object> Locker = new(() => new object(), LazyThreadSafetyMode.ExecutionAndPublication);
    private IData _data;
    private readonly Random InternalRandom;
    
    /// <summary>
    /// Set the random number generator manually with a seed to get reproducible results.
    /// </summary>
    public static Random Seed = new();
    
    /// <summary>
    /// 
    /// </summary>
    public Randomizer()
    {
      _data = new Data();
      InternalRandom = Seed;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="seed"></param>
    public Randomizer(int seed)
    {
      _data = new Data();
      InternalRandom = new Random(seed);
    }

    private string Capitalize(string value)
    {
      value = $"{value[0].ToString().ToUpper()}{value.Substring(1)}";

      return value;
    }

    private string Pad(int number, int width, char pad = '0')
    {
      var numberString = number.ToString(CultureInfo.InvariantCulture);
      return numberString.PadLeft(width, pad);
    }

    private T Pick<T>(List<T> list)
    {
      return list.Pick();
    }
  }
}
