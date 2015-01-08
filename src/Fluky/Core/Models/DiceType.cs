using System;

namespace Fluky.Core.Models
{
  [Flags]
  public enum DiceType : byte
  {
    D4 = 4,
    D6 = 6,
    D8 = 8,
    D10 = 10,
    D12 = 12,
    D20 = 20,
    D30 = 30,
    D100 = 100
  }
}
