using System.Collections.Generic;
using System.Globalization;
using Fluky.Extensions;
using Random = System.Random;

namespace Fluky
{
  /// <summary>
  /// Fluky is a minimalist generator of random strings, numbers, etc. to help reduce the monotony particularly while writing automated tests or anywhere else you need anything random.
  /// </summary>
  public partial class Randomizer : IRandomizer
  {
    private static readonly object SyncLock = new object();
    private static int? _seed;
    private readonly IData _data;

    /// <summary>
    /// 
    /// </summary>
    public Randomizer()
    {
      _data = new Data();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    public Randomizer(IData data)
    {
      _data = data;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="seed"></param>
    public Randomizer(int seed)
    {
      _data = new Data();
      _seed = seed;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="seed"></param>
    /// <param name="data"></param>
    public Randomizer(int seed, IData data)
    {
      _seed = seed;
      _data = data;
    }

    private static Random InternalRandom()
    {
      lock (SyncLock)
      {
        var seed = _seed.HasValue ? _seed.Value : System.Guid.NewGuid().GetHashCode();
        var internalRandom = new Random(seed);

        return internalRandom;
      }
    }

    private static Random InternalRandom(int seed)
    {
      lock (SyncLock)
      {
        var internalRandom = new Random(seed);

        return internalRandom;
      }
    }

    private string Capitalize(string value)
    {
      value = string.Format("{0}{1}", value[0].ToString().ToUpper(), value.Substring(1));

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
