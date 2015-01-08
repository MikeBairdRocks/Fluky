using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Fluky.Core;
using Fluky.Core.Extensions;
using Fluky.Core.Models;

namespace Fluky.Framework
{
  public partial class Randomizer
  {
    /// <summary>
    /// Return a value equal to the roll of a die.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public int Dice(DiceType? type = null)
    {
      var diceTypes = EnumExtensions.GetEnumValues<DiceType>().ToList();
      type = type.HasValue ? type.Value : Pick(diceTypes);

      var max = (int)type.Value;

      return Natural(1, max);
    }

    /// <summary>
    /// Return a random hex hash.
    /// </summary>
    /// <param name="length"></param>
    /// <param name="casing"></param>
    /// <returns></returns>
    public string Hash(int length = 40, CasingType casing = CasingType.Lower)
    {
      length.ThrowIfOutOfRange(0, 512);

      var pool = Constants.HexPool;
      switch (casing)
      {
        case CasingType.Upper:
          pool = pool.ToUpper();
          break;
        case CasingType.Both:
          pool = (pool + Constants.CharsUpper);
          break;
      }

      return String(length, pool);
    }

    /// <summary>
    /// Return a normally-distributed random variate.
    /// </summary>
    /// <param name="mean"></param>
    /// <param name="deviation"></param>
    /// <returns></returns>
    public double Normal(int mean = 0, int deviation = 1)
    {
      int u;
      int s;

      do
      {
        // U and V are from the uniform distribution on (-1, 1)
        u = InternalRandom().Next() * 2 - 1;
        var v = InternalRandom().Next() * 2 - 1;

        s = u * u + v * v;
      } while (s >= 1);

      // Compute the standard normal variate
      var norm = u * Math.Sqrt(-2 * Math.Log(s) / s);

      // Shape and scale
      return deviation * norm + mean;
    }

    /// <summary>
    /// Given an input looking like #d#, where the first # is the number of dice to roll and the second # is the max of each die, returns an array of dice values.
    /// </summary>
    /// <param name="die"></param>
    /// <param name="sum"></param>
    /// <returns></returns>
    public string Rpg(string die, bool sum = false)
    {
      var diceTypes = EnumExtensions.GetEnumValues<DiceType>().Select(x => ((int)x).ToString(CultureInfo.InvariantCulture)).ToArray();
      var allowed = string.Join("|", diceTypes);
      var regex = string.Format("(?<number>[1-9])(?<str>d)(?<type>({0}))", allowed);
      if (!Regex.IsMatch(die, regex))
        throw new ArgumentException("Die is not in the correct format. (3d20)", "die");

      var split = die.Split('d');
      var number = int.Parse(split[0]);
      var dieType = (DiceType)Enum.Parse(typeof(DiceType), split[1].ToString(CultureInfo.InvariantCulture));

      var list = new List<int>();
      for (var i = 0; i < number; i++)
      {
        var roll = Dice(dieType);
        list.Add(roll);
      }

      if (sum)
        return list.Sum(x => x).ToString(CultureInfo.InvariantCulture);

      return string.Join(",", list.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray());
    }
  }
}